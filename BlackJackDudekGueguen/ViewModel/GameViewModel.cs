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
            this.Bank.Hands = new ObservableCollection<Hand>();
            this.Player = new User();
            this.Player.Hands = new ObservableCollection<Hand>();
            drawCards();
            startGame();
        }

        public void drawCards()
        {
            draw(Player.Hands[0], true);
            draw(Bank.Hands[0], true);
            draw(Player.Hands[0], true);
            draw(Bank.Hands[0], false);
        }

        public void draw(Hand UserHand, bool isVisible)
        {
            UserHand.Add(this.Deck.Cards.Last());
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
        public async void updateStack(Double earnings)
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
