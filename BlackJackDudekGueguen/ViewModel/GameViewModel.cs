using BlackJackDudekGueguen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.ViewModel
{
    class GameViewModel
    {
        public Deck Deck { get; set; }
        public User Bank { get; set; }
        public User Player { get; set; }

        public GameViewModel()
        {
            this.Deck = new Deck();
            this.Bank = new User();
            this.Bank.Hand = new Hand();
            this.Player = new User();
            this.Player.Hand = new Hand();
            DrawCards();
            StartGame();
        }

        //On fait les tirages du début du tour
        public void DrawCards()
        {
            Draw(Player.Hand, true);
            Draw(Bank.Hand, true);
            Draw(Player.Hand, true);
            Draw(Bank.Hand, false);
        }

        //Code pour distribuer une carte
        public void Draw(Hand UserHand, bool isVisible)
        {
            //La carte tirée est la dernière du paquet
            Card cardDrawed = this.Deck.Cards.Last();
            //face ou visible ou cachée
            cardDrawed.IsVisible = isVisible;
            //on l'ajoute à la main du joueur
            UserHand.Cards.Add(cardDrawed);
            //on supprime la drnière carte du paquet (celle qui vient d'être tiré)
            int numberCard = Deck.Cards.Count;
            Deck.Cards.RemoveAt(numberCard);
        }

        //Pas eu le temps d'avancer plus le code, beaucoup de souci
        public void StartGame()
        {
            //Display Bet View Model
            //Do you want to play
            //if yes
                // 
                if(Player.Hand.Cards[0].Number == Player.Hand.Cards[1].Number)
                {
                    //Display Split Button
                }

            //else
                //stop Game

        }

        //si il click sur le bouton split
        public void Split()
        {

        }

        //Si il clique sur le bouton assurance
        public void Insurance()
        {

        }

        public void Forgive()
        {

        }

        //Se fait à la fin d'un tour
        public async void UpdateStack(int moneyWin)
        {
            string apiUrl = "user/" + Player.Email + "/stack/" + moneyWin;
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
