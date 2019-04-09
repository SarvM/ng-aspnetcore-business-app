using System;

namespace ng_core_api.Entities
{
    public class Band : AuditableEntity
    {
        public Guid BandId { get; set;}
        public string Name {get; set;}
    }
}