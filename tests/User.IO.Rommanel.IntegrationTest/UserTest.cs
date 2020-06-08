using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using User.IO.Rommanel.API;
using User.IO.Rommanel.API.ResultSet;
using User.IO.Rommanel.Application.ViewModels;
using User.IO.Rommanel.IntegrationTest.Config;
using Xunit;

namespace User.IO.Rommanel.IntegrationTest
{
    [TestCaseOrderer("User.IO.Rommanel.IntegrationTest.Config.PriorityOrderer", "User.IO.Rommanel.IntegrationTest")]
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class UserTest
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public UserTest(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Adicionar usuário com sucesso"), TestPriority(1)]
        [Trait("Usuario", "Integração Api v1 - Usuario")]
        public async Task User_RegisterNewUser_Sucess()
        {
            //Arrange
            var url = $"User/RegisterNewUser";
            var userViewModel = _testsFixture.GenerateNewUserValid();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            var postRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            // Assert
            postResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<List<MethodResult>>(await postResponse.Content.ReadAsStringAsync());
            var isOk = Convert.ToBoolean(result.FirstOrDefault().Key);
            Assert.True(isOk);
        }

        [Fact(DisplayName = "Alterar usuário com sucesso"), TestPriority(4)]
        [Trait("Usuario", "Integração Api v1 - Usuario")]
        public async Task User_UpdateUser_Sucess()
        {
            //Arrange
            var url = $"User/UpdateUser";
            var userViewModel = _testsFixture.GenerateUpdateUserValid();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            var postRequest = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = content
            };

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            // Assert
            postResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<List<MethodResult>>(await postResponse.Content.ReadAsStringAsync());
            var isOk = Convert.ToBoolean(result.FirstOrDefault().Key);
            Assert.True(isOk);
        }

        [Fact(DisplayName = "Deletar usuário com sucesso"), TestPriority(5)]
        [Trait("Usuario", "Integração Api v1 - Usuario")]
        public async Task User_DeleteUser_Sucess()
        {
            //Arrange
            var url = $"User/DeleteUser/{_testsFixture.IdUser}";
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, url);

            // Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            // Assert
            postResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<List<MethodResult>>(await postResponse.Content.ReadAsStringAsync());
            var isOk = Convert.ToBoolean(result.FirstOrDefault().Key);
            Assert.True(isOk);
        }

        [Fact(DisplayName = "Buscar todos os usuarios com sucesso"), TestPriority(2)]
        [Trait("Usuario", "Integração Api v1 - Usuario")]
        public async Task User_GetAll_Sucess()
        {
            //Arrange
            var url = $"User/GetAllUser";
            var getRequest = new HttpRequestMessage(HttpMethod.Get, url);

            // Act
            var getResponse = await _testsFixture.Client.SendAsync(getRequest);

            // Assert
            getResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(await getResponse.Content.ReadAsStringAsync()).ToList();
            _testsFixture.IdUser = result.FirstOrDefault().Id;
            Assert.NotEmpty(result);
        }

        [Fact(DisplayName = "Buscar usuario por id com sucesso"), TestPriority(3)]
        [Trait("Usuario", "Integração Api v1 - Usuario")]
        public async Task User_GetById_Sucess()
        {
            //Arrange
            var url = $"User/GetUser/{_testsFixture.IdUser}";
            var getRequest = new HttpRequestMessage(HttpMethod.Get, url);

            // Act
            var getResponse = await _testsFixture.Client.SendAsync(getRequest);

            // Assert
            getResponse.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<UserViewModel>(await getResponse.Content.ReadAsStringAsync()); ;
            Assert.NotNull(result);
        }

    }
}
