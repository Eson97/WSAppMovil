using Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class AppVersion : EntityBase<int>
    {
        public AppVersion()
        {
            DescargaUsuarios = new HashSet<Descarga>();
        }

        public int IdApp { get; set; }
        public string AppVersion1 { get; set; } = null!;
        public string UrlDescarga { get; set; } = null!;
        public DateTime? FechaPublicacion { get; set; }

        public virtual App IdAppNavigation { get; set; } = null!;
        public virtual ICollection<Descarga> DescargaUsuarios { get; set; }
    }
}
