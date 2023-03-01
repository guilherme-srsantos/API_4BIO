using API_4BIO.Models;

namespace API_4BIO.Data.Interfaces
{
    public interface IDataMocker
    {
        List<Client> GenerateMockClients(int amount);
    }
}