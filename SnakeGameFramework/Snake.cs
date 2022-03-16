using System;
using System.Collections.Generic;

namespace SnakeGameFramework
{
    internal class Snake
    {
        private readonly ConsoleColor headColor;
        private readonly ConsoleColor bodyColor;

        public Snake(short initalX, short initalY, ConsoleColor headColor, ConsoleColor bodyColor, short bodyLenght = 3)
        {
            this.headColor = headColor;
            this.bodyColor = bodyColor;

            Head = new Pixel(initalX, initalY, headColor);

            for (short i = bodyLenght; i >= 0; i--)
            {
                Body.Enqueue(new Pixel((short)(Head.Position.X - i - 1), initalY, bodyColor));
            }

            Draw();
        }

        public Pixel Head { get; private set; }

        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        public void Draw()
        {
            Head.Draw();

            foreach (var pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (var pixel in Body)
            {
                pixel.Clear();
            }
        }

        public void Move(Direction dir, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.Position.X, Head.Position.Y, bodyColor));

            if (!eat)
                Body.Dequeue();

            switch (dir)
            {
                case Direction.Right:
                    Head = new Pixel((short)(Head.Position.X + 1), Head.Position.Y, headColor);
                    break;

                case Direction.Left:
                    Head = new Pixel((short)(Head.Position.X - 1), Head.Position.Y, headColor);
                    break;

                case Direction.Up:
                    Head = new Pixel(Head.Position.X, (short)(Head.Position.Y - 1), headColor);
                    break;

                case Direction.Down:
                    Head = new Pixel(Head.Position.X, (short)(Head.Position.Y + 1), headColor);
                    break;
            }

            Draw();
        }
    }
}