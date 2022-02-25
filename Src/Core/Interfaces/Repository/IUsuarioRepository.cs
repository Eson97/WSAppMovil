using Core.Entities;
using Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IUsuarioRepository<TContext>:IBaseRepository<Usuario,TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<Usuario>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    }
}
