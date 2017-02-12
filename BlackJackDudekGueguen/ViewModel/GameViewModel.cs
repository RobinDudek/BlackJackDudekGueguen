using BlackJackDudekGueguen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.ViewModel
{
    class GameViewModel
    {
        public User Bank { get; set; }
        public User Player { get; set; }

        public GameViewModel()
        {
            this.Bank = new User();
            this.Player = new User();
        }



        public void Split()
        {

        }

        //Se fait à la fin d'un tour
        public async void UpdateStack(Double earnings)
        {
            string apiUrl = "user/" + Player.Email + "/stack/" + earnings;
            using (var client = new HttpClient())
            {
                //send the new stack to api in GET
                client.BaseAddress = new Uri("http://demo.comte.re/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string res = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }


}
