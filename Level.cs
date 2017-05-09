using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.V2
{
    class Level
    {
        /*FBOX =>> Туган дээр байгаа хайрцаг
         FBOXMAN =>> Туган дээр байгаа Boxman*/
        public const int WALL = 9, EMPTY = 0, FLAG = 1, BOX = 3, FBOX = 4, BOXMAN = 5, FBOXMAN = 6;
        public const int PASSED = 1, RESETED = 2;
        public const int LEVEL1 = 0, LEVEL2 = 1, LEVEL3 = 2, LEVEL4 = 3, LEVEL5 = 4, LASTLEVEL = 4;
        public static int[,] map;
        public static int height, width;

        public Level()
        {
            //todo
        }

        public static void LevelControl(int level)
        {
            switch (level)
            {
                case LEVEL1:
                    LevelOne();
                    BoxMan.MOVES = 0;
                    break;
                case LEVEL2:
                    LevelTwo();
                    break;
                case LEVEL3:
                    LevelThree();
                    break;
                case LEVEL4:
                    LevelFour();
                    break;
                case LEVEL5:
                    LevelFive();
                    break;
            }
            
            int result = GamePlay.Play();
            level++;
            if (result == PASSED)
            {
                if (level <= LASTLEVEL)
                {
                    LevelControl(level);
                }
                else
                {
                    Display.Congratulation();
                }
            }
            if(result == RESETED)
            {
                level--;
                LevelControl(level);
            }
        }
        
        private static void LevelOne()
        {
            height = 8;
            width = 8;
            map = new int[,]
            {
                {WALL, WALL, WALL,  WALL,   WALL,  WALL,  WALL, WALL},
                {WALL, WALL, WALL,  WALL,   FLAG,  WALL,  WALL, WALL},
                {WALL, WALL, WALL,  WALL,   EMPTY, WALL,  WALL, WALL},
                {WALL, FLAG, EMPTY, BOX,    BOX,   WALL,  WALL, WALL},
                {WALL, WALL, WALL,  BOXMAN, BOX,   EMPTY, FLAG, WALL},
                {WALL, WALL, WALL,  BOX,    WALL,  WALL,  WALL, WALL},
                {WALL, WALL, WALL,  FLAG,   WALL,  WALL,  WALL, WALL},
                {WALL, WALL, WALL,  WALL,   WALL,  WALL,  WALL, WALL}
            };
            //throw new NotImplementedException();
        }

        private static void LevelTwo()
        {
            height = 9;
            width = 9;
            map = new int[,]
            {
                {WALL, WALL,  WALL,  WALL,   WALL,  WALL,  WALL,  WALL,  WALL},
                {WALL, EMPTY, EMPTY, BOXMAN, WALL,  WALL,  WALL,  WALL,  WALL},
                {WALL, EMPTY, BOX,   BOX,    WALL,  WALL,  WALL,  WALL,  WALL},
                {WALL, EMPTY, BOX,   EMPTY,  WALL,  WALL,  WALL,  FLAG,  WALL},
                {WALL, WALL,  WALL,  EMPTY,  WALL,  WALL,  WALL,  FLAG,  WALL},
                {WALL, WALL,  WALL,  EMPTY,  EMPTY, EMPTY, EMPTY, FLAG,  WALL},
                {WALL, WALL,  EMPTY, EMPTY,  EMPTY, WALL,  EMPTY, EMPTY, WALL},
                {WALL, WALL,  EMPTY, EMPTY,  EMPTY, WALL,  WALL,  WALL,  WALL},
                {WALL, WALL,  WALL,  WALL,   WALL,  WALL,  WALL,  WALL,  WALL}
            };
            //throw new NotImplementedException();
        }

        private static void LevelThree()
        {
            height = 8;
            width = 6;
            map = new int[,]
            {
                {WALL, WALL,  WALL,   WALL,  WALL,  WALL},
                {WALL, WALL,  EMPTY,  EMPTY, WALL,  WALL},
                {WALL, EMPTY, BOXMAN, BOX,   WALL,  WALL},
                {WALL, WALL,  BOX,    EMPTY, WALL,  WALL},
                {WALL, WALL,  EMPTY,  BOX,   EMPTY, WALL},
                {WALL, FLAG,  BOX,    EMPTY, EMPTY, WALL},
                {WALL, FLAG,  FLAG,   FBOX,  FLAG,  WALL},
                {WALL, WALL,  WALL,   WALL,  WALL,  WALL}
            };
            //throw new NotImplementedException();
        }

        private static void LevelFour()
        {
            height = 8;
            width = 8;
            map = new int[,]
            {
                {WALL, WALL, WALL,   WALL,  WALL,  WALL,  WALL,  WALL},
                {WALL, WALL, BOXMAN, EMPTY, WALL,  WALL,  WALL,  WALL},
                {WALL, WALL, EMPTY,  BOX,   EMPTY, EMPTY, WALL,  WALL},
                {WALL, WALL, WALL,   EMPTY, WALL,  EMPTY, WALL,  WALL},
                {WALL, FLAG, WALL,   EMPTY, WALL,  EMPTY, EMPTY, WALL},
                {WALL, FLAG, BOX,    EMPTY, EMPTY, WALL,  EMPTY, WALL},
                {WALL, FLAG, EMPTY,  EMPTY, EMPTY, BOX,   EMPTY, WALL},
                {WALL, WALL, WALL,   WALL,  WALL,  WALL,  WALL,  WALL}
            };
            //throw new NotImplementedException();
        }

        private static void LevelFive()
        {
            height = 7;
            width = 8;
            map = new int[,]
            {
                {WALL, WALL,   WALL,  WALL, WALL,  WALL,  WALL,  WALL},
                {WALL, EMPTY,  EMPTY, WALL, EMPTY, EMPTY, EMPTY, WALL},
                {WALL, EMPTY,  BOX,   FLAG, FLAG,  BOX,   EMPTY, WALL},
                {WALL, BOXMAN, BOX,   FLAG, FBOX,  EMPTY, WALL,  WALL},
                {WALL, EMPTY,  BOX,   FLAG, FLAG,  BOX,   EMPTY, WALL},
                {WALL, EMPTY,  EMPTY, WALL, EMPTY, EMPTY, EMPTY, WALL},
                {WALL, WALL,   WALL,  WALL, WALL,  WALL,  WALL,  WALL}
            };
            //throw new NotImplementedException();
        }
    }
}
