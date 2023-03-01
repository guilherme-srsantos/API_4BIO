using FastEndpoints;

namespace API_4BIO.Models.Request
{
    public class EditClientRequest
    {
        [FromBody]
        public Client Client { get; set; }
    }
}
