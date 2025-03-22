using System.Numerics;

namespace MyMonsterKampf
{
    internal class Goblin : MonsterBase
    {
        public override void Attack(MonsterBase _defendingMonster)
        {
            if (healthPoints > 0)
            {
                Random rnd = new Random();
                int critChance = rnd.Next(1, 100);
                float critMultiplier = 2f;

                float finalDamage = MathF.Round(attackPoints - 0.2f * _defendingMonster.defensePoints);

                if (critChance >= 80)
                {
                    finalDamage = MathF.Round(attackPoints * critMultiplier - 0.2f * _defendingMonster.defensePoints);
                    Console.WriteLine($"{SetRace()} landet einen kritischen Treffer!");
                }

                if (_defendingMonster.healthPoints > 0)
                {
                    _defendingMonster.TakeDamage(finalDamage);
                    if (_defendingMonster.healthPoints < 0)
                    {
                        _defendingMonster.healthPoints = 0;
                    }
                }
                else
                {
                    _defendingMonster.healthPoints = 0;
                }
            }
        }


        public override void TakeDamage(float _damage)
        {
            healthPoints -= _damage;
        }

        public override string SetRace()
        {
            string currentRace = race[2];
            return currentRace;
        }
    }
}
