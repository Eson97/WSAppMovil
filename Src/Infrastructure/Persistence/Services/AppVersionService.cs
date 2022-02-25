using AutoMapper;
using Core.DTO.Request;
using Core.DTO.Response;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Services.Base;

namespace Infrastructure.Persistence.Services
{
    public class AppVersionService : CService<CreateAppVersionDTO, int, AppVersion, IAppVersionRepository<AppMovilDbContext>, AppMovilDbContext>, IAppVersionService
    {
        public AppVersionService(IAppVersionRepository<AppMovilDbContext> repository, IUnitOfWork<AppMovilDbContext> unitOfWork, IMapper mapper) : 
            base(repository, unitOfWork, mapper) { }

        public async Task<CreateAppVersionDTO> InsertAppVersionAsync(CreateAppVersionDTO createAppVersionDTO, CancellationToken cancellationToken = default)=>
            await InsertAsync(createAppVersionDTO,cancellationToken);
    }
}
