using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.ClientType;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Services;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaUNAH.Controllers
{
    [ApiController]
    [Route("api/clientstypes")]
    public class ClientTypeController : ControllerBase
    {
        private readonly IClientTypeService _clientTypeService;
        public ClientTypeController(IClientTypeService clientTypeService)
        {
            _clientTypeService = clientTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<CategoryProductEntity>>> GetAll()
        {
            var response = await _clientTypeService.GetClientsTypesListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto<CategoryProductDto>>> Get(Guid id)
        {
            var response = await _clientTypeService.GetClientTypeAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<CategoryProductDto>>> Create(ClientTypeCreateDto dto)
        {
            var response = await _clientTypeService.CreateClientTypeAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ResponseDto<CategoryProductDto>>> Edit(ClientTypeEditDto dto, Guid id)
        {
            var response = await _clientTypeService.EditClientTypeAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<ResponseDto<CategoryProductDto>>> Delete(Guid id)
        {
            var response = await _clientTypeService.DeleteClientTypeAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
