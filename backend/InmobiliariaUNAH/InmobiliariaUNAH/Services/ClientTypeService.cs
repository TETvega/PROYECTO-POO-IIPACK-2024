using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.ClientType;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaUNAH.Services
{
    public class ClientTypeService : IClientTypeService
    {
        private readonly InmobiliariaUNAHContext _context;
        private readonly IMapper _mapper;

        public ClientTypeService(InmobiliariaUNAHContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ClientTypeDto>>> GetClientsTypesListAsync()
        {
            var clientsTypesEntity = await _context.TypesOfClient.ToArrayAsync();


            var clientsTypesDtos = _mapper.Map<List<ClientTypeDto>>(clientsTypesEntity);

            return new ResponseDto<List<ClientTypeDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de tipos de cliente obtenido correctamente.",
                Data = clientsTypesDtos
            };
        }

        public async Task<ResponseDto<ClientTypeDto>> GetClientTypeAsync(Guid id)
        {
            var clientTypeEntity = await _context.TypesOfClient.FirstOrDefaultAsync(ct => ct.Id == id);
            if (clientTypeEntity == null)
            {
                return new ResponseDto<ClientTypeDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el tipo de cliente.",
                };
            }

            var ClientTypeDto = _mapper.Map<ClientTypeDto>(clientTypeEntity);

            return new ResponseDto<ClientTypeDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Listado de producto obtenida correctamente",
                Data = ClientTypeDto
            };
        }
        public async Task<ResponseDto<ClientTypeDto>> CreateClientTypeAsync(ClientTypeCreateDto dto)
        {

            var ClientTypeEntity = _mapper.Map<ClientTypeEntity>(dto);
            _context.TypesOfClient.Add(ClientTypeEntity);
            await _context.SaveChangesAsync();

            var ClientTypeDto = _mapper.Map<ClientTypeDto>(ClientTypeEntity);

            return new ResponseDto<ClientTypeDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Producto creado correctamente.",
                Data = ClientTypeDto,
            };

        }

        public async Task<ResponseDto<ClientTypeDto>> EditClientTypeAsync(ClientTypeEditDto dto, Guid id)
        {
            var ClientTypeEntity = await _context.TypesOfClient.FirstOrDefaultAsync(ct => ct.Id == id);
            if (ClientTypeEntity == null)
            {
                return new ResponseDto<ClientTypeDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el producto la categoría de producto especificada.",
                };
            }

            _mapper.Map<ClientTypeEditDto, ClientTypeEntity>(dto, ClientTypeEntity);
            _context.TypesOfClient.Update(ClientTypeEntity);
            await _context.SaveChangesAsync();

            var ClientTypeDto = _mapper.Map<ClientTypeDto>(ClientTypeEntity);

            return new ResponseDto<ClientTypeDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Tipode cliente modificado correctamente.",
                Data = ClientTypeDto
            };
        }
        public async Task<ResponseDto<ClientTypeDto>> DeleteClientTypeAsync(Guid id)
        {
            var categoryProductEntity = await _context.TypesOfClient.FirstOrDefaultAsync(p => p.Id == id);

            if (categoryProductEntity is null)
            {
                return new ResponseDto<ClientTypeDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró la categoria del producto.",
                };
            }

            _context.TypesOfClient.Remove(categoryProductEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<ClientTypeDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Tipo de cliente eliminado correctamente.",

            };
        }
    }
}
