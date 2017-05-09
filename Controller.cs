using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.V2
{
    class Controller
    {
        public const int LEFT = 1, UP = 2, RIGHT = 3, DOWN = 4, ENTER = 5, ESC = -1, RESET = 9;
        public Controller()
        {
            //todo
        }
        public static int ListenInputKeys()
        {
            int readKeyValue = 0;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        readKeyValue = UP;
                        break;
                    case ConsoleKey.DownArrow:
                        readKeyValue = DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        readKeyValue = LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        readKeyValue = RIGHT;
                        break;
                    case ConsoleKey.Enter:
                        readKeyValue = ENTER;
                        break;
                    case ConsoleKey.Escape:
                        readKeyValue = ESC;
                        break;
                    case ConsoleKey.R:
                        readKeyValue = RESET;
                        break;
                    default:
                        Display.WrongInput();
                        break;
                }
            }
            return readKeyValue;
            //throw new NotImplementedException();
        }
    }
}
