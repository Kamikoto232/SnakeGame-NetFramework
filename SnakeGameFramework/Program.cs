using System.Threading;
using static System.Console;

namespace SnakeGameFramework
{
    internal static class Program
    {
        private static void Main()
        {
            InitalizeRender(SnakeGameManager.ScreenWidht, SnakeGameManager.ScreenHeight);
            while (true)
            {
                SnakeGameManager.GameLogic();

                Thread.Sleep(1000);
                ReadKey();
                Clear();
            }
        }

        private static void InitalizeRender(short w, short h)
        {
            SetWindowSize(w, h);
            SetBufferSize(w, h);
            CursorVisible = false;
        }
    }
}