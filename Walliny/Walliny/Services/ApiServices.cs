using Ideas.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Walliny.Helpers;
using Walliny.Models;

namespace Walliny.Services
{
    class ApiServices
    {
        public async Task<bool> RegisterAsync(string firstname, string lastname, string cellphone, string username, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel()
            {
                Firstname = firstname,
                Lastname = lastname,
                Cellphone = cellphone,
                Username = username,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseApiAddress + "create.php?APIkeyID=a9c0c8e9a7c2c1f9c4fca82d57510d63", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var KeyValues = new List<KeyValuePair<string, string>>
            {
            new KeyValuePair<string, string>("Username", userName),
            new KeyValuePair<string, string>("Password", password),
            new KeyValuePair<string, string>("grant_type", "Password")
            };

            string json = JsonConvert.SerializeObject(KeyValues);


            var request = new HttpRequestMessage(
            HttpMethod.Post, "http://walliny.azurewebsites.net/app3/webservice/v3/token.php");

            request.Content = new FormUrlEncodedContent(KeyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            // var accessTokenExpiration = jwtDynamic.Value<DateTime>("expires");
            var Username = jwtDynamic.Value<string>("userName");
            var accessToken = jwtDynamic.Value<string>("access_Token");

            Settings.Username = Username;

            //Settings.Username= accessTokenExpiration;

            // Debug.WriteLine(accessTokenExpiration);

            Debug.WriteLine(jwt);


            return accessToken;


        }
        public async Task<List<Service>> GetServicesAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "ideas.php");

            var services = JsonConvert.DeserializeObject<List<Service>>(json);

            return services;
        }

        public async Task PutServiceAsync(Service service, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(service);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new
                MediaTypeHeaderValue("application/json");

            //var response = await client.PutAsync(
            //  "http://apps-carpejani.rhcloud.com/app3/webservice/v2/ideas.php" + idea.Id, content);

            var response = await client.PutAsync(
               Constants.BaseApiAddress + "ideas.php", content);
        }

        public async Task DeleteIdeaAsync(int id, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync(
                "http://apps-carpejani.rhcloud.com/app3/webservice/v3/ideas.php/" + id);
        }

        public async Task<List<Idea>> SearchIdeasAsync(string keyword, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync
                (Constants.BaseApiAddress + "ideasSearch.php/" + keyword);

            var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

            return ideas;
        }

        //###OfferServicesAsync

        public async Task<List<OfferServices>> OfferServicesAsync(string Id_Services, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync
                (Constants.BaseApiAddress + "requestservice.php/" + Id_Services);

            var OfferServices = JsonConvert.DeserializeObject<List<OfferServices>>(json);


            return OfferServices;
        }

        public async Task<string> PostRequestServiceAsync(Request request, string accessToken)
        {
            // public async Task<List<OfferServices>> PostRequestServiceAsync(Request request, string accessToken)
            //  {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var service = await client.PostAsync(Constants.BaseApiAddress + "ideas.php", content);

            //#### Retorna ofertas
            //var offerServices = JsonConvert.DeserializeObject<List<OfferServices>>(json);

            //return offerServices;
            //return response.IsSuccessStatusCode;

            // var jwt = await response.Content.ReadAsStringAsync();

            var Id_Services = await service.Content.ReadAsStringAsync();

            //JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(Id_Services);


            Id_Services = "24";
            return Id_Services;
        }

        public async Task PutServiceConfirmAsync(RequestService requestService, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(requestService);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                Constants.BaseApiAddress + "api/Ideas/" + requestService.Id_tb_tipo_services, content);

        }

        
    }
}
