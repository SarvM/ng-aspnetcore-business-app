using System;

namespace ng_core_api.Entities
{
    public class Show : AuditableEntity
    {
        public Guid ShowId { get; set;}
        public DateTimeOffset Date { get; set;}
        public string Venue { get; set;}
        public string City { get; set;}
        public string Country { get; set;}
        public Guid TourId { get; set;}
        public Tour Tour { get; set;}

    }
}