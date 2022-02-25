using Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Descarga : EntityBase<int>
    {
        public int IdAppVersion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaDescarga { get; set; }

        public virtual AppVersion IdAppVersionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
