using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.V2
{
    class BoxMan
    {
        int posX, posY;
        public static int MOVES = 0;
        const int BOXMANPOWER = 5;

        public BoxMan(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }
        
        public void CheckMovement(int direction)
        {
            int nextX = this.posX, nextY = this.posY;
            int nextNextX = this.posX, nextNextY = this.posY;
            switch (direction)
            {
                case Controller.LEFT:
                    nextX--;
                    nextNextX -= 2;
                    break;
                case Controller.UP:
                    nextY--;
                    nextNextY -= 2;
                    break;
                case Controller.RIGHT:
                    nextX++;
                    nextNextX += 2;
                    break;
                case Controller.DOWN:
                    nextY++;
                    nextNextY += 2;
                    break;
            }
            int currentNode = Level.map[this.posX, this.posY];
            int nextNode = Level.map[nextX, nextY];
            int nextNextNode;
            if (nextNode != Level.WALL)
            {
                nextNextNode = Level.map[nextNextX, nextNextY];
                if (nextNode == Level.FLAG || nextNode == Level.EMPTY)
                {
                    MoveBoxMan(nextX, nextY);
                    MOVES++;
                }
                if(nextNode == Level.BOX || nextNode == Level.FBOX)
                {
                    if (BOXMANPOWER >= nextNode + nextNextNode)
                    {
                        PushBox(nextX, nextY, nextNextX, nextNextY);
                        MOVES++;
                    }
                }
            }
        }

        private void MoveBoxMan(int nextX, int nextY)
        {
            Level.map[this.posX, this.posY] -= Level.BOXMAN;
            Level.map[nextX, nextY] += Level.BOXMAN;
            this.posX = nextX;
            this.posY = nextY;
        }

        private void PushBox(int nextX, int nextY, int nextNextX, int nextNextY)
        {
            Level.map[this.posX, this.posY] -= Level.BOXMAN;
            Level.map[nextX, nextY] += (Level.BOXMAN - Level.BOX);
            Level.map[nextNextX, nextNextY] += Level.BOX;
            this.posX = nextX;
            this.posY = nextY;
        }
    }
}
