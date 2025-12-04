// See https://aka.ms/new-console-template for more information
using System.IO;

internal class Program
{

    static void Main(string[] args)
    {
        int currentValue = 50;
        int timesAtZero = 0;

        String line;
        char[] splitWords = ['L', 'R'];
        try
        {
            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Day 1\\Day 1\\Input.txt");
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Day 1\\Day 1\\Input2.txt");

            //StreamReader sr = new StreamReader("..\\Input.txt");
            line = sr.ReadLine();


            while (line != null)
            {
                bool isLeft = line.Contains('L');
                string[] split = line.Split(splitWords);

                if (isLeft)
                {
                    int value = Convert.ToInt32(split[1]) * -1;
                    //RotateP1(value);
                    RotateP2(value);
                }
                else
                {
                    int value = Convert.ToInt32(split[1]);
                    //RotateP1(value);

                    RotateP2(value);
                }


                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Value: " + timesAtZero);
        }

        void RotateP1(int value)
        {
            currentValue += value;

            while (currentValue < 0 || currentValue > 99)
            {
                if (currentValue > 99)
                {
                    currentValue = currentValue - 100;
                }

                if (currentValue < 0)
                {
                    currentValue = currentValue + 100;
                }
            }


            if (currentValue == 0)
            {
                timesAtZero++;
            }
        }

        void RotateP2(int value)
        {
            Console.WriteLine("Start: " + currentValue + ", value: " + value);
            bool SkipFirst = false;
            bool rotated = false;

            if (currentValue == 0)
            {
                SkipFirst = true;
            }

            if (value > 0)
            {
                currentValue += value;
                timesAtZero = timesAtZero + (value / 100);
                currentValue = currentValue % 100;
            }
            else
            {
                int oldValue = currentValue;
                currentValue -= Math.Abs(value);
                if (currentValue == 0)
                {
                    currentValue++;
                }
                if (currentValue < 0)
                {
                    if (oldValue != 0)
                    {
                        currentValue++;
                    }

                    timesAtZero = timesAtZero + ((Math.Abs(value) - oldValue) / 100);
                    currentValue = currentValue % 100;
                }
            }



            //currentValue += value;
            //while (currentValue < -99 || currentValue > 99)
            //{
            //    bool haveAdded = false;
            //    if (currentValue > 99)
            //    {
            //        if (SkipFirst == false)
            //        {

            //        }
            //        timesAtZero++;
            //        haveAdded = true;
            //        Console.WriteLine("Add 1");

            //        SkipFirst = false;
            //        currentValue = currentValue - 99;
            //        rotated = true;
            //    }

            //    if (currentValue < 0)
            //    {
            //        if (SkipFirst == false)
            //        {
            //            timesAtZero++;
            //            haveAdded = true;
            //            Console.WriteLine("Add 2");

            //        }
            //        SkipFirst = false;
            //        currentValue = currentValue + 99;
            //        rotated = true;
            //    }

            //    if (!haveAdded && currentValue % 100 == 0)
            //    {
            //        Console.WriteLine("Add 3");
            //        timesAtZero++;
            //    }
            //}


            //if (!rotated && currentValue == 0)
            //{
            //    Console.WriteLine("Add 4");
            //    timesAtZero++;
            //}

            //if (currentValue < 0)
            //{
            //    currentValue += 100;
            //}

            Console.WriteLine("End: " + currentValue);

            Console.WriteLine("Points: " + timesAtZero + '\n');
        }
    }
}

