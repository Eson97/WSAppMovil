using Core.DTO.Request;
using Core.DTO.Response;
using Core.Interfaces.Services;
using Core.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppService _appService;

        public AppController(IAppService appService) => _appService = appService;

        [HttpPost]
        public async Task<IActionResult> Post(CreateAppDTO request)
        {
            request = await _appService.InsertAppAsync(request);
            var response = new ApiResponse<CreateAppDTO>(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetApps()
        {
            var data = await _appService.GetAllAppsAsync();
            var response = new ApiResponse<IEnumerable<AppDTO>>(data);
            return Ok(response);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestApps()
        {
            var data = await _appService.GetAllAppsWithLatesVersion();
            var response = new ApiResponse<IEnumerable<AppWithVersionDTO>>(data);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApp(int id)
        {
            AppDTO appDTO = await _appService.FindAppAsync(id);
            
            if(appDTO == null)
                return NotFound();

            var response = new ApiResponse<AppDTO>(appDTO);
            return Ok(response);
        }


    }
}
