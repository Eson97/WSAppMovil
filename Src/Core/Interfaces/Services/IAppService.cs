using Core.DTO.Request;
using Core.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAppService
    {
        Task<AppDTO> FindAppAsync(int id,CancellationToken cancellationToken = default);
        Task<IEnumerable<AppDTO>> GetAllAppsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<AppWithVersionDTO>> GetAllAppsWithLatesVersion(CancellationToken cancellationToken = default);
        Task<CreateAppDTO> InsertAppAsync(CreateAppDTO creatAppDTO, CancellationToken cancellationToken = default);

        //update
        //delete
    }
}
