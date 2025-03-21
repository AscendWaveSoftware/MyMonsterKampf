namespace MyMonsterKampf
{
    public abstract class MonsterBase
    {
        // Deklarieren der Variablen
        public float healthPoints;
        public float attackPoints;
        public float defensePoints;
        public float speed;

        public string[] race = { "Ork", "Troll", "Goblin" };


        public abstract void SetStats();

        public abstract void Attack(MonsterBase _defendingMonster);

        public abstract void TakeDamage(float _damage);
    }
}
