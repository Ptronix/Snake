﻿using System;

namespace SnakeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(83, 25);
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine(Console.WindowHeight);

            Matchfield m = new Matchfield();
            m.DrawBorders();
            Snake snake = new Snake(m);
            snake.InitializeSnake(m);
            m.DropItems();

            while (m.SnakeIsALive)
            {
                
                snake.MoveSnake(m);
                snake.DeleteLastPart();
                snake.CheckCollision(m);
                snake.DrawSnake(m);
                snake.CheckBerryMatch(m);

                //snake.MoveSnake(m);
                //Als eigener thread, der alle x ms sekunden ausgeführt wird...
                //snake.MoveSnake(m);
            }
        }
    }
}
