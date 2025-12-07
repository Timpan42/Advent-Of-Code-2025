using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
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

            ProcessP1();

            (int Y, int X) start = (0, 0);

            for (int i = 0; i < grid.GetUpperBound(1); i++)
            {
                if (grid[0, i] == 'S')
                {
                    start = (0, i);
                }
            }

            totalSplits = ProcessP2(start.Y, start.X);

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
                    //totalSplits++;
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

        private int ProcessP2(int Y, int X)
        {
            int val = 0;
            if (Y == grid.GetUpperBound(0) - 1)
            {
                return 1;
            }

            if (grid[Y, X] == '|' || grid[Y, X] == 'S')
            {
                return ProcessP2(Y + 1, X);
            }
            else if (grid[Y, X] == '^')
            {
                val += ProcessP2(Y, X - 1);
                val += ProcessP2(Y, X + 1);
            }

            return val;

        }

    }
}
