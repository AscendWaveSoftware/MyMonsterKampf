using System.Runtime.CompilerServices;

namespace MyMonsterKampf
{
    internal class Program
    {
        static bool isGameOver = false;

        static void Main(string[] args)
        {
            ChooseMonster();
            GameLoop();
        }


        /// <summary>
        /// Erstellt den Game Loop. Läuft, solange die HP keines Monsters unter 0 sind. 
        /// </summary>
        static void GameLoop()
        {
            MonsterBase firstMonster = ChooseMonster().firstMonster;
            MonsterBase secondMonster = ChooseMonster().secondMonster;

            string winner = "";


            firstMonster.SetStats();
            secondMonster.SetStats();

            while (!isGameOver)
            {
                    Console.WriteLine($"{firstMonster.SetRace()} attackiert:");
                    firstMonster.Attack(secondMonster);
                    Console.WriteLine($"{secondMonster.SetRace()} hat noch {secondMonster.healthPoints} Lebenspunkte.");
                    Console.ReadKey();

                    Console.WriteLine($"{secondMonster.SetRace()} attackiert:");
                    secondMonster.Attack(firstMonster);
                    Console.WriteLine($"{firstMonster.SetRace()} hat noch {firstMonster.healthPoints} Lebenspunkte.");


                    Console.ReadKey();

                    if (firstMonster.healthPoints == 0 || secondMonster.healthPoints == 0)
                    {
                        if (firstMonster.healthPoints == 0)
                        {
                            winner = secondMonster.SetRace();
                        }
                        else if (secondMonster.healthPoints == 0)
                        {
                            winner = firstMonster.SetRace();
                        }
                        isGameOver = true;
                    }
                
            }
            Console.Clear();
            Console.WriteLine($"{winner} hat gewonnen!");
        }



        /// <summary>
        /// Regelt die Logik für das Auswählen der Monster. Nutzer kann 1-3 als Input eingeben.
        /// </summary>
        /// <returns>Gibt die zwei Monstertypen zurück, die der Nutzer ausgewählt hat</returns>
        static (MonsterBase firstMonster, MonsterBase secondMonster) ChooseMonster()
        {
            int userInput = 0;
            bool firstInput = false;
            bool secondInput = false;
            MonsterBase firstMonster = null;
            MonsterBase secondMonster = null;


            while (!firstInput)
            {
                Console.Write("Wähle das erste Monster:");
                int.TryParse(Console.ReadLine(), out userInput);

                switch (userInput)
                {
                    case 1:
                        firstMonster = new Ork();
                        firstInput = true;
                        break;
                    case 2:
                        firstMonster = new Troll();
                        firstInput = true;
                        break;
                    case 3:
                        firstMonster = new Goblin();
                        firstInput = true;
                        break;
                }
            }


            if (firstInput == true)
            {
                while (!secondInput)
                {
                    Console.Write("Wähle das zweite Monster:");
                    int.TryParse(Console.ReadLine(), out userInput);

                    switch (userInput)
                    {
                        case 1:
                            secondMonster = new Ork();
                            secondInput = true;
                            break;
                        case 2:
                            secondMonster = new Troll();
                            secondInput = true;
                            break;
                        case 3:
                            secondMonster = new Goblin();
                            secondInput = true;
                            break;
                    }
                }
            }
            Console.WriteLine($"{firstMonster.SetRace()} kämpft gegen {secondMonster.SetRace()}");
            return (firstMonster, secondMonster);
        }
        
    }
}