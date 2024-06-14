using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace SnakeGame
{

    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(100, 100);

            Console.WriteLine("\t\t\t\t Welcome to my snake game");
            Console.WriteLine("W S, D, A tugmalari orqali * ni siljiting " +
                                "  chiqish uchun Escape " +
                                "Counter dagidek hammasi ");
            Console.WriteLine(Environment.NewLine);

            int balandlik = 25;
            int kenglik = 50;
            // bizga kerak bo'ladigan maydonni belgilab chizib olamiz.
            try
            {
                for (int height = 0; height < balandlik; height++)
                {
                    for (int width = 0; width < kenglik; width++)
                    {
                        if (height == 0)
                        {
                            Console.Write("` ");
                        }
                        else if (width == 0 && height != 0)
                        {
                            Console.Write("` ");
                        }
                        if (height == balandlik - 1 && width != 0)
                        {
                            Console.Write("` ");
                        }

                        else if (height != 0 && height != balandlik - 1 && width != 0 && width != kenglik - 1)
                        {
                            Console.Write("  ");
                        }
                        else if (width == kenglik - 1 && height != 0 && height != balandlik - 1)
                        {
                            Console.Write("` ");
                        }

                    }
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a numeric value.");
            }

            int x = 9;  // Boshlang'ich x koordinatasi 
            int y = 9; // Boshlang'ich y koordinatasi

            bool running = true;
            int dx = 0;
            int dy = 0;
            Console.CursorVisible = false;

            Random random = new Random();
            int randomX = random.Next(6, 80);
            int randomY = random.Next(8, 30);

            while (running)
            {
                // yeyish uchun olma
                Console.SetCursorPosition(randomX, randomY);
                Console.Write("+");

                // Belgini yangi joylashuvda chiqarish
                Console.SetCursorPosition(x, y);
                Console.Write("o ");

                Console.SetCursorPosition(x - dx, y - dy);
                Console.Write(" ");

                
                // Foydalanuvchi kirishini tekshirish
                if (Console.KeyAvailable)
                {
                    
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.A:
                            dx = -1;
                            dy = 0;
                            break;
                        case ConsoleKey.D:
                            dx = 1;
                            dy = 0;
                            break;
                        case ConsoleKey.W:
                            dx = 0;
                            dy = -1;
                            break;
                        case ConsoleKey.S:
                            dx = 0;
                            dy = 1;
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            running = false;
                            Console.CursorVisible = true;
                            break;
                    }
                }

                // Harakatni yangilash
                x += dx;
                y += dy;

                // Chegaralarni tekshirish
                if (x <= 1)
                {
                    running = false;
                    Console.CursorVisible = true;
                    Console.WriteLine("you lose");
                };
                if (y <= 4)
                {
                    running = false;
                    Console.CursorVisible = true;
                    Console.WriteLine("you lose");
                };
                if (x > Console.WindowWidth - 3)
                {
                    running = false;
                    Console.CursorVisible = true;
                    Console.WriteLine("you lose");
                };
                if (y > balandlik + 2)
                {
                    running = false;
                    Console.CursorVisible = true;
                    Console.WriteLine("you lose");
                };

                // Kichik kutish
                Thread.Sleep(190);

            }
        }
    }
}
