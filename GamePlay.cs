using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sokoban.V2
{
    class GamePlay
    {
        public static BoxMan boxman;
        const int delay = 120;
        public GamePlay()
        {
            //todo
        }
        
        public static int Play()
        {
            int command, returnValue = 0;
            //todo
            Display.Clear();
            Display.DrawMap(Level.map);
            ScanBoxManPos(Level.map);   
            do
            {
                command = Controller.ListenInputKeys();
                boxman.CheckMovement(command);
                if(IsLevelDone(Level.map))
                {
                    returnValue = Level.PASSED;
                    break;
                }
                if(command == Controller.RESET)
                {
                    returnValue = Level.RESETED;
                    break;
                }
                Display.DrawMap(Level.map);
                Thread.Sleep(delay);
            } while (command != Controller.ESC);
            return returnValue;
        }





        private static void ScanBoxManPos(int[,] gmap)
        {
            for(int i = 0; i < Level.height; i++)
            {
                for(int j = 0; j < Level.width; j++)
                {
                    if (Level.BOXMAN == gmap[i, j] || Level.FBOXMAN == gmap[i, j])
                        boxman = new BoxMan(i, j);
                }
            }
        }

        private static bool IsLevelDone(int[,] gmap)
        {
            int countOfFlag = 0;
            for (int x = 0; x < Level.height; x++)
            {
                for (int y = 0; y < Level.width; y++)
                {
                    if (Level.FLAG == gmap[x, y] || Level.FBOXMAN == gmap[x, y])
                        countOfFlag++;
                }
            }
            if (countOfFlag == 0)
                return true;
            else
                return false;
        }
    }
}
