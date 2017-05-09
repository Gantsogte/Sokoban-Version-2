using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sokoban.V2
{
    class Display
    {
        public const int NEWGAME = 0, EXIT = 3, delay = 100, LongDelay = 3000;
        public static int chosenItem = 0, returnItem;       //default New Game
        public static int chosenLevel = 0, returnLevel;     //default Level 1
        const int FirstLine = 2, LastLineMenu = 5, LastLineLevel = 6, HeaderSpace = 2;
        public Display()
        {
            //todo
        }

        public static int ShowMenu()
        {
            MenuHeader();
            String[] menuItem = { "New Game", "Choose Level", "Credits", "Exit" };
            int userInput;

            do
            {
                userInput = Controller.ListenInputKeys();
                switch (userInput)
                {
                    case Controller.UP:
                        chosenItem--;
                        if (chosenItem < NEWGAME)
                            chosenItem = NEWGAME;
                        break;
                    case Controller.DOWN:
                        chosenItem++;
                        if (chosenItem > EXIT)
                            chosenItem = EXIT;
                        break;
                    case Controller.ENTER:
                        returnItem = chosenItem;
                        break;
                }

                for (int i = FirstLine; i <= LastLineMenu; i++)
                {
                    if (chosenItem == i - HeaderSpace)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(menuItem[i - HeaderSpace]);
                }

                Thread.Sleep(delay);
            } while (userInput != Controller.ENTER);
            return returnItem;
        }
        
        public static int ChooseLevel()
        {
            MenuHeader();
            String[] levelItem = { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5"};
            int userInput;
            do
            {
                userInput = Controller.ListenInputKeys();
                switch (userInput)
                {
                    case Controller.UP:
                        chosenLevel--;
                        if (chosenLevel < Level.LEVEL1)
                            chosenLevel = Level.LEVEL1;
                        break;
                    case Controller.DOWN:
                        chosenLevel++;
                        if (chosenLevel > Level.LEVEL5)
                            chosenLevel = Level.LEVEL5;
                        break;
                    case Controller.ENTER:
                        returnLevel = chosenLevel;
                        break;
                }

                for (int i = FirstLine; i <= LastLineLevel; i++)
                {
                    if (chosenLevel == i - HeaderSpace)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(levelItem[i - HeaderSpace]);
                }
                if (userInput == Controller.ESC)
                {
                    returnLevel = Controller.ESC;
                    goto there;
                }
                Thread.Sleep(delay);
            } while (userInput != Controller.ENTER);
            there:
            return returnLevel;
        }
        
        public static void ShowCredits()
        {
            do
            {
                Console.SetCursorPosition(0, HeaderSpace);
                Console.WriteLine("E.Gantsogt   ---->>>   J.SE13D017\n" +
                                  "MUST         ---->>>   SICT\n" +
                                  "2017         ---->>>   SE302\n" +
                                  "Press Esc to return");
            } while (Controller.ListenInputKeys() != Controller.ESC);
        }

        public static void Congratulation()
        {
            MenuHeader();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(0,HeaderSpace);
            Console.WriteLine("Congratulations, You won the GAME");
            Thread.Sleep(LongDelay);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void WrongInput() {
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("Wrong Input !!!");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("Up, left, right, down arrow keys to control \n, R to reset Esc to escape");
        }

        public static void DrawMap(int[,] map)
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Moves : " + BoxMan.MOVES.ToString());

            for (int x = 0; x < Level.height; x++)
            {
                for (int y = 0; y < Level.width; y++)
                {
                    if (Level.EMPTY == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine((char)2);
                    }
                    if (Level.WALL == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine((char)2);
                    }
                    if (Level.FLAG == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine((char)2);
                    }
                    if (Level.FBOX == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine((char)2);
                    }
                    if (Level.BOX == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine((char)2);
                    }
                    if (Level.BOXMAN == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine((char)2);
                    }
                    if (Level.FBOXMAN == map[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine((char)2);
                    }
                }
            }
        }

        private static void MenuHeader()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("The Sokoban .V2");
        }
    }
}
