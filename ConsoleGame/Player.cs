using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        private string Marker;


        public Player(int startingX, int startingY)
        {
            X = startingX;
            Y = startingY;
            Marker = "@";
            Color = ConsoleColor.DarkRed;

        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Marker);
            Console.ResetColor();
        }
    }
}
