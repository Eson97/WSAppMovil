using Core.Interfaces.Base;
using Core.Interfaces.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services.Base
{
    public interface ICService<TAddDTO,TKey,TEntity,TRepoRead,TContext>
        where TEntity : class , IEntityBase<TKey>
        where TRepoRead : IBaseRepository<TEntity,TContext> //se usa base ya que no existen update o delete en este de momento
        where TContext : DbContext, new()
    {
        Task<TAddDTO> InsertAsync(TAddDTO dto, CancellationToken cancellationToken = default);
    }
}
