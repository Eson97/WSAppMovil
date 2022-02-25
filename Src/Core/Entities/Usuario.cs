using Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Usuario : EntityBase<int>
    {
        public Usuario()
        {
            DescargaUsuarios = new HashSet<Descarga>();
        }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Descarga> DescargaUsuarios { get; set; }
    }
}
