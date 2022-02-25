using AutoMapper;
using Core.Exceptions;
using Core.Interfaces.Base;
using Core.Interfaces.Management;
using Core.Interfaces.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Services.Base
{
    public abstract class CRUDService<TGetDTO, TAddDTO, TKey, TEntity, TRepoAll, TContext> : ICRUDService<TGetDTO, TAddDTO, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity,TContext>
        where TContext : DbContext, new()
    {
        internal readonly IMapper _mapper;
        internal readonly TRepoAll _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;

        protected TRepoAll Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public CRUDService(TRepoAll repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
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
            TEntity entity = await _repository.GetByIdAsync(id);

            if (entity == null) 
                throw new EntityNotFoundException(typeof(TEntity), id);
            
            return  _mapper.Map<TGetDTO>(entity);
        }

        public async Task<IEnumerable<TGetDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.AllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TGetDTO>>(list);
        }

        public async Task<TAddDTO> InsertAsync(TAddDTO dto, CancellationToken cancellationToken = default)
        {
            TEntity addEntity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(addEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<TAddDTO>(addEntity);
        }
    }
}
