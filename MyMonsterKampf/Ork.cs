namespace MyMonsterKampf
{
    internal class Ork : MonsterBase
    {
        public override void Attack(MonsterBase _defendingMonster)
        {
            if (healthPoints > 0)
            {
                float finalDamage = MathF.Round(attackPoints - 0.2f * _defendingMonster.defensePoints);

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

            string currentRace = race[0];
            return currentRace;
        }
    }
}
