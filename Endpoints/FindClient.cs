using API_4BIO.Data.Interfaces;
using API_4BIO.Models.Request;
using API_4BIO.Models.Response;

namespace API_4BIO.Endpoints
{
    public class FindClient : FastEndpoints.Endpoint<FindClientRequest, FindClientResponse>
    {
        IClientManager _clientManager;

        public FindClient(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        public override void Configure()
        {
            Post("/clientes/listar");
            DontCatchExceptions();
            AllowAnonymous();
        }

        public override async Task HandleAsync(FindClientRequest req, CancellationToken ct)
        {
            var clients = await _clientManager.FindClientAsync(req?.Filter, ct);

            if (clients.Count < 1) 
            {
                await SendNotFoundAsync(ct);
            }
            else
            {
                var response = new FindClientResponse
                {
                    Results = clients
                };

                await SendOkAsync(response);
            }
           
            
        }

       
    }
}
