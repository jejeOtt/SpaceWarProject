using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWarProject
{
    public class Soldier
    {
        public Guid BadgeID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public bool Favorite { get; set; }
        public Team TeamAffected { get; set; }
        public Soldier(Team team) 
        {
            Name = RandomGenerator.GenerateName();
            Health = RandomGenerator.GenerateNumber(1000, 2000);
            AttackDamage = RandomGenerator.GenerateNumber(100, 500);
            TeamAffected = team;
        }
        public void Attack(ref Soldier soldierTargeted)
        {
            int damagePercentage = new Random().Next(100);
            int damageAttack = (int)Math.Round((double)(AttackDamage * damagePercentage) / 100);
            soldierTargeted.Health -= damageAttack;

            if (soldierTargeted.Health <= 0) soldierTargeted.Health = 0;

            SoldierLog(damageAttack, soldierTargeted);

        }
        public void SoldierLog(int damageAttack, Soldier soldier)
        {
            if (TeamAffected == Team.Rebel)
            {
                Console.WriteLine("Pour la princesse Organa !");
            }
            else
            {
                Console.WriteLine("Traitor !");
            }

            Console.WriteLine($"Le soldat {soldier.Name} a {soldier.Health + damageAttack} points de vie");
            Console.WriteLine($"Le soldat {Name} de l'équipe {TeamAffected} a attaqué le soldat de l'équipe ennemie !");
            Console.WriteLine($"Il a attaqué pour un total de {damageAttack} de points de dégâts");
            Console.WriteLine($"Le soldat ciblé {soldier.Name} a maintenant {soldier.Health} points de vie");

            if(soldier.Health <= 0)
            {
                Console.WriteLine($"Le soldat {soldier.Name} est mort !");
            }

        }
        public enum Team
        {
            Rebel,
            Empire
        }
    }
}
