namespace MyMonsterKampf
{
    internal class Ork : MonsterBase
    {
        public override void SetStats()
        {
            healthPoints = 100f;
            attackPoints = 10f;
            defensePoints = 5;
            speed = 15f;

            string currentRace = race[0];
        }

        public override void Attack(MonsterBase _defendingMonster)
        {
            Random rnd = new Random();
            int critChance = rnd.Next(1, 100);
            float critMultiplier = 1.5f;

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
