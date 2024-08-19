using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Events;
using InmobiliariaUNAH.Dtos.Events.Helper_Dto;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<ResponseDto<EventDto>> GetEventById(Guid id)
        {
            var eventEntity = await _context.Events
            .Include(e => e.User)
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
        private ResponseDto<EventDto> ExeptionProductosNoExistentes(List<Guid> ProductsNoExistentes)
        {
            // https://www.youtube.com/watch?v=ZAgnc0sbzA8&ab_channel=ConsejosC%23
            // el video habla por si le queres entender como funciona lo de concatenacion de strigs
            // aunque aun asi no encuentro como hacer que se pongan con una linea de por medio sale /r/n
            var errorMessages = new StringBuilder();
            foreach (var productId in ProductsNoExistentes)
            {
                errorMessages.AppendLine($"{productId}");
            }
            var errorMessagesString = errorMessages.ToString().Replace("\r\n", ", ");

            return new ResponseDto<EventDto>
            {
                StatusCode = 404,
                Status = false,
                Message = $"El o los productos: {errorMessagesString}no exiten en la base de datos."
            };
        }
       
        private async Task<string> ValidacionDeProductosFechas(DateTime startDate,
          DateTime endDate,
          IEnumerable<EventProducDto> productos,
          List<ReservationEntity> newReservations,
          IEnumerable<ReservationEntity> ExistinReservations,
          EventEntity eventEntity,
          List<ProductEntity> existingProducts)
            {
                var errorMessages2 = new StringBuilder();
                 var productosData = await _context.Products.ToListAsync();
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    foreach (var product in productos)
                    {
                        var productId = product.ProductId;
                        var CantidadSolicitada = product.Quantity;

                        // para calcular la cantidad de producto en una fecha especifica
                        var existingTotalCount = ExistinReservations
                            .Where(reservation => reservation.ProductId == productId && reservation.Date == date)
                            .Sum(reservation => reservation.Count);

                        var productEntityIteracion = existingProducts.FirstOrDefault(p => p.Id == productId);
                        var StockProductoIteracion = productEntityIteracion?.Stock ?? 0;

                        // verificacion de los de reserva contra el stock
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
                        var productoEnData = productosData.FirstOrDefault(p => p.Id == productId);
                            errorMessages2.AppendLine($"El producto {
                               productoEnData.Name
                                } no tiene suficiente stock para la fecha {date.ToShortDateString()}.");
                        }
                    }
                }

                // Si hay error los devuelve en cadena de string y si no un string vacio asi ""
                return errorMessages2.Length > 0 ? errorMessages2.ToString().Replace("\r\n", " ") : string.Empty;
        }
        // Funcion parala validacion de las Fechas Aqui va toda la Loguica conrespecto a Fechas
        private ResponseDto<EventDto> ValidarFechas(DateTime startDate, DateTime endDate)
        {
            if ((startDate > endDate) || (startDate < DateTime.Today))
            {
                return new ResponseDto<EventDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = "La fecha de Inicio no puede ser Despues de la Fecha de Finalizacion"
                };
            }
            else if (startDate.Date == DateTime.Today)
            {
                return new ResponseDto<EventDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = "La fecha de inicio no puede ser el dia de hoy. Por favor, seleccione una fecha a partir de mañana."
                };
            }

            return null; 
        }

        private (List<DetailEntity> details, decimal eventCost) GenerarDetallesYCalcularCosto(
            EventCreateDto dto,
            EventEntity eventEntity,
            List<ProductEntity> existingProducts)
        {
            //lista de detalles del evento
            var newListDetails = new List<DetailEntity>();
            decimal eventCost = 0; // costo final del evento en cuestion

            foreach (var product in dto.Productos)
            {
                var productoIteracion = existingProducts.FirstOrDefault(p => p.Id == product.ProductId);

                if (productoIteracion != null)
                {
                    newListDetails.Add(new DetailEntity
                    {
                        EventId = eventEntity.Id,
                        ProductId = product.ProductId,
                        Quantity = product.Quantity,
                        UnitPrice = productoIteracion.Cost,
                        TotalPrice = product.Quantity * productoIteracion.Cost,
                    });

                    eventCost += product.Quantity * productoIteracion.Cost;
                }
            }

            return (newListDetails, eventCost);
        }
        // para obtrener el tipo de cliente
        // deje esto asi por si algo cuando agregemos a los usuarios o demas
        private async Task<(ClientTypeEntity clientType, ResponseDto<EventDto> error)> ObtenerTipoDeClienteAsync(Guid clientTypeId)
        {
            var clientType = await _context.TypesOfClient.FirstOrDefaultAsync(t => t.Id == clientTypeId);
            if (clientType is null)
            {
                return (null, new ResponseDto<EventDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Error con el tipo de cliente."
                });
            }

            return (clientType, null);
        }
        // valida si el usuario existe
        private async Task<(UserEntity user, ResponseDto<EventDto> error)> ValidarUsuarioAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
            {
                return (null, new ResponseDto<EventDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Usuario no encontrado"
                });
            }

            return (user, null);
        }
        public async Task<ResponseDto<EventDto>> CreateEvent(EventCreateDto dto)
        {
            ///// validacion si existen los productos

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
                return ExeptionProductosNoExistentes(ProductsNoExistentes);
               
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

                    DateTime startDate = dto.StartDate.Date;
                    DateTime endDate = dto.EndDate.Date;

                    var validacionFechasResult = ValidarFechas(startDate, endDate);
                    if (validacionFechasResult != null)
                    {
                        return validacionFechasResult;
                    }

                    var newReservations = new List<ReservationEntity>();
                    var errorMesagesValidacionProductos =await  ValidacionDeProductosFechas(startDate, endDate, dto.Productos, newReservations, ExistinReservations ,eventEntity, existingProducts);
                    if(errorMesagesValidacionProductos.Length > 0)
                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 405,
                        Status = false,
                        Message = errorMesagesValidacionProductos,
                    };


                    // guardar todos los cambios 
                    await _context.Reservations.AddRangeAsync( newReservations );
                    await _context.SaveChangesAsync();

                    // para obtener los detalles y el costo del evento 
                    // mira esta chulada encontre algo en tik tok y busque y fua gloria oro puro 
                    // https://es.stackoverflow.com/questions/460803/se-pueden-devolver-varios-valores-con-un-return-c
                    // Detro de la funcion estoy definiendo el tipo de dato osea returna el tipo de dato por dentro
                    var (newListDetails, eventCost) = GenerarDetallesYCalcularCosto(dto, eventEntity, existingProducts);

                    await _context.Details.AddRangeAsync(newListDetails);
                    await _context.SaveChangesAsync();

                    // creando el evento correctamente 
                    eventEntity.EventCost = eventCost;

                    // TODO EL DESCUENTO NECESITAMOS SABER QUIEN ES EL QUE MANDA ESTO 

                    // Validar usuario
                    var (user, userError) = await ValidarUsuarioAsync(eventEntity.UserId);
                    if (userError != null)
                    {
                        return userError;
                    }

                    // Obtener tipo de cliente
                    var (clientType, clientTypeError) = await ObtenerTipoDeClienteAsync(user.ClientTypeId);
                    if (clientTypeError != null)
                    {
                        return clientTypeError;
                    }
                    var discount = eventEntity.Discount = ((eventEntity.EventCost) * (clientType.Discount));
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


        public async Task<ResponseDto<EventDto>> CancelEventAsync(Guid id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var eventEntity = await _context.Events.FindAsync(id);
                    if (eventEntity is null)
                    {
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 404,
                            Status = false,
                            Message = $"No se encontró el Evento con el id: {id}"
                        };
                    }
                    _context.Events.Remove(eventEntity);
                    await _context.SaveChangesAsync();

                    var details = await _context.Details.Where(d => d.EventId == id).ToListAsync();
                    _context.Details.RemoveRange(details);
                    await _context.SaveChangesAsync();

                    var reservations = await _context.Reservations.Where(d => d.EventId == id).ToListAsync();
                    _context.Reservations.RemoveRange(reservations);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 200,
                        Status = true,
                        Message = "El evento ha sido cancelado correctamente"
                    };
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(e, "Error al cancelar evento en el try.");
                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 500,
                        Status = false,
                        Message = "Error al cancelar evento."
                    };
                }
            }
        }

        public async Task<ResponseDto<EventDto>> EditEventAsync(EventEditDto dto, Guid id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var CheckEventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

                if (CheckEventEntity is null)
                {
                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = $"El evento a editar no fue encontrado."
                    };
                }
                var userId = CheckEventEntity.UserId;

                DateTime startDate = dto.StartDate.Date;
                DateTime endDate = dto.EndDate.Date;
                var validacionFechasResult = ValidarFechas(startDate, endDate);
                if (validacionFechasResult != null)
                {
                    return validacionFechasResult;
                }
                var existingProducts = await _context.Products.ToListAsync();
                var productIdsInDto = dto.Productos.Select(p => p.ProductId).ToList();

                var ProductsNoExistentes = productIdsInDto
                   .Where(dtoProductId => !existingProducts.Any(eP => eP.Id == dtoProductId))
                   .ToList();


                // Compartido
                var ProductosNoExistentesdelDto = ProductsNoExistentes.Count();
                if (ProductosNoExistentesdelDto > 0)
                {
                    return ExeptionProductosNoExistentes(ProductsNoExistentes);

                }
                ///
                try
                {
                    var eventEntity = _mapper.Map(dto, CheckEventEntity); // Actualiza el evento existente        
                    eventEntity.UserId = userId;                                                    
                    _context.Events.Update(eventEntity);
                    await _context.SaveChangesAsync();

                    var details = await _context.Details.Where(d => d.EventId == id).ToListAsync();
                    _context.Details.RemoveRange(details);
                    await _context.SaveChangesAsync();

                    var reservations = await _context.Reservations.Where(d => d.EventId == id).ToListAsync();
                    _context.Reservations.RemoveRange(reservations);
                    await _context.SaveChangesAsync();

                    var ExistinReservations = await _context.Reservations
                        .Where(reservation => productIdsInDto.Contains(reservation.ProductId))
                        .ToListAsync();

                    var newReservations = new List<ReservationEntity>();
                    var errorMesagesValidacionProductos =await ValidacionDeProductosFechas(startDate, endDate, dto.Productos, newReservations, ExistinReservations, eventEntity, existingProducts);
                    if (errorMesagesValidacionProductos.Length > 0)
                        return new ResponseDto<EventDto>
                        {
                            StatusCode = 405,
                            Status = false,
                            Message = errorMesagesValidacionProductos,
                        };


                    await _context.Reservations.AddRangeAsync(newReservations);
                    await _context.SaveChangesAsync();

                    var (newListDetails, eventCost) = GenerarDetallesYCalcularCosto(dto, eventEntity, existingProducts);


                    await _context.Details.AddRangeAsync(newListDetails);
                    await _context.SaveChangesAsync();

                    eventEntity.EventCost = eventCost;

                    // Validar usuario
                    var (user, userError) = await ValidarUsuarioAsync(eventEntity.UserId);
                    if (userError != null)
                    {
                        return userError;
                    }

                    // Obtener tipo de cliente
                    var (clientType, clientTypeError) = await ObtenerTipoDeClienteAsync(user.ClientTypeId);
                    if (clientTypeError != null)
                    {
                        return clientTypeError;
                    }
                    var discount = eventEntity.Discount = ((eventEntity.EventCost) * (clientType.Discount));
                    eventEntity.Total = eventEntity.EventCost - discount;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                  //  var eventDto = _mapper.Map<EventDto>(eventEntity);
                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 200,
                        Status = true,
                        Message = "Exito al EDITAR UN EVENTO",
                        //Data = eventDto
                    };
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(e, "Error al editar el evento en el try.");
                    return new ResponseDto<EventDto>
                    {
                        StatusCode = 500,
                        Status = false,
                        Message = "Error al editar el evento."
                    };
                }
            }
        }


    }
}
