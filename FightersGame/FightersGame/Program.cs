using Fighters.Managers;

namespace Fighters
{
    public class Program
    {
        static void Main( string[] args )
        {
            IGameManager gameManager = new GameManager();
            gameManager.Play();

        }
    }
}