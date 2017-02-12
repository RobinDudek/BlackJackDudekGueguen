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
        public bool hasForgiven { get; set; }
        public bool hasInsurance { get; set; }
        public bool hasDoubled { get; set; }
        public bool hasSplit { get; set; }
        
        public GameViewModel()
        {
            hasForgiven = false;
            hasSplit = false;
            hasInsurance = false;
            hasDoubled = false;
            this.Deck = new Deck();
            this.Bank = new User();
            this.Bank.Hand = new Hand();
            this.Player = new User();
            this.Player.Hand = new Hand();
            AskBet();
            DrawCards();
            StartGame();
        }

        //On demande au joueur de parier
        public void AskBet()
        {

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

        //Pas eu le temps d'avancer plus le code, 
        //beaucoup trop de souci avec le git qu'on a dû réparer
        public void StartGame()
        {
            //Display Bet PopUp

            //Do you want to play
            //if yes
            if (Player.Hand.Cards[0].Number == Player.Hand.Cards[1].Number)
            {
                //Display Split Button
            }
            if (Bank.Hand.Cards[0].Number == 1)
            {
                //Display Insurance Button
            }

            //else
            //stop Game
        }


        //
        //si il clique sur le bouton split
        public void Split()
        {
            Player.SplitHand = new Hand();
            Player.SplitHand.Cards = new ObservableCollection<Card>();
            Player.SplitHand.Cards.Add(Player.Hand.Cards[1]);
            Player.Hand.Cards.RemoveAt(1);
            Player.SplitHand.Bet = Player.Hand.Bet;

            hasSplit = true;
        }

        //Si il clique sur le bouton assurance
        public void Insurance()
        {
            Player.Hand.SideBet = Player.Hand.Bet;
            hasInsurance = true;
        }

        //il clic sur le bouton Forgive
        public void Forgive()
        {
            hasForgiven = true;
        }

        //si il clique sur le bouton double
        //il double les gains de sa mise
        public void Double()
        {
            hasDoubled = true;
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
