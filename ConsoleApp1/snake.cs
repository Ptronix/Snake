using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeApp
{
   public class Snake
    {//private set
        public  int Xpos { get; private set; }
        public int Ypos { get; private set; }
        public char BodyPart = 'X';
        public char Head = '0';

        public List<int> XposBody = new List<int>();
        public List<int> YposBody = new List<int>();
        public string lastMove;

        public Snake(Matchfield m)
        {
            
        }
        /// <summary>
        /// Width in fields 22 Snake in range 1-19
        /// heigth in fields 42 Snake 1-41
        /// Border x,y index 0
        /// Otherwise GAME OVER
        /// </summary>

        public void InitializeSnake(Matchfield m)
        {
            YposBody.Insert(0, m.Height / 2);
            XposBody.Insert(0, m.Length / 2);

            //start at the middle of the matchfield
            Console.SetCursorPosition(XposBody[0],YposBody[0]);
            Console.WriteLine("{0}",Head);
        }

        public void CheckBerryMatch(Matchfield m)
        {
            
            if ( XposBody.Contains(m.xRandom) && YposBody.Contains(m.yRandom) )
            {
                m.Score += 10;
                Console.SetCursorPosition(1,23);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Score: {0}",m.Score);
                m.DropItems();
                AppendBlock();
            }
        }
        public void AppendBlock()
        {
            switch (lastMove)
            {
                case "up":
                    XposBody.Add(XposBody[XposBody.Count - 1]);
                    YposBody.Add(YposBody[YposBody.Count - 1] + 1);
                    break;

                case "down":
                    XposBody.Add(XposBody[XposBody.Count - 1]);
                    YposBody.Add(YposBody[YposBody.Count - 1] + 1);
                    break;

                case "left":
                    XposBody.Add(XposBody[XposBody.Count - 1] +1);
                    YposBody.Add(YposBody[YposBody.Count - 1]);
                    break;

                case "right":
                    XposBody.Add(XposBody[XposBody.Count - 1]);
                    YposBody.Add(YposBody[YposBody.Count - 1] + 1);
                    break;
            }
        }

        public void DrawSnake(Matchfield m)
        {
          
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var xPosition in XposBody)
            {
                foreach (var yPosition in YposBody)
                {
                    Console.SetCursorPosition(xPosition, yPosition);
                    Console.Write("{0}", BodyPart);
                   
                    
                }
            }
        }
        public void CheckCollision(Matchfield m)
        {
            //if (XposBody[0] <= 0 || XposBody[0] >= 81 || YposBody[0] <= 0 || YposBody[0] >= 21 )
            if (XposBody[0] <= 0 || YposBody[0] >= 21)
            {
                Console.SetCursorPosition(30, 22);
                Console.WriteLine("Game Over!");
                m.SnakeIsALive = false;
                Console.WriteLine();
            }
        }
               
        public void MoveSnake(Matchfield m)
        {
            ConsoleKey keyPressed = Console.ReadKey().Key;

            //Move Up y-1
            if (keyPressed == ConsoleKey.UpArrow)
            {
                lastMove = "up";

                int yPositionToAttend = YposBody[0];
                int xPositionToAttend = XposBody[0];

                YposBody.Insert(0, yPositionToAttend-1);
                XposBody.Insert(0, xPositionToAttend);

                DeleteLastPart();
                CheckCollision(m);
                DrawSnake(m);
                CheckBerryMatch(m);
                MoveSnake(m);
                CheckCollision(m);

            }
            //Move Down = y+1
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                lastMove = "down";

                int yPositionToAttend = YposBody[0];
                int xPositionToAttend = XposBody[0];

                YposBody.Insert(0, yPositionToAttend + 1);
                XposBody.Insert(0, xPositionToAttend);
                DeleteLastPart();
                CheckCollision(m);
                DrawSnake(m);
                CheckBerryMatch(m);
                
                MoveSnake(m);
                CheckCollision(m);
            }
            //MoveLeft = x-1
            else if  (keyPressed == ConsoleKey.LeftArrow)
            {
                lastMove = "left";
                int yPositionToAttend = YposBody[0];
                int xPositionToAttend = XposBody[0];

                YposBody.Insert(0, yPositionToAttend);
                XposBody.Insert(0, xPositionToAttend - 1);

                DeleteLastPart();
                CheckCollision(m);
                DrawSnake(m);
                CheckBerryMatch(m);
                
                MoveSnake(m);
                CheckCollision(m);

            }
            //MoveRight = x+1
            else if (keyPressed == ConsoleKey.RightArrow)
            {
                lastMove = "right";
                int yPositionToAttend = YposBody[0];
                int xPositionToAttend = XposBody[0];

                YposBody.Insert(0, yPositionToAttend);
                XposBody.Insert(0, xPositionToAttend + 1);

                DeleteLastPart();
                CheckCollision(m);
                DrawSnake(m);
                CheckBerryMatch(m);
                
                MoveSnake(m);
                CheckCollision(m);
            }
            
        }

        public void DeleteLastPart()
        {
            Console.SetCursorPosition(XposBody[XposBody.Count - 1], YposBody[YposBody.Count - 1]);
            Console.Write(" ");
            //delete last element count-1 because starts at 0
            XposBody.RemoveAt(XposBody.Count - 1);
            YposBody.RemoveAt(YposBody.Count - 1);
        }
    }
}
