using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblemSolving
{
    class Dijkstra_Chess
    {
        static int I = 8 * 8;
        const int TH_Sleep = 900;
        static void Main(string[] args)
        {
            PlayHourses2D(0, 0);
        }

        private static void PlayHourses2D(int x, int y)
        {
            var area = Chess_2D.Read(8, 8);

            (int x, int y)[] dx_2D = new[]
            {
                (-1, +2), // A      - - - - - - - -
                (+1, +2), // B      - - G - H - - -
                (+2, +1), // C      - F - - - A - -
                (+2, -1), // D      - - - S - - - -
                (+1, -2), // E      - E - - - B - -
                (-1, -2), // F      - - D - C - - -
                (-2, -1), // G      - - - - - - - -
                (-2, +1), // H      - - - - - - - -
            };

            Queue<(int x, int y)> q = new Queue<(int x, int y)>();
            //bool[,] visited = new bool[8, 8];
            Dictionary<(int x, int y), (int x, int y)> Parent = new Dictionary<(int x, int y), (int x, int y)>();

            Visit((x, y), area);
            q.Enqueue((x, y));
            Parent[(x, y)] = (x, y);

            Console.ReadLine();

            while (q.Count > 0)
            {
                (x, y) = q.Dequeue();
                area[x, y] = 'P';
                foreach ((int dx, int dy) in dx_2D)
                {
                    (int X, int Y) = (x + dx, y + dy);
                    if (X >= 0 && X < 8 && Y >= 0 && Y < 8 && area[X, Y] == '-')
                    {
                        area[X, Y] = '+';
                    }
                }

                Chess_2D.Plot(area);
                Thread.Sleep(TH_Sleep);

                foreach ((int dx, int dy) in dx_2D)
                {
                    (int X, int Y) = (x + dx, y + dy);
                    if (X >= 0 && X < 8 && Y >= 0 && Y < 8 && area[X, Y] == '+')
                    {
                        Visit((X, Y), area);

                        q.Enqueue((X, Y));
                        Parent[(X, Y)] = (x, y);
                    }
                }

                area[x, y] = '0';
            }
            Chess_2D.Plot(area);
            Thread.Sleep(TH_Sleep * 3);
        }

        private static void Visit((int x, int y) v, char[,] area)
        {
            (int x, int y) = (v.x, v.y);
            //area[p.x, p.y] = 'P';
            area[x, y] = 'S';
            //visited[x, y] = true;
            Chess_2D.Plot(area);
            area[x, y] = 'O';
            //area[p.x, p.y] = '0';
            Console.WriteLine($"\r\n[{--I}] tiles remaining ...");
            Thread.Sleep(TH_Sleep);
        }
    }
}