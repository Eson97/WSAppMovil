using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; set; }
        public object Id { get; set; }

        public EntityNotFoundException():base(){}
        public EntityNotFoundException(Type entityType) : this(entityType, null, null) { }
        public EntityNotFoundException(Type entityType,object id): this(entityType, id, null) { }
        public EntityNotFoundException(Type entityType,object id, Exception innerException):base(
            id==null
            ? $"No existe la entidad. Entity type: {entityType.FullName}"
            : $"No existe la entidad. Entity type: {entityType.FullName}, id: {id}", innerException) 
        { 
            EntityType = entityType; Id = id;
        }

        public EntityNotFoundException(string message) : base(message) { }
    }
}
