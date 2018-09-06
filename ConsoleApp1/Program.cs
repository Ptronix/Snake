using System;

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
            m.ScoreSpeedLabel();

            do
            {
                if (Console.KeyAvailable) snake.MoveSnake(m);

            } while (m.SnakeIsALive);
        }   
    }
}
