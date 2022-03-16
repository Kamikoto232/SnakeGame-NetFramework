using System;

namespace SnakeGameFramework
{
    public readonly struct Pixel
    {
        public const char PixelChar = '█';

        public Pixel(short x, short y, ConsoleColor color, short pixelSize = 3)
        {
            Position = new Vector2(x, y);
            Color = color;
            PixelSize = pixelSize;
        }

        public Vector2 Position { get; }
        public short PixelSize { get; }
        public ConsoleColor Color { get; }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((Position.X * PixelSize) + x, (Position.Y * PixelSize) + y);
                    Console.Write(PixelChar);
                }
            }
        }

        public void Clear()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((Position.X * PixelSize) + x, (Position.Y * PixelSize) + y);
                    Console.Write(' ');
                }
            }
        }
    }
}