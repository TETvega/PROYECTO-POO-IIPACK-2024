using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Events;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace InmobiliariaUNAH.Services
{
    public class EventsService : IEventService
    {

        private readonly InmobiliariaUNAHContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<IEventService> _logger;

        public EventsService(
            InmobiliariaUNAHContext context,
            IMapper mapper,
            ILogger<IEventService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseDto<List<EventDto>>> GetAllEventsAsync()
        {
            var eventsEntity = await _context.Events
            .Include(e => e.EventDetails)
            .ThenInclude(ed => ed.Product) 
            .ToListAsync();


            var eventsDto = _mapper.Map<List<EventDto>>(eventsEntity);

            return new ResponseDto<List<EventDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de eventos obtenida correctamente",
                Data = eventsDto
            };
        }

        public async Task<ResponseDto<EventDto>> GeEventById(Guid id)
        {
            var eventEntity = await _context.Events
            .Include(e => e.EventDetails)
            .ThenInclude(ed => ed.Product)
            .FirstOrDefaultAsync(ev => ev.Id == id);

            if (eventEntity == null)
            {
                return new ResponseDto<EventDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el evento",
                };
            }

            var eventDto = _mapper.Map<EventDto>(eventEntity);

            return new ResponseDto<EventDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de eventos obtenida correctamente",
                Data = eventDto
            };
        }

        public async Task<ResponseDto<EventDto>> CreateEvent(EventCreateDto dto)
        {
            ///// validacion si existen los productos
            var error = false;
            var eventEntity = _mapper.Map<EventEntity>(dto);
           

            var existingProducts = await _context.Products.ToListAsync();
            var productIdsInDto = dto.Productos.Select(p => p.ProductId).ToList();

            // anner esta es para ver cuales no existen 
            // el any es si alguno de los de la tabla existen entoncess es un si , el ! es si almenos uno de ellos NO existe en la tabla
            //Productos que están presentes en el DTO pero no existen en la base de datos.
            var ProductsNoExistentes = productIdsInDto
                .Where(dtoProductId => !existingProducts.Any(eP => eP.Id == dtoProductId))
                .ToList();

            // si hay un producto existente sera 1 o mayor a 1 
            var ProductosNoExistentesdelDto = ProductsNoExistentes.Count();
            if (ProductosNoExistentesdelDto > 0)
            {
                // https://www.youtube.com/watch?v=ZAgnc0sbzA8&ab_channel=ConsejosC%23
                // el video habla por si le queres entender como funciona lo de concatenacion de strigs
                // aunque aun asi no encuentro como hacer que se pongan con una linea de por medio sale /r/n
                var errorMessages = new StringBuilder();
                foreach (var productId in ProductsNoExistentes)
                {
                    errorMessages.AppendLine($"{productId}");
                }
                var  errorMessagesString = errorMessages.ToString().Replace("\r\n", ", ");

                return new ResponseDto<EventDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = $"El o los productos: {errorMessagesString}no exiten en la base de datos."
                };
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {

                try
                {
                    // Para saber el User ID tambien 
                    // TODO
                    eventEntity.UserId = new Guid("b1234567-89ab-cdef-0123-456789abcdef");
                    await _context.Events.AddAsync(eventEntity);
                    await _context.SaveChangesAsync();
                    // verficacion de fechas 
                    // Todas las Reservaciones que coinciden con los id de productos existentes
// Se obtienen todas las reservas que coinciden con los IDs de productos proporcionados en la solicitud. Para verificar las reservas existentes que puedan afectar el stock de los productos.
                    var ExistinReservations = await _context.Reservations
                        .Where(reservation => productIdsInDto.Contains(reservation.ProductId)) 
                        .ToListAsync();

                    var errorMessages2 = new StringBuilder();
                    var newReservations = new List<ReservationEntity>();

                    DateTime startDate = dto.StartDate;
                    DateTime endDate = dto.EndDate;

                    if ( (startDate > endDate)  || (startDate < DateTime.Today))
                    {
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 400,
                            Status = false,
                            Message = "La fecha de inicio no puede ser posterior a la fecha de finalización ni ser anterior a la fecha actual. Por favor, revise las fechas ingresadas."
                        };
                    }else if(startDate.Date == DateTime.Today)
                    {
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 400,
                            Status = false,
                            Message = "La fecha de inicio no puede ser el día de hoy. Por favor, seleccione una fecha a partir de mañana."
                        };
                    }

                    // para las fechas agregando un dia
                    for (var date = startDate; date <= endDate; date = date.AddDays(1))
                    {
                        foreach (var product in dto.Productos)
                        {
                            var productId = product.ProductId;
                            var CantidadSolicitada = product.Quantity;

                            // validando el id y que sea el mismo dia 
                            //  calcular la cantidad total de un producto que ya ha sido reservado en una fecha específica
                            var existingTotalCount = ExistinReservations
                                .Where(reservation => ( (reservation.ProductId == productId) && (reservation.Date == date) )) // Selecciona solo aquellas reservas cuyo 'productId'  coincide con el 'productId' dado && cuya Date coincide con la fecha proporcionada (date).
                                .Sum(reservation => reservation.Count);// aqui esta sumando la cantidad solicitada 


                            var productEntityIteracion = existingProducts.FirstOrDefault(p => p.Id == productId);
                            var StockProductoIteracion = productEntityIteracion.Stock;

                            // varifica si el producto solicitado ese dia mas la suma de las reservaciones de ese producto ese dia es menos o igual al stok de ese dia
                            if (existingTotalCount + CantidadSolicitada <= StockProductoIteracion)
                            {
                                newReservations.Add(new ReservationEntity
                                {
                                    ProductId = productId,
                                    EventId = eventEntity.Id,
                                    Date = date,
                                    Count = CantidadSolicitada,
                                    Name = eventEntity.Name,
                                    
                                });
                            }
                            else
                            {
                                error = true;
                                errorMessages2.AppendLine($"El producto con ID {productId} no tiene suficiente stock para la fecha {date.ToShortDateString()}.");
                            }
                        }
                    }

                    var errorMesagesString2 = errorMessages2.ToString().Replace("\r\n", " ");
                    if (error)
                    {
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 405,
                            Status = false,
                            Message = errorMesagesString2,
                        };
                        
                    }
                    // guardar todos los cambios 
                    await _context.Reservations.AddRangeAsync( newReservations );
                    await _context.SaveChangesAsync();

                    var newListDetails = new List<DetailEntity>();
                    Decimal eventCost = 0;
                    // para añadir el detalle segun cada producto

                    foreach (var product in dto.Productos)
                    {
                        var productoIteracion = existingProducts.FirstOrDefault(p => p.Id ==  product.ProductId);

                        newListDetails.Add(new DetailEntity
                        {
                            EventId = eventEntity.Id,
                            ProductId = product.ProductId,
                            Quantity = product.Quantity,
                            UnitPrice = productoIteracion.Cost,
                            TotalPrice = product.Quantity * productoIteracion.Cost,

                        });
                        eventCost += (product.Quantity) * (productoIteracion.Cost);
                    }

                    await _context.Details.AddRangeAsync(newListDetails);
                    await _context.SaveChangesAsync();

                    // creando el evento correctamente 
                    eventEntity.EventCost = eventCost;

                    // TODO EL DESCUENTO NECESITAMOS SABER QUIEN ES EL QUE MANDA ESTO 
                    //eventEntity.Discount = 


                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == eventEntity.UserId);
                    if (user is null) 
                    {
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 404,
                            Status = false,
                            Message = "Usuario no encontrado"
                        };
                    }

                    var clientTypeOfUser = await _context.TypesOfClient.FirstOrDefaultAsync(u => u.Id == user.ClientTypeId);
                    if (clientTypeOfUser is null)
                    {
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 404,
                            Status = false,
                            Message = "Error con el tipo de cliente."
                        };
                    }
                    var discount = eventEntity.Discount = ((eventEntity.EventCost) * (clientTypeOfUser.Discount));
                    eventEntity.Total = eventEntity.EventCost - discount;

                   // eventEntity.Total = eventEntity.EventCost - eventEntity.Discount;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    var eventDto = _mapper.Map<EventDto>(eventEntity);

                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 200,
                        Status = true,
                        Message = "Exito al CREAR UN EVENTO",
                        Data = eventDto
                        
                    };

                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(e, "Error al crear un Evento en el try");
                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 500,
                        Status = false,
                        Message = "Error al crear un nuevo Evento"
                    };

                }

            }
        }
    }
}
