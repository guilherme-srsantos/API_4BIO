using API_4BIO.Data.Interfaces;
using API_4BIO.Models.Request;
using API_4BIO.Models.Response;

namespace API_4BIO.Endpoints
{
    public class GenerateMockData : FastEndpoints.Endpoint<GenerateMockDataRequest, GenerateMockDataResponse>
    {
        IDataMocker _mocker;
        IClientManager _clientManager;
        public GenerateMockData(IDataMocker mocker, IClientManager clientManager)
        {
            _mocker = mocker;
            _clientManager = clientManager;

        }
        public override void Configure()
        {
            Get("/clientes/gerarclientes/{numberofclients}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GenerateMockDataRequest req, CancellationToken ct)
        {
            var mockedClients = _mocker.GenerateMockClients(req.NumberOfClients);
            var addedClients = await _clientManager.AddMultipleClientsAsync(mockedClients, ct);

            var response = new GenerateMockDataResponse()
            {
                NewClients = addedClients,
                Message = $"{addedClients.Count} clientes adicionados com sucesso!"

            };
            await SendAsync(response, statusCode: StatusCodes.Status201Created, ct);

        }
    }
}
