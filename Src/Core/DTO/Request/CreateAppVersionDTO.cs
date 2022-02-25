using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Request
{
    public class CreateAppVersionDTO
    {
        public int IdApp { get; set; }
        public string AppVersion1 { get; set; } = null!;
        public string UrlDescarga { get; set; } = null!;
        public DateTime? FechaPublicacion { get; set; }
    }
}
