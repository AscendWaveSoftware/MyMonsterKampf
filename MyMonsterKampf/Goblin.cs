namespace MyMonsterKampf
{
    internal class Goblin : MonsterBase
    {
        public override void SetStats()
        {
            // Goblin sehr schnell, crit-lastig
            healthPoints = 20f;
            attackPoints = 20f;
            defensePoints = 15;
            speed = 45f;
        }

        public override void Attack(MonsterBase _defendingMonster)
        {
            Random rnd = new Random();
            int critChance = rnd.Next(1, 100);
            float critMultiplier = 2f;

            float finalDamage = attackPoints - _defendingMonster.defensePoints;

            if (critChance >= 80)
            {
                finalDamage = attackPoints * critMultiplier - _defendingMonster.defensePoints;
            }

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

            string currentRace = race[2];
            return currentRace;
        }
    }
}
