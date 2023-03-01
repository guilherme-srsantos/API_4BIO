using API_4BIO.BusinessLogic.Validators;
using API_4BIO.Data.Interfaces;
using API_4BIO.Documentation;
using API_4BIO.Models.Request;
using API_4BIO.Models.Response;

namespace API_4BIO.Endpoints
{
    public class AddClient : FastEndpoints.Endpoint<CreateClientRequest, CreateClientResponse>
    {
        IClientManager _clientManager { get; set; }

        public AddClient(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        public override void Configure()
        {
            Post("/clientes/criar");
            AllowAnonymous();
            Validator<CreateClientValidator>();
        }

        public override async Task HandleAsync(CreateClientRequest req, CancellationToken ct)
        {
            var newClient = await _clientManager.CreateClientAsync(req.Client, ct);

            var response = new CreateClientResponse()
            {
                ClientId = newClient.ClientId,
                Message = "Cliente criado com sucesso!"
            };

            await SendAsync(response, statusCode: StatusCodes.Status201Created, ct);
        }
    }
}
