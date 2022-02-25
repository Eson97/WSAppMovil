using AutoMapper;
using Core.Interfaces.Base;
using Core.Interfaces.Management;
using Core.Interfaces.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services.Base
{
    public class CService<TAddDTO, TKey, TEntity, TRepoCreate, TContext> : ICService<TAddDTO, TKey, TEntity, TRepoCreate, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoCreate : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        internal readonly IMapper _mapper;
        internal readonly TRepoCreate _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;

        protected IMapper Mapper => _mapper;
        protected TRepoCreate Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

        public CService(TRepoCreate repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
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
