using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Response
{
    public class DescargaDTO
    {
        public int Id { get; set; }
        public int IdAppVersion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaDescarga { get; set; }
    }
}
