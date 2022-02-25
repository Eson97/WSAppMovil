using AutoMapper;
using Core.DTO.Request;
using Core.DTO.Response;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services.Base;

namespace Infrastructure.Persistence.Services
{
    public class AppService : CRUDService<AppDTO, CreateAppDTO, int, App, IAppRepository<AppMovilDbContext>, AppMovilDbContext>, IAppService
    {
        public AppService(IMapper mapper, IUnitOfWork<AppMovilDbContext> unitOfWork, IAppRepository<AppMovilDbContext> appRepository): 
            base(appRepository, unitOfWork, mapper) { }

        public async Task<AppDTO> FindAppAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);

        public async Task<IEnumerable<AppDTO>> GetAllAppsAsync(CancellationToken cancellationToken = default) =>
            await GetAllAsync(cancellationToken);

        public async Task<IEnumerable<AppWithVersionDTO>> GetAllAppsWithLatesVersion(CancellationToken cancellationToken = default)=>
            await _repository.GetLatestAppAsync(cancellationToken);

        public async Task<CreateAppDTO> InsertAppAsync(CreateAppDTO createAppDTO, CancellationToken cancellationToken = default) =>
            await InsertAsync(createAppDTO, cancellationToken);

    }
}
