using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sokoban.V2
{
    class Game
    {
        static void Main(string[] args)
        {
            const int NEWGAME = 0, CHOOSELEVEL = 1, CREDITS = 2, EXIT = 3;
            showMainMenu:
            int userCommand = Display.ShowMenu();
            switch (userCommand)
            {
                case NEWGAME:
                    Level.LevelControl(NEWGAME);
                    goto showMainMenu;
                case CHOOSELEVEL:
                    int chosenLevel = Display.ChooseLevel();
                    if (chosenLevel >= 0)
                    {
                        Level.LevelControl(chosenLevel);
                        goto showMainMenu;
                    }
                    else
                        goto showMainMenu;
                case CREDITS:
                    Display.ShowCredits();
                    goto showMainMenu;
                case EXIT:
                    break;
            }
            //todo
        }
    }
}
