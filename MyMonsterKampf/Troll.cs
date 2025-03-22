using System;

namespace MyMonsterKampf
{
    internal class Troll : MonsterBase
    {
       public override void SetStats()
       {
            healthPoints = 35f;
            attackPoints = 40f;
            defensePoints = 15f;
            speed = 10f;

       } 

        public override void Attack(MonsterBase _defendingMonster)
        {

            float finalDamage = attackPoints - _defendingMonster.defensePoints;

            if (_defendingMonster.healthPoints > 0)
            {
                _defendingMonster.TakeDamage(finalDamage);
            }
            else
            {
                _defendingMonster.healthPoints = 0;
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
