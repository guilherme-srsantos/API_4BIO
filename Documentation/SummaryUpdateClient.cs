using API_4BIO.Endpoints;
using FastEndpoints;

namespace API_4BIO.Documentation
{
    public class SummaryUpdateClient : Summary<UpdateClient>
    {
        public SummaryUpdateClient()
        {
            Summary = "Endpoint para editar um cliente";
            Description = @"Recebe um objeto de cliente que possui obrigatoriamente um ID gerado pelo sistema e retorna o mesmo cliente caso a edição tenha sido bem sucedida";
            Responses[200] = "Indica que o cliente foi editado com sucesso.";
            Responses[400] = "Indica que houve algum erro durante a validação dos dados do cliente durante o processo de edição.";
        }
    }
}
