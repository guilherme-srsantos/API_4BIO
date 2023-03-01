using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_4BIO.Models
{
    public class ContactInfo
    {
        [Key]
        public Guid ClientId { get; set; }
        public string Email { get; set; }
        public int AreaCode { get; set; }   
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }  
    }
}
