using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Models
{
    class Card
    {
        private int Color { get; set; }
        private int Number { get; set; }
        private int Value { get; set; }

        public Card(int color, int number)
        {
            /**
             * i ==> Color
             * i = 1, SPADES (Pics)
             * i = 2, HEARTS (Coeurs)
             * i = 3, CLUBS (Trèfles)
             * i = 4, DIAMONDS (Carreaux)
             * 
             * j ==> Number
             * j = 1, ACE
             * j = 2, TWO
             * j = 3, THREE
             * j = 4, FOUR
             * j = 5, FIVE
             * j = 6, SIX
             * j = 7, SEVEN
             * j = 8, EIGHT
             * j = 9, NINE
             * j = 10, TEN
             * j = 11, JACK
             * j = 12, QUEEN
             * j = 13, KING
             **/

            this.Color = color;
            this.Number = number;
            if(number==10 && number == 11 && number == 12 && number == 13)
            {
                this.Value = 10;
            }
            else
            {
                this.Value = number;
            }
        }
    }
}
