using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWarProject
{

    public class RandomGenerator
    {
        private static readonly string[] firstNames = { "Apollo", "Atlas", "Aurora", "Cielo", "Thomas" };
        private static readonly string[] lastNames = { "Cosmo", "Jericho", "Orion", "Pranav", "Pesquet" };
        public static string GenerateName()
        {
            var random = new Random();

            string firstName = firstNames[random.Next(0, firstNames.Length)];
            string lastName = lastNames[random.Next(0, lastNames.Length)];
            
            return $"{firstName} {lastName}";
        }
        public static int GenerateNumber(int numberMin, int numberMax)
        {
            var random = new Random();
            return random.Next(numberMin, numberMax);
        }
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
        public static Soldier RandomSoldier(List<Soldier> soldiers)
        {
            var random = new Random();
            List<Soldier> soldierFilterOnHealth = soldiers.Where(x => x.Health > 0).ToList();
            Soldier soldier = soldierFilterOnHealth[random.Next(soldierFilterOnHealth.Count)];
            return soldier;
        }
    }
}

