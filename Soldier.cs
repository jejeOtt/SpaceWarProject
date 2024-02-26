using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWarProject
{
    public class Soldier
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int BaseHealth { get; set; }
        public int AttackDamage { get; set; }
        public Team TeamAffected { get; set; }
        public Soldier(Team team) 
        {
            Name = RandomGenerator.GenerateName();
            Health = RandomGenerator.GenerateNumber(1000, 2000);
            AttackDamage = RandomGenerator.GenerateNumber(100, 500);
            BaseHealth = Health;
            TeamAffected = team;
        }
        /// <summary>
        /// Attaque le soldat ciblé
        /// </summary>
        /// <param name="soldierTargeted"></param>
        public void Attack(ref Soldier soldierTargeted)
        {
            int damagePercentage = new Random().Next(100);
            int damageAttack = (int)Math.Round((double)(AttackDamage * damagePercentage) / 100);
            soldierTargeted.Health -= damageAttack;

            if (soldierTargeted.Health <= 0) soldierTargeted.Health = 0;

            SoldierLog(damageAttack, soldierTargeted);

        }
        /// <summary>
        /// Log sur l'etat des soldats durant la bataille
        /// </summary>
        /// <param name="damageAttack"></param>
        /// <param name="soldier"></param>
        public void SoldierLog(int damageAttack, Soldier soldier)
        {
            if (TeamAffected == Team.Rebel)
            {
                Console.WriteLine("\"Pour la princesse Organa !\"");
            }
            else
            {
                Console.WriteLine("\"Traitor !\"");
            }

            Console.WriteLine();
            Console.WriteLine($"Le soldat ciblé {soldier.Name} de l'équipe {soldier.TeamAffected} a actuellement {soldier.Health + damageAttack} points de vie");
            Console.WriteLine();

            if(damageAttack == 0)
                Console.WriteLine($"Dommage, le soldat {Name} de l'équipe {TeamAffected} n'a fait aucun point de dégâts !");
            else
                Console.WriteLine($"Le soldat {Name} de l'équipe {TeamAffected} a attaqué le soldat de l'équipe ennemie pour un total de {damageAttack} de points de dégâts !");

            Console.WriteLine();

            if (soldier.Health <= 0)
            {
                Console.WriteLine($"Le soldat {soldier.Name} est mort !");
                Console.WriteLine();
            } else
            {
                Console.WriteLine($"Le soldat ciblé {soldier.Name} a maintenant {soldier.Health} points de vie");
                Console.WriteLine();
            }
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();
        }
        public enum Team
        {
            Rebel,
            Empire
        }
    }
}
