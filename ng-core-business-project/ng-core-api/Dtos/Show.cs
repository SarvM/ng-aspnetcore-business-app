using System;

namespace ng_core_api.Dtos
{
    public class Show
    {
        public Guid ShowId { get; set;}
        public DateTimeOffset Date { get; set;}
        public string Venue { get; set;}
        public string City { get; set;}
        public string Country { get; set;}
    }
}