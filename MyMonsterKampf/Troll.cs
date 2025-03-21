using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMonsterKampf
{
    internal class Troll : MonsterBase
    {
       public override void SetStats()
       {
            healthPoints = 200f;
            attackPoints = 20f;
            defensePoints = 15f;
            speed = 3f;

            string currentRace = race[1];
       } 

        public override void Attack(MonsterBase _defendingMonster)
        {
            Random rnd = new Random();
            int critChance = rnd.Next(1, 200);
            float critMultiplier = 2f;

            float finalDamage = attackPoints - _defendingMonster.defensePoints;

            if (critChance >= 80)
            {
                finalDamage = attackPoints * critMultiplier - _defendingMonster.defensePoints;
            }

            _defendingMonster.TakeDamage(finalDamage);
        }

        public override void TakeDamage(float _damage)
        {
            healthPoints -= _damage;
        }
    }
}
