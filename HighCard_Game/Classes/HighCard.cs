using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HighCard_Game.Classes
{

    public enum PlayMethods
    {
        TieAllowed,
        TieNewCard
    }

    public class HighCard
    {
        private PlayMethods PlayMethod;

        public Deck Deck;

        public HighCard(PlayMethods playMethod)
        {
            this.PlayMethod = playMethod;
            Deck = new Deck(52, 4);
        }

        public HighCard(int DeckCards, int DeckSuits, PlayMethods playMethod)
        {
            this.PlayMethod = playMethod;
            Deck = new Deck(DeckCards, DeckSuits);
        }

        /// <summary>
        /// 0 Lost
        /// 1 Win
        /// 2 Tie
        /// </summary>
        /// <returns></returns>
        public int Play()
        {
            Random rnd = new Random();

            Card A = Deck.GetCard(rnd.Next(Deck.GetNumCards()));
            Card B = Deck.GetCard(rnd.Next(Deck.GetNumCards()));

            Console.WriteLine(A.ToString() + " <-> " + B.ToString());

            if (A.GetWildCar()) return 0;

            if (B.GetWildCar()) return 1;

            if (B.GetNumber() > A.GetNumber()) return 1;

            if (B.GetNumber() == A.GetNumber())
            {
                if (PlayMethod == PlayMethods.TieNewCard)
                    return 2;

                if (B.GetSuit() > A.GetSuit()) return 1;
            }

            return 0;
        }
    }
}
