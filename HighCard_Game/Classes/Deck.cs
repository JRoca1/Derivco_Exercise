using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighCard_Game.Classes
{
    public class Deck
    {
        private int NumSuits;

        private Card[] Cards;
        

        public Deck(int NumCards, int NumSuits)
        {
            if (NumCards % NumSuits != 0) 
                throw new Exception(String.Format("NumSuites: {0} is not multiple for NumCards: {1}", NumSuits, NumCards));

            this.NumSuits = NumSuits;
            this.Cards = new Card[NumCards];

            SetDeck();
            SetWildCar();
        }

        private void SetDeck()
        {            
            int cardnumber;
            for (int i = 0; i < NumSuits; i++)
            {
                cardnumber = 1;
                for(int j = (Cards.Length / NumSuits) * i; j < ((Cards.Length / NumSuits) * (i + 1)); j++)
                {
                    this.Cards[j] = new Card(cardnumber, i);
                    cardnumber++;
                }
            }            
        }

        private void SetWildCar()
        {
            Random rnd = new Random();

            Card X = GetCard(rnd.Next(Cards.Length));
            X.SetWildCar(true);
        }

        public int GetNumCards()
        {
            return this.Cards.Length;
        }

        public int GetNumSuits()
        {
            return this.NumSuits;
        }

        public Card GetCard(int num)
        {
            return this.Cards[num];
        }
    }
}
