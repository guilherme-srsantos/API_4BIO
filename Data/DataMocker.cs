using API_4BIO.Data.Interfaces;
using API_4BIO.Models;
using Bogus;
using Bogus.Extensions.Brazil;


namespace API_4BIO.Data
{
    public class DataMocker : IDataMocker
    {
        private readonly Faker<Client> _clientFaker;



        public DataMocker()
        {


            _clientFaker = new Faker<Client>("pt_BR")
                .StrictMode(false)
                .RuleFor(c => c.ClientId, f => f.Random.Guid())
                .RuleFor(c => c.FullName, f => f.Name.FullName())
                .RuleFor(c => c.CPF, f => f.Person.Cpf())
                .RuleFor(c => c.RG, f => f.Person.Rg())
                .RuleFor(c => c.ContactInfo, (_, c) =>
                {
                    return CreateMockContactInfo(c.ClientId);
                })
                .RuleFor(c => c.Address, (_, c) =>
                {
                    return CreateMockAddress(c.ClientId);
                });
        }

        public List<Client> GenerateMockClients(int amount)
        {
            return _clientFaker.Generate(amount);
        }

        private Address CreateMockAddress(Guid fk)
        {
            return  new Faker<Address>("pt_BR")
                .RuleFor(c => c.PostalCode, f => f.Address.ZipCode())
                .RuleFor(c => c.Neighborhood, f => f.Address.County())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.Number, f => f.Address.BuildingNumber())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Complement, f => f.Address.SecondaryAddress())
                .RuleFor(c => c.Reference, f => f.Address.Random.Word())
                .RuleFor(c => c.StreetName, f => f.Address.StreetName())
                .RuleFor(c => c.State, f => f.Address.State())
                .RuleFor(c => c.ClientId, fk); 
        }

        private ContactInfo CreateMockContactInfo(Guid fk)
        {
            return new Faker<ContactInfo>("pt_BR")
                .StrictMode(false)
                .RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
                .RuleFor(c => c.PhoneNumber, f => f.Person.Phone)
                .RuleFor(c => c.AreaCode, f => f.Random.Int(11, 99))
                .RuleFor(c => c.ClientId, fk);
        }

    }
}
