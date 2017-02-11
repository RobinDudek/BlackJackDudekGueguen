using BlackJackDudekGueguen.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;

namespace BlackJackDudekGueguen.ViewModel
{
    public class SignInViewModel
    {
        public string HashMD5(string pwd) {
            MD5 mHash = new MD5CryptoServiceProvider();
            byte[] MD5B = mHash.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            string result = Convert.ToBase64String(MD5B);
            return pwd;
        }

        public SignInViewModel()
        {
            User User = new User();
            User.Username = this.Username;
            User.Password = this.Password;
            User.Password = HashMD5(User.Password);
            string json = JsonConvert.SerializeObject(User);
            getMethod(json);
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
    }
}
