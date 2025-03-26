namespace MyMonsterKampf
{
    internal class GameManager
    {
        // Definition der Variablen
        private bool isGameOver = false;
        private bool firstInput = false;
        private bool secondInput = false;
        private MonsterBase firstMonster = null!;
        private MonsterBase secondMonster = null!;
        private MonsterBase monsterToAttack = null!;



        /// <summary>
        /// Erstellt den Game Loop. Läuft, solange die HP keines Monsters unter 0 sind. 
        /// </summary>
        public void GameLoop()
        {
            // Gibt am Ende des Kampfes den Sieger aus
            string winner = "";

            firstMonster.SetStats();
            secondMonster.SetStats();

            if (firstMonster.speed > secondMonster.speed)
            {
                monsterToAttack = firstMonster;
            }
            else
            {
                monsterToAttack = secondMonster;
            }

            while (!isGameOver)
            {

                if (monsterToAttack == firstMonster)
                {
                    FirstMonsterAttackHandler();
                    monsterToAttack = secondMonster;
                }
                else if (monsterToAttack == secondMonster)
                {
                    SecondMonsterAttackHandler();
                    monsterToAttack = firstMonster;
                }
                else
                {
                    Console.WriteLine("monsterToAttack hat keinen Wert zugewiesen!"); ;
                }

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
        public (MonsterBase firstMonster, MonsterBase secondMonster) ChooseMonster()
        {
            int userInput = 0;

                while (userInput == 0)
                {
                    Console.Write("Wähle das erste Monster: ");
                    int.TryParse(Console.ReadLine(), out userInput);

                    if (userInput == 1 || userInput == 2 || userInput == 3)
                    {
                        // User wählt das erste Monster
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
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe! Bitte gebe eine Zahl von 1 bis 3 ein.");
                        userInput = 0;
                    }
                }


            userInput = 0;

            while (userInput == 0)
            {
                Console.Write("Wähle das zweite Monster: ");
                int.TryParse(Console.ReadLine(), out userInput);

                if (userInput == 1 || userInput == 2 || userInput == 3)
                {
                    // User wählt das erste Monster
                    switch (userInput)
                    {
                        case 1:
                            secondMonster = new Ork();
                            firstInput = true;
                            break;
                        case 2:
                            secondMonster = new Troll();
                            firstInput = true;
                            break;
                        case 3:
                            secondMonster = new Goblin();
                            firstInput = true;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine($"{firstMonster.SetRace()} kämpft gegen {secondMonster.SetRace()}");
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte gebe eine Zahl von 1 bis 3 ein.");
                }
            }
            Console.Clear();
            return (firstMonster, secondMonster);
        }


        private void FirstMonsterAttackHandler()
        {
            if (firstMonster.healthPoints > 0)
            {
                Console.WriteLine($"{firstMonster.SetRace()} attackiert:");
                firstMonster.Attack(secondMonster);
                Console.WriteLine($"{secondMonster.SetRace()} hat noch {secondMonster.healthPoints} Lebenspunkte.");
                Console.ReadKey();
            }
        }

        private void SecondMonsterAttackHandler()
        {
            if (secondMonster.healthPoints > 0)
            {
                Console.WriteLine($"{secondMonster.SetRace()} attackiert:");
                secondMonster.Attack(firstMonster);
                Console.WriteLine($"{firstMonster.SetRace()} hat noch {firstMonster.healthPoints} Lebenspunkte.");
                Console.ReadKey();
            }
        }
    }
}
