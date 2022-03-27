using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Game
    {
        private World myWorld;
        private Player currentPlayer;
        public void Start()
        {
            string[,] grid = LevelParser.ParseFileToArray(@"C:\Users\pc\source\repos\ConsoleGame\ConsoleGame\level1.txt");
            myWorld = new World(grid);
            currentPlayer = new Player(1, 7);

            GameLoop();
        }

        private void Draw()
        {
            myWorld.Draw();
            currentPlayer.DrawPlayer();
        }

        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.W:
                    currentPlayer.Y -= 1;
                    break;
                case ConsoleKey.A:
                    currentPlayer.X -= 1;
                    break;
                case ConsoleKey.S:
                    currentPlayer.Y += 1;
                    break;
                case ConsoleKey.D:
                    currentPlayer.X += 1;
                    break;
                default:
                    break;
            }

        }
        private void GameLoop()
        {
            while (true)
            {
                //DrawLevel
                Draw();

                //handle any input
                HandleInput();
                
            }
        }
    }
}
