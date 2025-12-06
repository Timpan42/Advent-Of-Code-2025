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
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day6.txt");

            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day6 - Test.txt");

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
            while (line != null)
            {
                string[] parsed = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parsed.Length; i++)
                {
                    if (parsed[i][0] == '+' || parsed[i][0] == '*')
                    {
                        mathList.Add((parsed[i][0], i));
                        continue;
                    }

                    computeList.Add((Int32.Parse(parsed[i]), i));

                    string wa = "";
                }

                line = sr.ReadLine();
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

        }
    }
}
