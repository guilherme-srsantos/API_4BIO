using API_4BIO.Endpoints;
using FastEndpoints;

namespace API_4BIO.Documentation
{
    public class SummaryFindClient : Summary<FindClient>
    {
        public SummaryFindClient()
        {
            Summary = "Endpoint para buscar clientes";
            Description = @"Recebe um objeto de filtro contendo o campo que será buscado ao pesquisar por um cliente, caso o objeto de filtro não seja especificado,
                            ou um filtro inválido seja especificado a busca irá listar todos os clientes do sistema.
            Valor de 0 a 4 que indica busca por:
            0 - ID do cliente (chave primária)
            1 - Nome
            2 - CPF
            3 - Email";
            Responses[200] = "Indica que a busca retornou ao menos um resultado para os critérios definidos nos filtros.";
            Responses[404] = "Indica que não foram encontrados clientes baseados nos critérios especificados.";
            
        }
    }
}
