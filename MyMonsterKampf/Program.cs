using System.Runtime.CompilerServices;

namespace MyMonsterKampf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.ChooseMonster();
            gameManager.GameLoop();
        }
    }
}