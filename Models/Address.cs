using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_4BIO.Models
{
    public class Address
    {
        [Key]
        public Guid ClientId { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string? Complement { get; set; }
        public string? Reference { get; set; }
        public string StreetName { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; } 

    }
}
