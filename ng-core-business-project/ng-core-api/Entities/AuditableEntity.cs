using System;

namespace ng_core_api.Entities
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public string UpdatedBy { get; set;}
        public DateTime UpdatedOn { get; set;}
    }
}