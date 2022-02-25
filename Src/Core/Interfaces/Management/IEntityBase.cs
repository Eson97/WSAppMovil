using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Management
{
    public interface IEntityBase<TKey> : IAddEntity<TKey> //update y delete no son requeridas en esta ocasion 
    {
    }
}
