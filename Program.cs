using System;

namespace SudokuSolver
{
    class Program
    {
        static int[,] grid;
        static Random rnd;
        static ConsoleColor[] colors;
        static void Main(string[] args)
        {
            rnd = new Random();

            colors = new ConsoleColor[8]{
                ConsoleColor.White,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Magenta,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkBlue};

            grid = new int[9, 9]{
                {8,0,0,0,0,0,0,0,0},
                {0,0,3,6,0,0,0,0,0},
                {0,7,0,0,9,0,2,0,0},
                {0,5,0,0,0,7,0,0,0},
                {0,0,0,0,4,5,7,0,0},
                {0,0,0,1,0,0,3,0,0},
                {0,0,1,0,0,0,0,6,8},
                {0,0,8,5,0,0,0,1,0},
                {0,9,0,0,0,0,4,0,0}
                };

            Console.WriteLine();
            Solve();
        }

        Program()
        {


        }

        static bool Possible(int y, int x, int n)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[y, i] == n)
                    return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, x] == n)
                    return false;
            }
            int x0 = (x / 3) * 3;
            int y0 = (y / 3) * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[y0 + i, x0 + j] == n)
                        return false;
                }
            }
            return true;
        }

        static void Solve()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (grid[y, x] == 0)
                    {
                        for (int n = 1; n < 10; n++)
                        {
                            bool possible = Possible(y, x, n);
                            //Console.WriteLine($"{possible.ToString()} y = {y.ToString()}, x = {x.ToString()}");
                            if (possible)
                            {
                                grid[y, x] = n;

                                Solve();
                                grid[y, x] = 0;
                            }
                        }
                        //PrintGrid();
                        return;
                    }
                }

            }
            Console.Clear();
            PrintGrid();
        }

        static void PrintGrid()
        {
            ChangeColor();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grid[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        static void ChangeColor()
        {
            int colorNum = rnd.Next(colors.Length);
            Console.ForegroundColor = colors[colorNum];
        }
    }
}
