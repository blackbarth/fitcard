using FitCard.API;
using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.DTOs.User;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace FitCard.Testes
{
    public class UserTesteController : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;
        private string _token;
        private string _controller = "user";
        private string _email = "blackbarth@outlook.com";

        private string token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
            }
        }


        [Fact]
        public async Task GetAll_Ok_Result()
        {
            // Arrange
            if (token == null)
                await GetToken();
            var request = $"/api/{_controller}";
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Client.GetAsync(request);


            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Post_Ok_Result()
        {
            // Arrange
            if (token == null)
                await GetToken();


            var request = new
            {
                Url = $"/api/{_controller}",
                Body = new
                {
                    categoriaNome = ($"Categoria {Guid.NewGuid().ToString()}").Substring(0, 40)

                }
            };


            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<CategoriaDTO>(jsonFromPostResponse);


            // Assert

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);



        }

        [Theory]
        [InlineData(14, "Novo texto")]
        public async Task Put_Ok_Result(int id, string txt)
        {
            // Arrange
            if (token == null)
                await GetToken();

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new
            {
                Url = $"/api/{_controller}",
                Body = new
                {
                    id = id,
                    categoriaNome = $"{txt}"
                }
            };

            //Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));


            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


        }

        [Theory]
        [InlineData(10)]
        public async Task GetById_Ok_Result(int id)
        {
            // Arrange
            if (token == null)
                await GetToken();
            var request = $"/api/{_controller}/{id}";
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Client.GetAsync(request);


            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Theory]
        [InlineData(13)]
        public async Task Delete_Ok_Result(int id)
        {
            // Arrange
            if (token == null)
                await GetToken();
            var request = $"/api/{_controller}/{id}";
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Client.DeleteAsync(request);


            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        public UserTesteController(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        public async Task GetToken()
        {
            var request = new
            {
                Url = "/api/login",
                Body = new
                {
                    email = _email
                }
            };

            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();


            var singleResponse = JsonConvert.DeserializeObject<Token>(jsonFromPostResponse);
            token = singleResponse.accessToken;

        }
    }
}