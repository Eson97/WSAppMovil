using AutoMapper;
using Core.DTO.Request;
using Core.DTO.Response;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services
{
    internal class DescargaService : CService<CreateDescargaDTO, int, Descarga, IDescargaRepository<AppMovilDbContext>, AppMovilDbContext>, IDescargaService
    {
        public DescargaService(IDescargaRepository<AppMovilDbContext> repository, IUnitOfWork<AppMovilDbContext> unitOfWork, IMapper mapper) : 
            base(repository, unitOfWork, mapper) { }

        public async Task<CreateDescargaDTO> InsertDescargaAsync(CreateDescargaDTO createDescargaDTO, CancellationToken cancellationToken = default) =>
            await InsertAsync(createDescargaDTO, cancellationToken);
    }
}
