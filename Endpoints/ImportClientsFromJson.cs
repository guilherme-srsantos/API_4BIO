using API_4BIO.Data.Interfaces;
using API_4BIO.Models.Request;
using API_4BIO.Models.Response;

namespace API_4BIO.Endpoints
{
    public class ImportClientsFromJson : FastEndpoints.Endpoint<FileImportRequest, FileImportResponse>
    {
        IClientManager _clientManager;

        public ImportClientsFromJson(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        public override void Configure()
        {
            Post("/clientes/importar");
            AllowAnonymous();
            AllowFileUploads();
        }

        public override async Task HandleAsync(FileImportRequest req, CancellationToken ct)
        {
            var addedIds = await _clientManager.ImportDataFromJsonAsync(req.JsonFile, ct);

            var response = new FileImportResponse
            {
                ImportedClients = addedIds
            };

            await SendAsync(response, statusCode: StatusCodes.Status201Created, ct);
            

        }
    }
}
