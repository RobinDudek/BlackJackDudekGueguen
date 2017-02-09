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

            int cardPackages = 6;

            for (int packageNumber = 0; packageNumber < cardPackages; packageNumber++)
            {
                for (int color = 0; color < 4; color++)
                {
                    for (int number = 0; number < 13; number++)
                    {
                        Cards.Add(new Card(color, number));
                    }
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
