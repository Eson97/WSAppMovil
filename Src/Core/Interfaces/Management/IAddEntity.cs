using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Management
{
    public interface IAddEntity<TKey>
    {
        TKey Id { get; }

        //en caso de contar con mas datos en comun, se agregarian aqui
    }
}
