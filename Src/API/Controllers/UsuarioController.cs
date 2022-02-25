using Core.DTO.Response;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        
        public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var data = await _usuarioService.GetAllUsuariosAsync();
            var response = new ApiResponse<IEnumerable<UsuarioDTO>>(data);
            return Ok(response);
        }
    }
}
