using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeApp
{
   public class Snake
    {//private set
        public  int Xpos { get; private set; }
        public int Ypos { get; private set; }
        public char BodyPart = 'o';
        public char Head = 'O';
        public bool isKeyAvailable = false;
        public string lastKey;
        public ConsoleKey keyPressed = ConsoleKey.UpArrow;
        public List<int> XposBody = new List<int>();
        public List<int> YposBody = new List<int>();
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left,
        }

        //standard direction
       public Direction direction = Direction.Up; 


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
                m.Speed -= 50;
                m.DropItems();
                AppendBlock();
            }
        }
        public void AppendBlock()
        {
            switch (direction)
            {
                case Direction.Up:
                    XposBody.Add(XposBody[XposBody.Count - 1]);
                    YposBody.Add(YposBody[YposBody.Count - 1] + 1);
                    break;

                case Direction.Down:
                    XposBody.Add(XposBody[XposBody.Count - 1]);
                    YposBody.Add(YposBody[YposBody.Count - 1] + 1);
                    break;

                case Direction.Left:
                    XposBody.Add(XposBody[XposBody.Count - 1] +1);
                    YposBody.Add(YposBody[YposBody.Count - 1]);
                    break;

                case Direction.Right:
                    XposBody.Add(XposBody[XposBody.Count - 1] + 1);
                    YposBody.Add(YposBody[YposBody.Count - 1] );
                    break;
            }
        }

        public void DrawSnake(Matchfield m)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(XposBody[0], YposBody[0]);
            Console.Write("{0}", Head);

            for (var xPosition =1; xPosition < XposBody.Count ; xPosition++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                for (var yPosition = 1; yPosition < YposBody.Count ; yPosition++)
                {
                    Console.SetCursorPosition(XposBody[xPosition],YposBody[yPosition]);
                    Console.Write("{0}", BodyPart);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void CheckCollision(Matchfield m)
        {
            //if (XposBody[0] <= 0 || XposBody[0] >= 81 || YposBody[0] <= 0 || YposBody[0] >= 21 )
            if (XposBody[0] <= 0 || XposBody[0] >= 81 || YposBody[0] <= 0 || YposBody[0] >= 21)
            {
                Console.SetCursorPosition(30, 22);
                Console.WriteLine("Game Over!");
                m.SnakeIsALive = false;
            }
        }
               
        public void MoveSnake(Matchfield m)
        {
          do
            {
                if (Console.KeyAvailable)
                {
                   keyPressed = Console.ReadKey().Key;
                }
                
                //Move Up y-1
                if (keyPressed == ConsoleKey.UpArrow && direction != Direction.Down)
                {
                    direction = Direction.Up;

                    YposBody.Insert(0, YposBody[0] - 1);
                    XposBody.Insert(0, XposBody[0]);

                    DeleteLastPart();
                }
                //Move Down = y+1
                else if (keyPressed == ConsoleKey.DownArrow && direction != Direction.Up)
                {
                    direction = Direction.Down;

                    YposBody.Insert(0, YposBody[0] + 1);
                    XposBody.Insert(0, XposBody[0]);
                    DeleteLastPart();

                }
                //MoveLeft = x-1
                else if (keyPressed == ConsoleKey.LeftArrow && direction != Direction.Right)
                {
                    direction = Direction.Left;
                    
                    YposBody.Insert(0, YposBody[0]);
                    XposBody.Insert(0, XposBody[0] - 1);
                    DeleteLastPart();
                }
                //MoveRight = x+1
                else if (keyPressed == ConsoleKey.RightArrow && direction != Direction.Left)
                {
                    direction = Direction.Right;
                   
                    YposBody.Insert(0, YposBody[0]);
                    XposBody.Insert(0, XposBody[0] + 1);
                    DeleteLastPart();
                }
                
                DrawSnake(m);
               // DeleteLastPart();
                CheckCollision(m);
                CheckBerryMatch(m);
                m.ScoreSpeedLabel();

                System.Threading.Thread.Sleep(m.Speed);

            } while (m.SnakeIsALive);

            Console.ReadLine();
                
        }

        public void DeleteLastPart()
        {
            Console.SetCursorPosition(XposBody[XposBody.Count - 1], YposBody[YposBody.Count - 1]);
            Console.WriteLine(" ");
            //delete last element count-1 because starts at 0
            XposBody.RemoveAt(XposBody.Count - 1);
            YposBody.RemoveAt(YposBody.Count - 1);
        }
    }
}
