using RMSDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RMSDesktopUI.Helper
{
    public class APIHelper : IAPIHelper
    {
        public HttpClient ApiClient { get; set; }

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            ApiClient = new HttpClient();
            string apiBaseAddress = ConfigurationManager.AppSettings["api"];
            ApiClient.BaseAddress = new Uri(apiBaseAddress);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser>  Authenticate(string userName, string password)
        {

            var data = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",userName),
                new KeyValuePair<string,string>("password",password)
            });

            using (HttpResponseMessage responseMessage = await ApiClient.PostAsync("/token", data))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<AuthenticatedUser>();
                    return result; 
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    } 
}
