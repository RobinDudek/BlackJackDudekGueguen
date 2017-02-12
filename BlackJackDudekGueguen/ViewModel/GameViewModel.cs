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
            drawCards();
            startGame();
        }

        public void drawCards()
        {
            draw(Player.Hand, true);
            draw(Bank.Hand, true);
            draw(Player.Hand, true);
            draw(Bank.Hand, false);
        }

        public void draw(Hand UserHand, bool isVisible)
        {
            Card cardDrawed = this.Deck.Cards.Last();
            cardDrawed.IsVisible = isVisible;
            UserHand.Cards.Add(cardDrawed);
            int numberCard = Deck.Cards.Count;
            Deck.Cards.RemoveAt(numberCard);
        }

        public void startGame()
        {

        }

        public void split()
        {

        }



        //Se fait à la fin d'un tour
        public async void updateStack(Double moneyWin)
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
