using Core.DTO.Response;
using Core.Entities;
using Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IAppRepository<TContext>: IBaseRepository<App,TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<App>> GetAllAppsAsync(CancellationToken cancellationToken = default);
        Task<App> GetAppByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<App>> FilterAppAsync(Expression<Func<App, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task AddAppAsync(App app, CancellationToken cancellationToken = default);
        Task<IEnumerable<AppWithVersionDTO>> GetLatestAppAsync(CancellationToken cancellationToken= default);

        //update
        //delete
    }
}
