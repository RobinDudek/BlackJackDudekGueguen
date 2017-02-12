﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Model
{
    class Hand
    {
        public ObservableCollection<Card> Cards { get; set; }

        public int Score { get; set; }

        public Hand()
        {
            this.Cards = new ObservableCollection<Card>();
        }
    }
}
