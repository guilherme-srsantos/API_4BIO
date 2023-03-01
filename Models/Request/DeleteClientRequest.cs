using FastEndpoints;

namespace API_4BIO.Models.Request
{
    public class DeleteClientRequest
    {
        [FromQueryParams]
        public string ClientId { get; set; }
    }
}
