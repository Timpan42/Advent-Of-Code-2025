using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Day7
    {
        char[,] grid = new char[143, 143];
        //char[,] grid = new char[17, 17];
        int totalSplits = 0;

        public void Main()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Tim\\code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day7.txt");
            //StreamReader sr = new StreamReader("C:\\Users\\Tim\\code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day7 - Test.txt");

            string line = sr.ReadLine();

            int loop = 0;
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    grid[loop, i] = line[i];
                }
                loop++;

                line = sr.ReadLine();
            }

            // ProcessP1();
            ProcessP2();

            for (int i = 0; i < grid.GetUpperBound(0); i++)
            {
                string row = "";
                for (int j = 0; j < grid.GetUpperBound(0); j++)
                {
                    row += grid[i, j];
                }
                Console.WriteLine(row);
            }

            Console.WriteLine('\n' + "Total: " + totalSplits);

            sr.Close();
        }

        private void ProcessP1()
        {
            HashSet<(int Y, int X)> indexesToAddLine = new HashSet<(int Y, int X)>();

            for (int i = 0; i < grid.GetUpperBound(0); i++)
            {
                WorkOn(ref indexesToAddLine);
                indexesToAddLine.Clear();


                for (int j = 0; j < grid.GetUpperBound(1); j++)
                {
                    if (grid[i, j] == 'S' || grid[i, j] == '|')
                    {
                        indexesToAddLine.Add((i + 1, j));
                        continue;
                    }
                }


            }
        }

        private void WorkOn(ref HashSet<(int Y, int X)> indexesToAddLine)
        {
            if (indexesToAddLine.Count <= 0)
            {
                return;
            }

            HashSet<(int Y, int X)> toAdd = new HashSet<(int Y, int X)>();

            foreach (var indexSet in indexesToAddLine)
            {
                if (grid[indexSet.Y, indexSet.X] == '^')
                {
                    totalSplits++;
                    if (!indexesToAddLine.Contains((indexSet.Y, indexSet.X + 1)) && !toAdd.Contains((indexSet.Y, indexSet.X + 1)))
                    {
                        toAdd.Add((indexSet.Y, (indexSet.X + 1)));
                    }
                    if (!indexesToAddLine.Contains((indexSet.Y, indexSet.X - 1)) && !toAdd.Contains((indexSet.Y, indexSet.X - 1)))
                    {
                        toAdd.Add((indexSet.Y, (indexSet.X - 1)));
                    }
                    continue;
                }


                if (grid[indexSet.Y, indexSet.X] == '.')
                {
                    grid[indexSet.Y, indexSet.X] = '|';
                }
            }

            indexesToAddLine.Clear();

            foreach (var item in toAdd)
            {
                indexesToAddLine.Add(item);
            }
            WorkOn(ref indexesToAddLine);
        }

        private void ProcessP2()
        {
            List<(int Y, int X)> indexesToAddLine = new List<(int Y, int X)>();

            for (int i = 0; i < grid.GetUpperBound(0); i++)
            {
                WorkOnP2(ref indexesToAddLine);
                indexesToAddLine.Clear();


                for (int j = 0; j < grid.GetUpperBound(1); j++)
                {
                    if (grid[i, j] == 'S' || grid[i, j] == '|')
                    {
                        indexesToAddLine.Add((i + 1, j));
                        continue;
                    }
                }


            }
        }

        private void WorkOnP2(ref List<(int Y, int X)> indexesToAddLine)
        {
            if (indexesToAddLine.Count <= 0)
            {
                return;
            }

            List<(int Y, int X)> toAdd = new List<(int Y, int X)>();

            foreach (var indexSet in indexesToAddLine)
            {
                if (grid[indexSet.Y, indexSet.X] == '^')
                {
                    totalSplits++;
                    toAdd.Add((indexSet.Y, (indexSet.X + 1)));
                    if (!indexesToAddLine.Contains((indexSet.Y, indexSet.X + 1)))
                    {
                    }
                    if (!indexesToAddLine.Contains((indexSet.Y, indexSet.X - 1)))
                    {
                    }
                    totalSplits++;

                    toAdd.Add((indexSet.Y, (indexSet.X - 1)));
                    continue;
                }

                if (grid[indexSet.Y, indexSet.X] == '.')
                {
                    grid[indexSet.Y, indexSet.X] = '|';
                }
            }



            indexesToAddLine.Clear();

            foreach (var item in toAdd)
            {
                indexesToAddLine.Add(item);
            }
            WorkOnP2(ref indexesToAddLine);
        }

    }
}
