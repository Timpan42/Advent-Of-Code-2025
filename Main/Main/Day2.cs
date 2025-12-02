
using System.Security.Cryptography;

namespace Main
{
    public class Day2()
    {
        long summeOfInvalidIds = 0;
        public void Main()
        {

            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day2.txt");
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day2.txt");



            String line = sr.ReadLine();

            while (line != null)
            {

                string[] ids = line.Split(",");

                //      ParsAndAddInvalidIdsP1(ref ids);
                ParsAndAddInvalidIdsP2(ref ids);



                line = sr.ReadLine();
            }
            sr.Close();

            Console.WriteLine(summeOfInvalidIds);
        }

        private void ParsAndAddInvalidIdsP1(ref string[] parString)
        {
            List<long> invalidIds = new List<long>();
            foreach (var idRange in parString)
            {
                string[] workRanges = idRange.Split("-");

                if (workRanges[0][0] == '0' || workRanges[1][0] == '0')
                {
                    Console.WriteLine("Invalid Id, skip");
                    continue;
                }

                long start = long.Parse(workRanges[0]);
                long maxRange = long.Parse(workRanges[1]);

                for (long i = start; i < maxRange + 1; i++)
                {
                    string a = i.ToString();

                    if (a.Length % 2 == 0)
                    {
                        int lenght = (a.Length / 2);


                        if (a.Substring(0, lenght) == a.Substring(lenght, a.Length - lenght))
                        {
                            invalidIds.Add(i);
                        }
                    }
                }
            }
            foreach (var item in invalidIds)
            {
                Console.WriteLine("Invalid: " + item);
                summeOfInvalidIds += item;
            }
        }
        private void ParsAndAddInvalidIdsP2(ref string[] parString)
        {
            List<long> invalidIds = new List<long>();
            foreach (var idRange in parString)
            {
                string[] workRanges = idRange.Split("-");

                if (workRanges[0][0] == '0' || workRanges[1][0] == '0')
                {
                    Console.WriteLine("Invalid Id, skip");
                    continue;
                }

                long start = long.Parse(workRanges[0]);
                long maxRange = long.Parse(workRanges[1]);

                for (long i = start; i < maxRange + 1; i++)
                {
                    string a = i.ToString();

                    if (a.Length < 2)
                    {
                        continue;
                    }

                    long sameCount = a.LongCount(c => c == a[0]);

                    if (sameCount == a.Length)
                    {
                        invalidIds.Add(i);
                        continue;
                    }

                    if (a.Length % 2 == 0)
                    {
                        int lenght = (a.Length / 2);

                        if (a.Substring(0, lenght) == a.Substring(lenght, a.Length - lenght))
                        {
                            invalidIds.Add(i);
                            continue;
                        }
                    }

                    string characterRepet = "";
                    bool stop = false;
                    for (int j = 0; j < a.Length - 1; j++)
                    {
                        if (stop)
                        {
                            break;
                        }

                        bool add = true;
                        for (int k = 0; k < characterRepet.Length; k++)
                        {
                            if (a[j] != characterRepet[k])
                            {
                                continue;
                            }
                            add = false;
                            stop = true;
                        }
                        if (add)
                        {
                            characterRepet += a[j];
                            continue;
                        }
                    }

                    if (characterRepet.Length < 2)
                    {
                        continue;
                    }

                    string[] sub = a.Split(characterRepet, StringSplitOptions.RemoveEmptyEntries);

                    if (sub.Length != 0)
                    {
                        continue;
                    }
                    invalidIds.Add(i);
                }
            }

            foreach (var item in invalidIds)
            {
                Console.WriteLine("Invalid: " + item);
                summeOfInvalidIds += item;
            }
        }
    }
}
