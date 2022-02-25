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
    public class DescargaRepository : BaseRepository<Descarga, int, AppMovilDbContext>, IDescargaRepository<AppMovilDbContext>
    {
        public DescargaRepository(IDbFactory<AppMovilDbContext> dbFactory) : base(dbFactory) { }

        public async Task AddDescarga(Descarga descarga, CancellationToken cancellationToken = default) =>
            await AddAsync(descarga, cancellationToken);
    }
}
