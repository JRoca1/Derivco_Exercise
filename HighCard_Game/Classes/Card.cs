using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighCard_Game.Classes
{
    public class Card
    {
        private int Number;
        private int Suit;
        private bool WildCar;

        public Card(int Number, int Suit)
        {
            this.Number = Number;
            this.Suit = Suit;
        }

        public int GetNumber() { return this.Number; }

        public int GetSuit() {  return this.Suit; }

        public void SetWildCar(bool value)
        {
            WildCar = value;
        }

        public bool GetWildCar()
        {
            return WildCar;
        }

        public override string ToString()
        {
            return String.Format("CardNumber: {0} , Suit: {1}, is Wild Car: {2}", Number, Suit, WildCar);
        }


    }
}
