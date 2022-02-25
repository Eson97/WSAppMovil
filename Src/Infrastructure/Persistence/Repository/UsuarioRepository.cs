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
    internal class UsuarioRepository : BaseRepository<Usuario, int, AppMovilDbContext>, IUsuarioRepository<AppMovilDbContext>
    {
        public UsuarioRepository(IDbFactory<AppMovilDbContext> dbFactory) : base(dbFactory) { }
        public async Task<IEnumerable<Usuario>> GetAllUsersAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
    }
}
