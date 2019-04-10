using System;

namespace ng_core_api.Entities
{
    public class Manager : AuditableEntity
    {
        public Guid ManagerId { get; set;}
        public string Name { get; set;}
    }
}