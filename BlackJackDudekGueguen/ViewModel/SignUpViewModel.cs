using BlackJackDudekGueguen.Models;
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
        public SignUp SignUp { get; set; }
        //affectation des valeurs au model SignUp
        public string FirstName
        {
            get { return this.SignUp.FirstName; }
            set
            {
                this.SignUp.FirstName = value;

            }
        }
        public string LastName
        {
            get { return this.SignUp.LastName; }
            set
            {
                this.SignUp.LastName = value;

            }
        }
        public string Userlogin
        {
            get { return this.SignUp.Userlogin; }
            set
            {
                this.SignUp.Userlogin = value;

            }
        }
        public string Mail
        {
            get { return this.SignUp.Mail; }
            set
            {
                if (value != ""){
                    this.SignUp.Mail = value;
                } 
                

            }
        }
        public string UserPwd
        {
            get { return this.SignUp.UserPwd; }
            set
            {
                this.SignUp.UserPwd = value;

            }
        }
        public SignUpViewModel()
        {
            //création popup erreur
            Popup PopAlert = new Popup();
            TextBlock tb = new TextBlock();
            //vérification des champs
            if (this.Mail.Contains("@"))
            {
                if (this.Userlogin != "")
                {
                    if (this.UserPwd != "")
                    {
                        PopAlert.IsOpen = false;
                        this.SignUp = new SignUp();
                        //création d'un nouveau sign up avec les données
                        SignUp.Userlogin = this.Userlogin;
                        SignUp.UserPwd = this.UserPwd;
                        SignUp.Mail = this.Mail;
                        SignUp.FirstName = this.FirstName;
                        SignUp.LastName = this.LastName;
                        //création d'un json pour signup
                        string json = JsonConvert.SerializeObject(SignUp);
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
