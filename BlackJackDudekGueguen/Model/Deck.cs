using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackDudekGueguen.Model
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public Deck()
        {
            this.Cards = new List<Card>();
            CreateDeck();
            ShuffleDeck();
        }

        public void CreateDeck()
        {
            //Le nombre de paquet nécessaire
            int cardPackages = 6;

            //On boucle le nombre de paquet nécessaire
            for (int packageNumber = 0; packageNumber < cardPackages; packageNumber++)
            {
                //A partir d'ici on rempli un paquet
                //4 couleur, on boucle 4 fois de 1 à 4
                for (int color = 1; color < 5; color++)
                {
                    //13 cartes par couleur, on boucle 13 fois
                    for (int number = 1; number < 14; number++)
                    {
                        //on ajoute la carte créée dans le deck
                        Cards.Add(new Card(color, number));
                    }
                }
            }
        }

        public void ShuffleDeck()
        {
            //code de randomisation trouvé sur internet

            //le deck de carte qui sera retourné une fois mélangé
            List<Card> randomizedDeck = new List<Card>();

            //notre valeur random
            Random r = new Random();

            //on choisi de façon random la position de la cutCard entre 50 et 80%
            //Dans 6 paquets, il y a 312 cartes, donc 50% vaut 156 et 80% vaut 249,6 donc 250
            int cutCard = r.Next(156, 250);
            bool cutCardIsSet = false;

            int randomIndex = 0;
            while (this.Cards.Count > 0)
            {
                //Si le nouveau deck n'a pas encore de cut card
                //on fait 312 - cutCard car sinon la cut card se retrouverais vers le haut du paquet
                if(randomizedDeck.Count == (312 - cutCard))
                {
                    randomizedDeck.Add(new Card(0, 0));
                    cutCardIsSet = true;
                }
                else
                {
                    //on choisi une carte random du premier deck
                    randomIndex = r.Next(0, this.Cards.Count);
                    //on la copie dans le second
                    randomizedDeck.Add(this.Cards[randomIndex]);
                    //puis on la supprime du premier
                    this.Cards.RemoveAt(randomIndex);
                }

            }
            //On brule les 5 premières cartes
            for(int burn = 0; burn < 5; burn++)
            {

            }
            //une fois que toute les cartes on été tirées, 
            //on remplace le premier deck par le deck mélangé
            this.Cards = randomizedDeck;
        }
    }
}
