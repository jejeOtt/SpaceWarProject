using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWarProject
{
    public static class DisplayConsoleExtensions
    {
        public static void DisplaySoldiers(this List<Soldier> soldiers) 
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Equipe " + soldiers.FirstOrDefault()?.TeamAffected);

            Console.WriteLine();

            foreach (Soldier soldier in soldiers)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < soldier.Health; i+=50)
                {
                    sb.Append('\u2551');
                    
                }
                Console.WriteLine(String.Format("{0,-14} | {1,-40} | {2,5}", soldier.Name, sb, " " + (soldier.Health <= 0 ? "Mort" : soldier.Health)));

                Console.WriteLine();

            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void DisplayEndScoreBoard() { }
    }
}
