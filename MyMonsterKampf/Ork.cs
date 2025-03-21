﻿namespace MyMonsterKampf
{
    internal class Ork : MonsterBase
    {
        public override void SetStats()
        {
            // Ork ausgewogen
            healthPoints = 30f;
            attackPoints = 25f;
            defensePoints = 25;
            speed = 20f;

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

            string currentRace = race[0];
            return currentRace;
        }
    }
}
