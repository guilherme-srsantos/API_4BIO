using FastEndpoints;

namespace API_4BIO.Models.Request
{
    public class FindClientRequest
    {
      [FromBody]
      public Filter? Filter { get; set; } 
    }
}
