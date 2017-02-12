using BlackJackDudekGueguen.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace BlackJackDudekGueguen.ViewModel
{
    public class SignInViewModel
    {
        public string UserEmail
        {
            get { return this.UserEmail; }
            set
            {
                this.UserEmail = value;

            }
        }
        public string Userpwd
        {
            get { return this.Userpwd; }
            set
            {
                this.Userpwd = value;

            }
        }
        //https://msdn.microsoft.com/library/windows/apps/br241511
        public string HashMD5(string pwd) {
            String strAlgName = HashAlgorithmNames.Sha512;;
            String strEncodedHash = this.SampleHashMsg(strAlgName, pwd);
            return pwd;
        }

        public String SampleHashMsg(String strAlgName, String pwd)
        {
            // conversion string en données binaires
            IBuffer buffUtf8Msg = CryptographicBuffer.ConvertStringToBinary(pwd, BinaryStringEncoding.Utf8);

            // nouvel objet d'hashage
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);
            String strAlgNameUsed = objAlgProv.AlgorithmName;

            // hashage.
            IBuffer buffHash = objAlgProv.HashData(buffUtf8Msg);

            // vérification de la longueur du hashage.
            if (buffHash.Length != objAlgProv.HashLength)
            {
                throw new Exception("There was an error creating the hash");
            }

            // conversion en base64
            String strHashBase64 = CryptographicBuffer.EncodeToBase64String(buffHash);
            return strHashBase64;
        }
        public SignInViewModel()
        {
            User User = new User();
            User.Email = this.UserEmail;
            User.Password = this.Userpwd;
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
