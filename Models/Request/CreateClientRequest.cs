using FastEndpoints;
using FluentValidation;

namespace API_4BIO.Models.Request
{
    public class CreateClientRequest
    {
        [FromBody]
        public Client Client { get; set; }
    }

}
