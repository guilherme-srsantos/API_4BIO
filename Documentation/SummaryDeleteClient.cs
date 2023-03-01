using API_4BIO.Endpoints;
using FastEndpoints;

namespace API_4BIO.Documentation
{
    public class SummaryDeleteClient : Summary<DeleteClient>
    {
        public SummaryDeleteClient()
        {
            Summary = "Endpoint para remover um cliente";
            Description = "Recebe um DELETE com o ID do cliente que se deseja excluir do sistema";
            Responses[200] = "Indica que o cliente foi adicionado com sucesso";
            Responses[500] = "Indica que houve um problema ao remover o cliente";

        }
    }
}
