using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Day5
    {
        List<(long min, long max)> ranges = new List<(long min, long max)>();
        List<long> procesValues = new List<long>();
        List<long> freshItems = new List<long>();

        public void Main()
        {
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day5.txt");
            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day5Waa.txt");

            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day5 - Test.txt");

            string line = sr.ReadLine();

            bool addProcesValues = false;
            while (line != null)
            {
                bool ignoreValue = false;
                if (line == "")
                {
                    addProcesValues = true;
                    ignoreValue = true;
                }


                if (!ignoreValue)
                {

                    if (addProcesValues)
                    {
                        // getting values
                        procesValues.Add(Int64.Parse(line));
                    }
                    else
                    {
                        // getting ranges 
                        string[] splitRange = line.Split('-');
                        ranges.Add((Int64.Parse(splitRange[0]), Int64.Parse(splitRange[1])));
                    }
                }

                line = sr.ReadLine();
            }

            //ProcessP1();
            ProcessP2();


            sr.Close();


        }

        private void ProcessP1()
        {

            foreach (var value in procesValues)
            {
                foreach (var range in ranges)
                {
                    if (value >= range.min && value <= range.max)
                    {
                        freshItems.Add(value);
                        break;
                    }
                }
            }

            foreach (var item in freshItems)
            {
                Console.WriteLine("Fresh: " + item);
            }

            Console.WriteLine('\n' + "Total: " + freshItems.Count);

        }
        private void ProcessP2()
        {
            long totalFrechIds = 0;

            List<(long min, long max)> fixRanges = new List<(long min, long max)>();


            for (int i = 0; i < ranges.Count; i++)
            {
                if (fixRanges.Count == 0)
                {
                    fixRanges.Add(ranges[i]);
                    continue;
                }
                bool canAddRange = false;
                for (int j = 0; j < fixRanges.Count; j++)
                {
                    if (fixRanges[j].min >= ranges[i].min && fixRanges[j].max <= ranges[i].max)
                    {
                        fixRanges[j] = (0, 0);
                        canAddRange = true;
                    }

                    if (
                        ranges[i].min < fixRanges[j].min && ranges[i].max < fixRanges[j].max ||
                        ranges[i].min > fixRanges[j].min && ranges[i].max > fixRanges[j].max
                        )
                    {
                        canAddRange = true;
                    }

                    if (ranges[i].min >= fixRanges[j].min && ranges[i].max <= fixRanges[j].max)
                    {
                        canAddRange = false;
                        break;
                    }

                    if (ranges[i].min <= fixRanges[j].max && ranges[i].min >= fixRanges[j].min)
                    {
                        ranges[i] = (fixRanges[j].max + 1, ranges[i].max);
                        canAddRange = true;
                    }

                    if (ranges[i].max >= fixRanges[j].min && ranges[i].max <= fixRanges[j].max)
                    {
                        ranges[i] = (ranges[i].min, fixRanges[j].min - 1);
                        canAddRange = true;
                    }

                    if (ranges[i].min > ranges[i].max)
                    {
                        canAddRange = false;
                    }
                }

                if (canAddRange)
                {
                    fixRanges.Add(ranges[i]);
                }
                else
                {
                    (long min, long max) thing = ranges[i];
                }

            }

            foreach (var range in fixRanges)
            {
                Console.WriteLine(range.min + " - " + range.max);
                if (range.min != 0 && range.max != 0)
                {
                    totalFrechIds += range.max - range.min + 1;
                }
            }


            Console.WriteLine(fixRanges.Count);
            Console.WriteLine('\n' + "Total: " + totalFrechIds);
        }

        private void SuperBad()
        {
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day5Waa.txt");
            string line = sr.ReadLine();

            while (line != null)
            {
                long number = Int64.Parse(line);
            }



            sr.Close();


        }
    }
}
