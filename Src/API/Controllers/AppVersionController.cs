using Core.DTO.Request;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppVersionController : ControllerBase
    {
        private readonly IAppVersionService _appVersionService;

        public AppVersionController(IAppVersionService appVersionService) => _appVersionService = appVersionService;

        [HttpPost]
        public async Task<IActionResult> Post(CreateAppVersionDTO request)
        {
            request = await _appVersionService.InsertAppVersionAsync(request);
            var response = new ApiResponse<CreateAppVersionDTO>(request);
            return Ok(response);
        }



    }
}
