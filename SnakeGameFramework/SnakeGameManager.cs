using System;
using System.Diagnostics;
using System.Linq;
using static System.Console;

namespace SnakeGameFramework
{
    internal static class SnakeGameManager
    {
        public const short ScreenWidht = SnakeGameManager.MapWidht * 3;
        public const short ScreenHeight = SnakeGameManager.MapHeight * 3;

        public const short MapWidht = 30;
        public const short MapHeight = 20;

        private const ConsoleColor BorderColor = ConsoleColor.Gray;
        private const ConsoleColor HeadColor = ConsoleColor.Cyan;
        private const ConsoleColor BodyColor = ConsoleColor.Green;
        private const ConsoleColor FoodColor = ConsoleColor.Red;

        private const short FrameMs = 300;

        private static readonly Random Rand = new Random();

        private static short Score = 0;

        private static void DrawBorder()
        {
            for (short i = 0; i < MapWidht; i++)
            {
                new Pixel(i, 0, BorderColor).Draw();
                new Pixel(i, MapHeight - 1, BorderColor).Draw();
            }

            for (short i = 0; i < MapHeight - 1; i++)
            {
                new Pixel(0, i, BorderColor).Draw();
                new Pixel(MapWidht - 1, i, BorderColor).Draw();
            }
        }

        private static Pixel GetFood(Snake snake)
        {
            Pixel food;

            do
            {
                food = new Pixel((short)Rand.Next(1, MapWidht - 2), (short)Rand.Next(1, MapHeight - 2), FoodColor);
            } while ((snake.Head.Position == food.Position)
            || snake.Body.Any(b => b.Position == food.Position));

            food.Draw();

            return food;
        }

        private static Direction ReadDirection(Direction currDir)
        {
            if (!KeyAvailable)
                return currDir;

            switch (ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (currDir != Direction.Down) currDir = Direction.Up;
                    break;

                case ConsoleKey.LeftArrow:
                    if (currDir != Direction.Right) currDir = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    if (currDir != Direction.Left) currDir = Direction.Right;
                    break;

                case ConsoleKey.DownArrow:
                    if (currDir != Direction.Up) currDir = Direction.Down;
                    break;
            }

            return currDir;
        }

        public static void GameLogic()
        {
            DrawBorder();

            var snake = new Snake(10, 5, HeadColor, BodyColor);
            Score = 0;
            Direction currMovement = Direction.Right;
            Stopwatch sw = new Stopwatch();
            Pixel food = GetFood(snake);

            do
            {
                sw.Restart();
                while (sw.ElapsedMilliseconds <= FrameMs)
                {
                    currMovement = ReadDirection(currMovement);
                }

                if (snake.Head.Position == food.Position)
                {
                    snake.Move(currMovement, true);

                    food = GetFood(snake);
                    Score++;
                }
                else
                {
                    snake.Move(currMovement);
                }
            }
            while (CheckCollision(snake));

            snake.Clear();
            SetCursorPosition(ScreenWidht / 3, ScreenHeight / 3);
            WriteLine("GAME OVER Score:" + Score.ToString());
        }

        private static bool CheckCollision(Snake snake)
        {
            return snake.Head.Position.X != MapWidht - 1
                    && snake.Head.Position.X != 0
                    && snake.Head.Position.Y != MapHeight - 1
                    && snake.Head.Position.Y != 0
                    && !snake.Body.Any(b => b.Position == snake.Head.Position);
        }
    }
}