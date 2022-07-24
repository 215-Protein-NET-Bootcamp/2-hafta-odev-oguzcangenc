using EmployeeTracking.Data.Models;
using EmployeeTracking.Test.Context;
using EmployeeTracking.WebAPI;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;

namespace EmployeeTracking.Test
{
    public class FoldersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> factory;

        public FoldersControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_All_Folders()
        {
            var client = factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/folder");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_By_Id_Folder()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("/api/folder/2");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Post_New_Folder()
        {

            Folder newFolder = new()
            {

                AccessType = "Test Access Type",
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,

            };

            var client = factory.CreateClient();
            var json = JsonSerializer.Serialize(newFolder);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("/api/folder", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Put_New_Folder()
        {
            Folder putFolder = new()
            {
                Id = 1,
                AccessType = "Test Folder Update",
            };

            var client = factory.CreateClient();
            var json = JsonSerializer.Serialize(putFolder);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync($"/api/folder/{putFolder.Id}", content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Remove_By_Id_Folder()
        {
            var client = factory.CreateClient();
            var response = await client.DeleteAsync("/api/folder/1");
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }    
}
