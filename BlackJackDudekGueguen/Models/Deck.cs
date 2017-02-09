using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Models
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public Deck()
        {
            this.Cards = new List<Card>();
            CreateDeck();
            ShuffleDeck();
            AddCutCard();
        }

        public void CreateDeck()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    Cards.Add(new Card(i, j));
                }
            }
        }

        public void ShuffleDeck()
        {

        }

        public void AddCutCard()
        {

        }
    }
}
