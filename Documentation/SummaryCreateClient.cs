using API_4BIO.Endpoints;
using API_4BIO.Models.Request;
using FastEndpoints;

namespace API_4BIO.Documentation
{
    public class SummaryCreateClient : Summary<AddClient>
    {
        public SummaryCreateClient()
        {
            Summary = "Endpoint para criação de cliente";
            Description = "Recebe um POST com um objeto JSON representando o cliente que deve ser criado";
            Responses[201] = "Indica que o cliente foi adicionado com sucesso";
            Responses[400] = "Indica que houve um problema no processamento do objeto enviado";
            
        }
    }
}
