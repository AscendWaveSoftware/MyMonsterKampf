using System.Runtime.CompilerServices;

namespace MyMonsterKampf
{
    internal class Program
    {
        static bool isGameOver = false;
        static int firstMonster = 0;
        static int secondMonster = 0;

        static void Main(string[] args)
        {
            GameLoop();
        }


        /// <summary>
        /// Erstellt den Game Loop. Läuft, solange die HP keines Monsters unter 0 sind. 
        /// </summary>
        static void GameLoop()
        {
            Ork ork = new Ork();
            Troll troll = new Troll();
            ork.SetStats();
            troll.SetStats();
            while (!isGameOver)
            {

                Console.WriteLine($"{ork.race} attackiert:");
                ork.Attack(troll);
                Console.WriteLine($"Toll hat noch {troll.healthPoints} Lebenspunkte.");
                Console.ReadKey();
                Console.WriteLine($"{troll.race} attackiert:");
                troll.Attack(ork);
                Console.WriteLine($"Ork hat noch {ork.healthPoints} Lebenspunkte.");
                Console.ReadKey();

            }
        }
        
    }
}