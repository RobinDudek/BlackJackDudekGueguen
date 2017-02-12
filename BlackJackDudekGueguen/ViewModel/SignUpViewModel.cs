using BlackJackDudekGueguen.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace BlackJackDudekGueguen.ViewModels
{
    class SignUpViewModel
    {
        public User User { get; set; }
        //affectation des valeurs au model SignUp
        public string Firstname
        {
            get { return this.User.Firstname; }
            set
            {
                this.User.Firstname = value;

            }
        }
        public string Lastname
        {
            get { return this.User.Lastname; }
            set
            {
                this.User.Lastname = value;

            }
        }
        public string Username
        {
            get { return this.User.Username; }
            set
            {
                this.User.Username = value;

            }
        }
        public string Email
        {
            get { return this.User.Email; }
            set
            {
                if (value != ""){
                    this.User.Email = value;
                } 
                

            }
        }
        public string Password
        {
            get { return this.User.Password; }
            set
            {
                this.User.Password = value;

            }
        }
        public SignUpViewModel()
        {
            //création popup erreur
            Popup PopAlert = new Popup();
            TextBlock tb = new TextBlock();
            //vérification des champs
            if (this.Email.Contains("@"))
            {
                if (this.Username != "")
                {
                    if (this.Password != "")
                    {
                        PopAlert.IsOpen = false;
                        this.User = new User();
                        //création d'un nouveau sign up avec les données
                        User.Username = this.Username;
                        User.Password = this.Password;
                        User.Email = this.Email;
                        User.Firstname = this.Firstname;
                        User.Lastname = this.Lastname;
                        //création d'un json pour signup
                        string json = JsonConvert.SerializeObject(User);
                        postMethod("/api/auth/register", json);
                    }
                    else
                    {
                        tb.Text = "password is empty";
                        PopAlert.Child = tb;
                        PopAlert.IsOpen = true;
                    }
                }else
                {
                    tb.Text = "login is empty";
                    PopAlert.Child = tb;
                    PopAlert.IsOpen = true;
                }

            }else
            {
                tb.Text = "bad email";
                PopAlert.Child = tb;
                PopAlert.IsOpen = true;
            }

        }
        public async void postMethod(string url, string jsonString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://demo.comte.re");
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
