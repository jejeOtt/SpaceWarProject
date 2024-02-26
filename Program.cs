
using System.Collections.Generic;
using static SpaceWarProject.Soldier;

namespace SpaceWarProject
{
    public class SpaceWar
    {
        static void Main(string[] args)
        {
            try
            {
                //On choisit le nombre de soldats par équipe que l'on souhaite
                Console.Write("Nombre de soldats de l'empire :");
                int soldierEmpireNbr = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Nombre de soldats rebelles :");
                int soldierRebelNbr = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                //On choisit l'équipe favorite
                Console.Write("Choisir une équipe favorite (Rebel ou Empire) :");
                string favoriteTeamInput = Console.ReadLine();
                Console.WriteLine();

                if (Enum.TryParse(favoriteTeamInput, true, out Team favoriteTeamChoosen))
                {
                    Console.WriteLine($"L'équipe favorite est : {favoriteTeamChoosen}");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Saisie invalide. Choix aléatoire par défaut");
                    Thread.Sleep(1000);
                    Console.WriteLine();

                    favoriteTeamChoosen = (new Random().Next(2) == 0) ? Team.Rebel : Team.Empire;
                    Console.WriteLine($"L'équipe favorite désignée aléatoirement est : {favoriteTeamChoosen}");
                    Thread.Sleep(1000);
                }

                List<Soldier> soldierEmpireList = RandomGenerator.GenerateSoldiersList(soldierEmpireNbr, Team.Empire);
                List<Soldier> soldierRebelList = RandomGenerator.GenerateSoldiersList(soldierRebelNbr, Team.Rebel);
                Team winningTeam = new Team();

                Console.Clear();
                DisplayConsole(soldierRebelList, soldierEmpireList);

                //La condition est vraie tant que une des équipes a toujours des soldats vivants
                while (soldierEmpireList.Any(x => x.Health > 0) && soldierRebelList.Any(x => x.Health > 0))
                {
                    //On choisit un camp aléatoire à prendre
                    int randomSelectedCamp = new Random().Next(2);

                    //On choisit un soldat aléatoire dans la liste généré en fonction du camp qui a été déterminé
                    Soldier soldierChooseToAttack = RandomGenerator.RandomSoldier((randomSelectedCamp == 0) ? soldierEmpireList : soldierRebelList);
                    Soldier soldierTargeted = RandomGenerator.RandomSoldier((soldierChooseToAttack.TeamAffected == Team.Rebel) ? soldierEmpireList : soldierRebelList);

                    //Le soldat désigné attaque le soldat ciblé
                    soldierChooseToAttack.Attack(ref soldierTargeted);

                    DisplayConsole(soldierRebelList, soldierEmpireList);
                }

                if (soldierEmpireList.Any(x => x.Health > 0))
                    winningTeam = Team.Empire;
                else
                    winningTeam = Team.Rebel;

                Console.WriteLine("L'équipe " + winningTeam + " a gagné !");
                Console.WriteLine();

                Thread.Sleep(1000);

                if (winningTeam == favoriteTeamChoosen)
                    Console.WriteLine("Félicitations ! Votre équipe favorite vient de gagner !");
                else
                    Console.WriteLine("Dommage, votre équipe favorite a perdue !");

                Console.WriteLine();
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }


        }
        /// <summary>
        /// Affiche le tableau de bord des équipes
        /// </summary>
        /// <param name="soldierRebelList"></param>
        /// <param name="soldierEmpireList"></param>
        public static void DisplayConsole(List<Soldier> soldierRebelList, List<Soldier> soldierEmpireList)
        {
            string text = "Tableau de bord des équipes";
            //Centre le titre en fonction de la taille de la console
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));

            soldierRebelList.DisplaySoldiers();
            soldierEmpireList.DisplaySoldiers();

            Console.WriteLine("Appuyer sur une touche pour passer au prochain tour...");
            Console.WriteLine();
            Console.ReadKey();
        }

    }
}
