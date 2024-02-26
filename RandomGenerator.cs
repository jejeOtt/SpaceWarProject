using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWarProject
{

    public class RandomGenerator
    {
        private static readonly string[] firstNames = { "Thomas", "Jérémy", "Luke", "Han", "Leïa", "Dark", "Anakin", "Jar Jar", "Sheev", "Chewbacca", "Obi-Wan" };
        private static readonly string[] lastNames = { "Pesquet", "Ott" , "Skywalker", "Solo", "Vador", "Sidious", "Spock", "Binks", "Palpatine", "Kenobi" };

        /// <summary>
        /// Genere un nom et un prénom en les associant avec les 2 listes ci-dessus 
        /// </summary>
        /// <returns></returns>
        public static string GenerateName()
        {
            var random = new Random();

            string firstName = firstNames[random.Next(0, firstNames.Length)];
            string lastName = lastNames[random.Next(0, lastNames.Length)];
            
            return $"{firstName} {lastName}";
        }
        /// <summary>
        /// Prend un nombre aléatoire entre un nombre minimal et maximal désigné
        /// </summary>
        /// <param name="numberMin"></param>
        /// <param name="numberMax"></param>
        /// <returns></returns>
        public static int GenerateNumber(int numberMin, int numberMax)
        {
            var random = new Random();
            return random.Next(numberMin, numberMax);
        }
        /// <summary>
        /// Genere une liste de soldats en fonction du nombre renseigné par équipe
        /// </summary>
        /// <param name="soldierNbr"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public static List<Soldier> GenerateSoldiersList(int soldierNbr, Soldier.Team team)
        {
            List<Soldier> soldierList = new List<Soldier>();

            for (int i = 0; i < soldierNbr; i++)
            {
                Soldier newSoldier = new Soldier(team);
                soldierList.Add(newSoldier);
            }
            return soldierList;
        }
        /// <summary>
        /// Désigne un soldat en fonction d'une liste donné
        /// </summary>
        /// <param name="soldiers"></param>
        /// <returns></returns>
        public static Soldier RandomSoldier(List<Soldier> soldiers)
        {
            var random = new Random();
            //Filtre sur les soldats qui sont encore en vie et choisie un soldat au hasard
            List<Soldier> soldierFilterOnHealth = soldiers.Where(x => x.Health > 0).ToList();
            Soldier soldier = soldierFilterOnHealth[random.Next(soldierFilterOnHealth.Count)];
            return soldier;
        }
    }
}

