using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO.Response;
using Core.Entities;
using Core.Interfaces.Base;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Services.Base;

namespace Infrastructure.Persistence.Services

{
    internal class UsuarioService : RService<UsuarioDTO, int, Usuario, IUsuarioRepository<AppMovilDbContext>, AppMovilDbContext>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository<AppMovilDbContext> repository, IUnitOfWork<AppMovilDbContext> unitOfWork, IMapper mapper) :
            base(repository, unitOfWork, mapper) { }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync(CancellationToken cancellationToken = default) =>
            await GetAllAsync(cancellationToken);
    }
}
