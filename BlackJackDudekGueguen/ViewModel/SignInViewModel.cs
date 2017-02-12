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
    class SignInViewModel
    {
        public User User { get; set; }
        //affectation des valeurs au model User
        public string UserEmail
        {
            get { return UserEmail; }
            set
            {
                this.UserEmail = value;

            }
        }
        public string Userpwd
        {
            get { return Userpwd; }
            set
            {
                this.Userpwd = value;

            }
        }

        //https://msdn.microsoft.com/library/windows/apps/br241511
        //le hashage en md5 est la seule chose qu'on a pas vu en cours, 
        //du coup on s'est permis de copié le code depuis internet
        //
        public string HashMD5(string pwd) {
            String strAlgName = HashAlgorithmNames.Md5;;
            String strEncodedHash = this.SampleHashMsg(strAlgName, pwd);
            return strEncodedHash;
        }

        public String SampleHashMsg(String strAlgName, String pwd)
        {

            // conversion string en données binaires
            IBuffer IBuff = CryptographicBuffer.ConvertStringToBinary(pwd, BinaryStringEncoding.Utf8);

            // nouvel objet d'hashage
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);
            String strAlgNameUsed = objAlgProv.AlgorithmName;

            // hashage.
            IBuffer buffHash = objAlgProv.HashData(IBuff);

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
            //nouvel utilisateur
            User User = new User();
            User.Email = this.UserEmail;
            User.Password = this.Userpwd;
            User.Secret = HashMD5(User.Password);
            string json = JsonConvert.SerializeObject(User);
            postMethod("/api/auth/register", json);
        }
        public async void postMethod(string url, string jsonString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://demo.comte.re/");
                /* On met le string du futur json
                 * jsonString -> le user lors de l'inscription, la table choisi 
                 */
                var json = JsonConvert.SerializeObject(jsonString);
                var itemJson = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, itemJson);
                if (response.IsSuccessStatusCode)
                {
                }
            }
        }
    }
}
