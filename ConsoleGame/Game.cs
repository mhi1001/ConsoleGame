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
        private World _myWorld;
        private Player _currentPlayer;
        private Enemy _currentEnemy;
        public static bool PendingMovement = false;

        public void Start()
        {
            string[,] grid = LevelParser.ParseFileToArray(@"C:\Users\pc\source\repos\ConsoleGame\ConsoleGame\level1.txt");
            _myWorld = new World(grid);
            _currentPlayer = new Player(1, 7);
            _currentEnemy = new Enemy(25, 1);
            _currentEnemy.Color = ConsoleColor.Cyan;

            GameLoop();
        }

        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.W:
                    if (_myWorld.IsWalkable(_currentPlayer.X, _currentPlayer.Y - 1))
                    {
                        _currentPlayer.Y -= 1;
                        PendingMovement = true;
                    }
                    break;

                case ConsoleKey.A:
                    if (_myWorld.IsWalkable(_currentPlayer.X - 1, _currentPlayer.Y))
                    {
                        _currentPlayer.X -= 1;
                        PendingMovement = true;
                    }
                    break;

                case ConsoleKey.S:
                    if (_myWorld.IsWalkable(_currentPlayer.X, _currentPlayer.Y + 1))
                    {
                        _currentPlayer.Y += 1;
                        PendingMovement = true;
                    }
                    break;

                case ConsoleKey.D:
                    if (_myWorld.IsWalkable(_currentPlayer.X + 1, _currentPlayer.Y)) _currentPlayer.X += 1;
                    break;
            }

        }

        public void Frame()
        {
            _myWorld.Draw();
            _currentPlayer.Draw();
            _currentEnemy.Draw();
        }

        public void EnemyMovement()
        {
            Thread.Sleep(500);
            _currentEnemy.X++;
            Frame();
            Thread.Sleep(500);
            _currentEnemy.X++;
            Frame();
            Thread.Sleep(500);
            _currentEnemy.X++;
            Frame();
            Thread.Sleep(500);
            _currentEnemy.X++;
            Frame();
            Thread.Sleep(500);
            _currentEnemy.X++;
            Frame();
            Thread.Sleep(500);
            _currentEnemy.X++;
            Frame();

        }
        private void GameLoop()
        {
            Task.Run(EnemyMovement);
            
            while (true)
            {
                Frame();
                HandleInput();
            }
        }
    }
}
