using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_4BIO.Models
{
    public class Client
    {
        [Key]
        public Guid ClientId { get; set; }
        public string FullName { get; set; }  
        public string CPF { get; set; }
        public string RG { get; set; }
        public virtual Address Address { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }



    }
}
