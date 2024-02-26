using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWarProject
{
    public static class DisplayConsoleExtensions
    {
        /// <summary>
        /// Extension permetant d'afficher la santé, le nom ainsi que le score des soldats
        /// </summary>
        /// <param name="soldiers"></param>
        public static void DisplaySoldiers(this List<Soldier> soldiers) 
        {
            Soldier.Team? team = soldiers.FirstOrDefault()?.TeamAffected;

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Equipe " + team + " " + soldiers.Where(x => x.Health > 0).ToList().Count + "/" + soldiers.Count);

            if (team == Soldier.Team.Empire)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine();

            foreach (Soldier soldier in soldiers)
            {
                StringBuilder sb = new StringBuilder();

                var percentageHealthBar = (int)Math.Round((double)soldier.Health * 100 / soldier.BaseHealth);
                //Permet d'afficher la bar de santé des soldats
                for (int i = 0; i < percentageHealthBar; i+=2)
                {
                    sb.Append('\u2551');
                }
                int soldierScore = soldier.Health + soldier.AttackDamage * 10;
                Console.WriteLine(String.Format("{0,-20} | {1,-50} | {2,-20} | {3, 5}", soldier.Name, sb, " PV : " + soldier.Health + "/" + soldier.BaseHealth + (soldier.Health <= 0 ? " (Mort)" : ""),"Score : " + soldierScore));

                Console.WriteLine();


            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
