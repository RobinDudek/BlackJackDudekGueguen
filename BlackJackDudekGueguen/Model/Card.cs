using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Model
{
    class Card
    {
        private int Color { get; set; }
        private int Number { get; set; }
        private int Value { get; set; }

        public Card(int color, int number)
        {
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
