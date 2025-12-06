using System;
using System.ComponentModel;

namespace Main
{
    public class Day6
    {
        List<(int number, int index)> computeList = new List<(int number, int index)>();

        List<(char mathType, int index)> mathList = new List<(char mathType, int index)>();

        long total = 0;
        public void Main()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Tim\\code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day6.txt");

            //StreamReader sr = new StreamReader("C:\\Users\\Tim\\code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day6 - Test.txt");

            string line = sr.ReadLine();

            //P1
            //while (line != null)
            //{
            //    string[] parsed = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    for (int i = 0; i < parsed.Length; i++)
            //    {
            //        if (parsed[i][0] == '+' || parsed[i][0] == '*')
            //        {
            //            mathList.Add((parsed[i][0], i));
            //            continue;
            //        }


            //        computeList.Add((Int32.Parse(parsed[i]), i));
            //    }

            //    line = sr.ReadLine();
            //}

            //P2
            List<string> numberLines = new List<string>();

            while (line != null)
            {
                if (line[0] != '+' && line[0] != '*')
                {
                    numberLines.Add(line);
                    line = sr.ReadLine();
                    continue;
                }

                string[] strings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strings.Length; i++)
                {
                    mathList.Add((strings[i][0], i));
                }

                line = sr.ReadLine();
            }


            //P2
            int count = 0;
            for (int i = 0; i < numberLines[0].Length; i++)
            {
                string sNumber = "";
                for (int j = 0; j < numberLines.Count; j++)
                {
                    sNumber += numberLines[j][i];
                }

                string[] test = sNumber.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (test.Length == 0)
                {

                    count++;
                    continue;
                }

                computeList.Add((Int32.Parse(sNumber), count));


            }


            ProcessP1();
            //ProcessP2();

            Console.WriteLine("total: " + total);

            sr.Close();
        }


        private void ProcessP1()
        {
            for (int i = 0; i < mathList.Count; i++)
            {
                long lineTotal = 0;
                for (int j = 0; j < computeList.Count; j++)
                {
                    if (mathList[i].index == computeList[j].index)
                    {
                        Console.WriteLine("value: " + computeList[j].number + ", LineTotal: " + lineTotal + ", MathType: " + mathList[i].mathType);

                        if (mathList[i].mathType == '+')
                        {
                            lineTotal += computeList[j].number;
                        }
                        else if (mathList[i].mathType == '*')
                        {
                            if (lineTotal == 0)
                            {
                                lineTotal++;
                            }
                            lineTotal *= computeList[j].number;
                        }
                    }
                }
                total += lineTotal;
            }
        }

        private void ProcessP2()
        {
            for (int i = 0; i < mathList.Count; i++)
            {
                long lineTotal = 0;
                for (int j = 0; j < computeList.Count; j++)
                {
                    if (mathList[i].index == computeList[j].index)
                    {
                        Console.WriteLine("value: " + computeList[j].number + ", LineTotal: " + lineTotal + ", MathType: " + mathList[i].mathType);

                        if (mathList[i].mathType == '+')
                        {
                            lineTotal += computeList[j].number;
                        }
                        else if (mathList[i].mathType == '*')
                        {
                            if (lineTotal == 0)
                            {
                                lineTotal++;
                            }
                            lineTotal *= computeList[j].number;
                        }
                    }
                }
                total += lineTotal;
            }
        }
    }
}
