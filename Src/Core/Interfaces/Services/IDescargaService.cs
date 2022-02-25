using Core.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IDescargaService
    {
        Task<CreateDescargaDTO> InsertDescargaAsync(CreateDescargaDTO createDescargaDTO, CancellationToken cancellationToken = default);
    }
}
