
using System.Collections.Generic;

namespace SpaceWarProject
{
    public class SpaceWar
    {
        static void Main(string[] args)
        {

            Console.Write("Nombre de soldats de l'empire:");
            int soldierEmpireNbr = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nombre de soldats rebelles:");
            int soldierRebelNbr = Convert.ToInt32(Console.ReadLine());

            List<Soldier> soldierEmpireList = RandomGenerator.GenerateSoldiersList(soldierEmpireNbr, Soldier.Team.Empire);
            List<Soldier> soldierRebelList = RandomGenerator.GenerateSoldiersList(soldierRebelNbr, Soldier.Team.Rebel);

            Soldier.Team winningTeam = new Soldier.Team();

            DisplayConsole(soldierRebelList, soldierEmpireList);

            while (soldierEmpireList.Any(x => x.Health > 0) && soldierRebelList.Any(x => x.Health > 0))
            {
                // Choix aléatoire entre 0 et 1
                int randomSelectedCamp = new Random().Next(2);

                Soldier soldierChooseToAttack = RandomGenerator.RandomSoldier((randomSelectedCamp == 0) ? soldierEmpireList : soldierRebelList);
                Soldier soldierTargeted = RandomGenerator.RandomSoldier((soldierChooseToAttack.TeamAffected == Soldier.Team.Rebel) ? soldierEmpireList : soldierRebelList);

                soldierChooseToAttack.Attack(ref soldierTargeted);

                DisplayConsole(soldierRebelList, soldierEmpireList);

            }
            Console.Write("une équipe a gagné lol");
            Console.ReadKey();

        }
        public static void DisplayConsole(List<Soldier> soldierRebelList, List<Soldier> soldierEmpireList)
        {
            string text = "Tableau de bord des équipes";

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));

            soldierRebelList.DisplaySoldiers();
            soldierEmpireList.DisplaySoldiers();

            Console.WriteLine("Appuyer sur une touche pour passer au prochain tour...");
            Console.ReadKey();
        }

    }
}
