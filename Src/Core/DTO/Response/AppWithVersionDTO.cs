using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Response
{
    public class AppWithVersionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string AppVersion1 { get; set; } = null!;
        public string UrlDescarga { get; set; } = null!;
        public DateTime? FechaPublicacion { get; set; }
    }
}
