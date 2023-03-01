using API_4BIO.Endpoints;
using FastEndpoints;

namespace API_4BIO.Documentation
{
    public class SummaryImportFromJson : Summary<ImportClientsFromJson>
    {
        public SummaryImportFromJson()
        {
            Summary = "Endpoint para importar vários usuários através de um arquivo .json";
            Description = @"Recebe um arquivo .json através de um POST e retorna os IDs dos clientes que foram adicionados";
            Responses[201] = "Indica que os usuários descritos no arquivo foram criados no sistema com sucesso";
            Responses[400] = "Indica que houve algum erro durante a validação dos clientes que foram especificados no arquivo";
        }
    }
}
