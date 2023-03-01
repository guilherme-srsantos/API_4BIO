using API_4BIO.Data.Interfaces;
using API_4BIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API_4BIO.Data
{
    public class ClientManager : IClientManager
    {
        private ApplicationDB _dbContext;
        public ClientManager(ApplicationDB context)
        {
            _dbContext = context;
        }

        public async Task<List<Guid>> ImportDataFromJsonAsync(IFormFile file, CancellationToken ct)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var json = await reader.ReadToEndAsync();

            var jsonClients = JsonConvert.DeserializeObject<List<Client>>(json);

            await _dbContext.Clients.AddRangeAsync(jsonClients);
            await _dbContext.SaveChangesAsync(ct);

            return jsonClients.Select(c => c.ClientId).ToList();

        }

        public async Task<bool> DeleteClientAsync(string clientId, CancellationToken ct)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId.ToString() == clientId, ct);
            if (client is null) return false;
            _dbContext.Remove(client);
            if (await _dbContext.SaveChangesAsync(ct) > 0) return true;
            return false;
        }

        public async Task<Client> CreateClientAsync(Client client, CancellationToken ct)
        {
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync(ct);
            return client;
        }

        public async Task<Client?> UpdateClientAsync(Client request, CancellationToken ct)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == request.ClientId) ?? throw new Exception("Cliente não encontrado!");
            _dbContext.Update(request);
            if (await _dbContext.SaveChangesAsync(ct) > 0) return request;
            return null;

        }

        public async Task<List<Client>> FindClientAsync(Filter filter, CancellationToken ct)
        {
            List<Client> clients = new();
            var query = _dbContext.Clients.AsQueryable();
            switch (filter.FilterType)
            {
                case FilterType.Name:
                    query = query
                        .Include(c => c.Address)
                        .Include(c => c.ContactInfo)
                        .Where(c => c.FullName
                        .Contains(filter.FilterValue));
                    clients = await query.ToListAsync(ct);
                    break;

                case FilterType.CPF:
                    query = query
                        .Include(c => c.Address)
                        .Include(c => c.ContactInfo)
                        .Where(c => c.CPF == filter.FilterValue);
                    clients = await query.ToListAsync(ct);
                    break;

                case FilterType.Email:
                    query = query
                            .Include(c => c.Address)
                            .Include(c => c.ContactInfo)
                            .Where(c => c.ContactInfo.Email == filter.FilterValue);
                    clients = await query.ToListAsync(ct);
                    break;

                default:
                    clients = await query
                        .Include(c => c.Address)
                        .Include(c => c.ContactInfo)
                        .ToListAsync(ct);
                    break;
            }
            return clients;

        }

        public async Task<List<Client>> AddMultipleClientsAsync(List<Client> clients, CancellationToken ct)
        {
            await _dbContext.Clients.AddRangeAsync(clients, ct);
            await _dbContext.SaveChangesAsync(ct);

            return clients;

        }



    }
}
