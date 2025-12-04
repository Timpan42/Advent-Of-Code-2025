using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Day4
    {
        char[,] grid;

        List<(int Y, int X)> coordList = new List<(int Y, int X)>();
        int ammountRemoved = 0;

        (int Y, int X)[] indexingValue =
        {
            (-1,-1), (-1, 0), (-1, 1),
            (0,-1), (0, 1),
            (1,-1), (1, 0), (1, 1),
        };

        public void Main()
        {
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day4.txt");
            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day4 - Test.txt");

            string line = sr.ReadLine();

            grid = new char[line.Length, line.Length];

            int loopIndexY = 0;
            while (line != null)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    grid[loopIndexY, x] = line[x];
                }

                loopIndexY++;
                line = sr.ReadLine();

            }


            // P1 & P2
            ProcessGridP1();
            ChangeGrid();

            // P2
            while (coordList.Count != 0)
            {
                coordList.Clear();
                ProcessGridP1();
                ChangeGrid();
            }

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                string test = "";
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    test += grid[y, x];
                }
                Console.WriteLine(test);
            }
            // P1
            //Console.WriteLine('\n' + "Amount of X: " + coordList.Count);

            // P2
            Console.WriteLine('\n' + "Amount of X: " + ammountRemoved);

        }

        private void ProcessGridP1()
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y, x] != '@')
                    {
                        continue;
                    }
                    int count = 0;
                    for (int i = 0; i < indexingValue.Length; i++)
                    {
                        int indexY = y + indexingValue[i].Y;
                        int indexX = x + indexingValue[i].X;

                        if (indexY < 0 || indexY > grid.GetLength(0) - 1 ||
                            indexX < 0 || indexX > grid.GetLength(1) - 1)
                        {
                            continue;
                        }

                        if (grid[indexY, indexX] == '@')
                        {
                            count++;
                        }
                    }

                    if (count < 4)
                    {
                        coordList.Add((y, x));
                    }
                }
            }
        }

        private void ChangeGrid()
        {
            foreach (var coordinate in coordList)
            {
                grid[coordinate.Y, coordinate.X] = 'X';
            }

            //P2
            ammountRemoved += coordList.Count;
        }
    }

}
