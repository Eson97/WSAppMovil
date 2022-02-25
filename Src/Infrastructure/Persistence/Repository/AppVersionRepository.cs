using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class AppVersionRepository : BaseRepository<AppVersion, int, AppMovilDbContext>, IAppVersionRepository<AppMovilDbContext>
    {
        public AppVersionRepository(IDbFactory<AppMovilDbContext> dbFactory) : base(dbFactory) { }

        public async Task AddVersionAsync(AppVersion appVersion, CancellationToken cancellationToken = default) =>
            await AddAsync(appVersion, cancellationToken);
    }
}
