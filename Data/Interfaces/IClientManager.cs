using API_4BIO.Models;

namespace API_4BIO.Data.Interfaces
{
    public interface IClientManager
    {
        Task<List<Client>> AddMultipleClientsAsync(List<Client> clients, CancellationToken ct);
        Task<Client> CreateClientAsync(Client client, CancellationToken ct);
        Task<bool> DeleteClientAsync(string clientId, CancellationToken ct);
        Task<List<Client>> FindClientAsync(Filter filter, CancellationToken ct);
        Task<List<Guid>> ImportDataFromJsonAsync(IFormFile file, CancellationToken ct);
        Task<Client?> UpdateClientAsync(Client client, CancellationToken ct);
    }
}