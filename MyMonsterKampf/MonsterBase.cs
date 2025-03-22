namespace MyMonsterKampf
{
    public abstract class MonsterBase
    {
        // Deklarieren der Variablen. Jedes Monster hat 100 Punkte die vergeben werden können.
        public float healthPoints;
        public float attackPoints;
        public float defensePoints;
        public float speed;

        public string[] race = { "Ork", "Troll", "Goblin" };

        /// <summary>
        /// Führt den Angriff eines Monsters aus
        /// </summary>
        /// <param name="_defendingMonster">Nimmt die MonsterBase Klasse des verteidigenden Monsters an</param>
        public abstract void Attack(MonsterBase _defendingMonster);

        /// <summary>
        /// Fügt dem Monster Schaden hinzu
        /// </summary>
        /// <param name="_damage">Schaden, der hinzugefügt werden soll</param>
        public abstract void TakeDamage(float _damage);

        /// <summary>
        /// Gibt die Rasse des Monsters als string zurück
        /// </summary>
        /// <returns></returns>
        public abstract string SetRace();


        /// <summary>
        /// Definiert die Werte eines Monsters
        /// </summary>
        public void SetStats()
        {
            Console.WriteLine($"Bitte gebe die Stats für {SetRace()} ein!");
            Console.WriteLine();

            healthPoints = GetValidatedInput("Health Points");
            attackPoints = GetValidatedInput("Attack Points");
            defensePoints = GetValidatedInput("Defense Points");
            speed = GetValidatedInput("Speed");

            Console.WriteLine($"{SetRace()} hat {healthPoints} HP, {attackPoints} AP, {defensePoints} DP, {speed} S");
        }


        private float GetValidatedInput(string statName)
        {
            float value;
            while (true)
            {
                Console.WriteLine($"{statName} (1-100)");
                string input = Console.ReadLine()!;
                if (float.TryParse(input, out value) && value >= 1 && value <= 100)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gebe eine Zahl zwischen 1 und 100 ein.");
                }
            }
        }
    }
}
