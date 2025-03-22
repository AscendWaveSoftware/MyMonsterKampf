using System;

namespace MyMonsterKampf
{
    internal class Troll : MonsterBase
    {
        public override void Attack(MonsterBase _defendingMonster)
        {
            if (healthPoints > 0)
            {
                float finalDamage = MathF.Round(attackPoints - 0.2f * _defendingMonster.defensePoints);

                if (healthPoints > _defendingMonster.healthPoints)
                {
                    float damageMultiplier = 1.2f;
                    finalDamage = MathF.Round(finalDamage * damageMultiplier);
                    Console.WriteLine($"{SetRace()} hat einen Schadensbonus, da die HP von {_defendingMonster.SetRace()} niedriger sind.");
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

            string currentRace = race[1];
            return currentRace;
        }
    }
}
