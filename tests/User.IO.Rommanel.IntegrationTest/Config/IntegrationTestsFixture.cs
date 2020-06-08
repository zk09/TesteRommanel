using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using User.IO.Rommanel.API;
using User.IO.Rommanel.Application.ViewModels;
using Xunit;

namespace User.IO.Rommanel.IntegrationTest.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>> { }
    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly UserAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(GetBaseUrl()),
            };

            Factory = new UserAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);

        }

        private string GetBaseUrl()
        {
            return "https://localhost:44369/";
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }


        public Guid IdUser { get; set; } = Guid.Parse("2A1C85AB-91D3-4E51-E078-08D80A89D716"); // Definir id aqui para rodar teste individual
        public UserViewModel GenerateNewUserValid()
        {
            var user = new Faker<UserViewModel>(locale: "pt_BR");
            user.RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
                .RuleFor(c => c.Cpf, (f, c) => "15964076033")
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name))
                .RuleFor(c => c.DateBirth, (f, c) => f.Person.DateOfBirth.Date)
                .RuleFor(c => c.City, (f, c) => f.Address.City())
                .RuleFor(c => c.ZipCode, (f, c) => f.Address.ZipCode())
                .RuleFor(c => c.State, (f, c) => f.Address.State());


            return user;
        }

        public UserViewModel GenerateUpdateUserValid()
        {
            var user = new Faker<UserViewModel>(locale: "pt_BR");
            user.RuleFor(c => c.Name, (f, c) => f.Name.FirstName())
                .RuleFor(c=> c.Id,(f,c)=> IdUser)
                .RuleFor(c => c.Cpf, (f, c) => "15964076033")
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name))
                .RuleFor(c => c.DateBirth, (f, c) => f.Person.DateOfBirth.Date)
                .RuleFor(c => c.City, (f, c) => f.Address.City())
                .RuleFor(c => c.ZipCode, (f, c) => f.Address.ZipCode())
                .RuleFor(c => c.State, (f, c) => f.Address.State());

            return user;
        }

    }

}
