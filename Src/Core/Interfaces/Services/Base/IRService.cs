using Core.Interfaces.Base;
using Core.Interfaces.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services.Base
{
    public interface IRService<TGetDTO, TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<TGetDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TGetDTO> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TGetDTO>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
