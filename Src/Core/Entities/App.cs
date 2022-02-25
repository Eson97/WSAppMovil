using Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class App :EntityBase<int>
    {
        public App()
        {
            AppVersions = new HashSet<AppVersion>();
        }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<AppVersion> AppVersions { get; set; }
    }
}
