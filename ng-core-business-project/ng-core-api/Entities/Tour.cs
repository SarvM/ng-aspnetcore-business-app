using System;

namespace ng_core_api.Entities
{
    public class Tour : AuditableEntity
    {
        public Guid TourId { get; set;}
        public string Title { get; set;}
        public string Description { get; set;}
        public decimal EstimatedProfits { get; set;}
        public DateTimeOffset StartDate { get; set;}
        public DateTimeOffset EndDate { get; set;}
        public Guid BandId { get; set;}
        public Band Band { get; set;}
        public Guid ManagerId { get; set;}
        public Manager Manager { get; set;}
         
    }
}