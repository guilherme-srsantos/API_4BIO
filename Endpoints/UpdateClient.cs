using API_4BIO.BusinessLogic.Validators;
using API_4BIO.Data.Interfaces;
using API_4BIO.Models.Request;
using API_4BIO.Models.Response;

namespace API_4BIO.Endpoints
{
    public class UpdateClient : FastEndpoints.Endpoint<UpdateClientRequest>
    {
        IClientManager _clientManager;
        public UpdateClient(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        public override void Configure()
        {
            Put("/clientes/atualizar");
            AllowAnonymous();
            Validator<UpdateClientValidator>();
        }

        public override async Task HandleAsync(UpdateClientRequest req, CancellationToken ct)
        {
            if(await _clientManager.UpdateClientAsync(req.Client, ct) is not null)
            {
                var response = new UpdateClientResponse
                {
                    Message = "Cliente atualizado com sucesso"
                };
                 await SendAsync(response, statusCode:StatusCodes.Status200OK, ct);
            }
            else
            {
                var response = new UpdateClientResponse
                {
                    Message = "Não foi possível atualizar o cliente específicado na requisição."
                };
                await SendAsync(response, statusCode: StatusCodes.Status500InternalServerError, ct);
            };

        }
    }
}
 