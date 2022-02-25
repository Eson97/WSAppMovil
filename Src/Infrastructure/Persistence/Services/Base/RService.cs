using AutoMapper;
using Core.Interfaces.Base;
using Core.Interfaces.Management;
using Core.Interfaces.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services.Base
{
    public class RService<TGetDTO, TKey, TEntity, TRepoRead, TContext> : IRService<TGetDTO, TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        internal readonly IMapper _mapper;
        internal readonly TRepoRead _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;

        protected IMapper Mapper => _mapper;
        protected TRepoRead Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public RService(TRepoRead repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TGetDTO>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken);
            return _mapper.Map<IEnumerable<TGetDTO>>(list);
        }

        public async Task<TGetDTO> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity entity = await _repository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<TGetDTO>(entity);
        }

        public async Task<IEnumerable<TGetDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.AllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TGetDTO>>(list);
        }
    }
}
