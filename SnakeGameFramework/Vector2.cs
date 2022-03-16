using System;

namespace SnakeGameFramework
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public short X;
        public short Y;

        public Vector2(short x, short y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Vector2 other)
        {
            return (X == other.X) && (Y == other.Y);
        }

        public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2((short)(vec1.X + vec2.X), (short)(vec1.Y + vec2.Y));
        }

        public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2((short)(vec1.X - vec2.X), (short)(vec1.Y - vec2.Y));
        }

        public static bool operator ==(Vector2 vec1, Vector2 vec2)
        {
            return (vec1.X == vec2.X) && (vec1.Y == vec2.Y);
        }

        public static bool operator !=(Vector2 vec1, Vector2 vec2)
        {
            return (vec1.X != vec2.X) || (vec1.Y != vec2.Y);
        }
    }
}