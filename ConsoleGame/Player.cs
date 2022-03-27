using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;

        public Player(int startingX, int startingY)
        {
            X = startingX;
            Y = startingY;
            PlayerMarker = "Ø";
            PlayerColor = ConsoleColor.DarkRed;

        }

        public void DrawPlayer()
        {
            Console.ForegroundColor = PlayerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
    }
}
