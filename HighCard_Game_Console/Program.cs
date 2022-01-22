using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighCard_Game.Classes;
using System.Diagnostics;

namespace HighCard_Game_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //HighCard highCard = new HighCard(20, 8, PlayMethods.TieNewCard);
                HighCard highCard = new HighCard(PlayMethods.TieNewCard);

                Console.WriteLine("Press some key to play!");

                while (true)
                {
                    Console.ReadKey();

                    int result = highCard.Play();

                    if (result == 0) Console.WriteLine("You Lost");
                    else if (result == 1) Console.WriteLine("You Win!!");
                    else if (result == 2) Console.WriteLine("You Tie, try again");
                }
            }
            catch (Exception ex)
            {
                Trace.Write(ex.ToString());
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
