using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Model
{
    class Api
    {
        public User ConnectedUser { get; set; }
        public Token UserToken { get; set; }

        public Api(string url, string method)
        {
            if(method == "GET")
            {
                getMethod(url);
            }
            else{
                //Console.WriteLine("On a chié dans la méthode, revérifie que t'a écris correctement GET avec les maj dans ton appel de l'API ");
            }

        }
        public Api(string url, string method, string jsonString)
        {
            if (method == "POST")
            {
                postMethod(url, jsonString);
            }
            else
            {
                //Console.WriteLine("On a chié dans la méthode, revérifie que t'a écris correctement POST avec les maj dans ton appel de l'API ");
            }
        }

        public async void getMethod(string url)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://demo.comte.re/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async void postMethod(string url, string jsonString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://demo.comte.re/");
                /* On met le string du futur json
                 * jsonString -> le user lors de l'inscription, la table choisi 
                 */
                var json = JsonConvert.SerializeObject(jsonString );
                var itemJson = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, itemJson);
                if (response.IsSuccessStatusCode)
                {
                }
            }
        }


    }


}

