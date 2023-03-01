using API_4BIO.Data.Interfaces;
using API_4BIO.Models.Request;
using API_4BIO.Models.Response;

namespace API_4BIO.Endpoints
{
    
    public class DeleteClient : FastEndpoints.Endpoint<DeleteClientRequest, DeleteClientResponse>
    {
        IClientManager _clientManager;
        public DeleteClient(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        public override void Configure()
        {
            Delete("/clientes/remover/{ClientId}");
            AllowAnonymous();

        }

        public override async Task HandleAsync(DeleteClientRequest req, CancellationToken ct)
        {
            if(await _clientManager.DeleteClientAsync(req.ClientId, ct))
            {
                var response = new DeleteClientResponse()
                {
                    Message = $"Cliente {req.ClientId} removido com sucesso!" 
                };

                await SendAsync(response, statusCode: StatusCodes.Status200OK, ct);
            };
        }
    }
}
