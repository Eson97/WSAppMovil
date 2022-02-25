using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository.Base;
using System.Linq.Expressions;
using System.Linq;
using Core.DTO.Response;

namespace Infrastructure.Persistence.Repository
{
    public class AppRepository : BaseRepository<App, int, AppMovilDbContext>, IAppRepository<AppMovilDbContext>
    {
        public AppRepository(IDbFactory<AppMovilDbContext> dbFactory) : base(dbFactory) { }

        public async Task AddAppAsync(App app, CancellationToken cancellationToken = default) =>
            await AddAsync(app, cancellationToken);

        public async Task<IEnumerable<App>> FilterAppAsync(Expression<Func<App, bool>> filterExpression, CancellationToken cancellationToken = default)=>
            await FilterAsync(filterExpression, cancellationToken);

        public async Task<IEnumerable<App>> GetAllAppsAsync(CancellationToken cancellationToken = default)=>
            await AllAsync(cancellationToken);

        public async Task<App> GetAppByIdAsync(int id, CancellationToken cancellationToken = default)=>
            await GetByIdAsync(id, cancellationToken);

        public async Task<IEnumerable<AppWithVersionDTO>> GetLatestAppAsync(CancellationToken cancellationToken = default)
        {
            List<AppWithVersionDTO> response = new List<AppWithVersionDTO>();
            
            //Obtenemos la lista de todas las apps
            IEnumerable<App> lista = await AllAsync(cancellationToken);

            foreach (App app in lista)
            {
                //Por cada aplicacion, obtenemos su version mas reciente
                var latestVersion = DbContext.AppVersions
                    .Where(x => x.IdApp == app.Id)
                    .OrderByDescending(x => x.FechaPublicacion)
                    .FirstOrDefault();

                //Si tiene versiones existentes agregamos los datos a la respuesta
                if (latestVersion != null)
                    response.Add(new AppWithVersionDTO
                    {
                        Id = app.Id,
                        Nombre = app.Nombre,
                        AppVersion1 = latestVersion.AppVersion1,
                        FechaPublicacion = latestVersion.FechaPublicacion,
                        UrlDescarga = latestVersion.UrlDescarga
                    });
            }

            return response;
        }

    }
}
