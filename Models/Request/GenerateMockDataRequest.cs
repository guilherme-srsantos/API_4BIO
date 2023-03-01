using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace API_4BIO.Models.Request
{
    public class GenerateMockDataRequest
    {
        public int NumberOfClients { get; set; }
    }
}
