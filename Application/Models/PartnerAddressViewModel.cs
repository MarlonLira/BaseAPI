using System;

namespace Application.Models
{
    public class PartnerAddressViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Complement { get; set; }
        public int PartnerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
