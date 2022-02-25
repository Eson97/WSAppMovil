using Core.DTO.Request;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescargaController : ControllerBase
    {
        private readonly IDescargaService _descargaService;

        public DescargaController(IDescargaService descargaService) => _descargaService = descargaService;
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateDescargaDTO request)
        {
            request = await _descargaService.InsertDescargaAsync(request);
            var response = new ApiResponse<CreateDescargaDTO>(request);
            return Ok(response);
        }
    }
}
