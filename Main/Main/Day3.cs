

using System.Runtime.Intrinsics.Arm;

namespace Main
{
    public class Day3
    {
        long totalSum = 0;
        public void Main()
        {
            StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day3.txt");
            //StreamReader sr = new StreamReader("C:\\Users\\TimFagerdal\\Code\\Advent-Of-Code-2025\\Main\\Main\\InputFiles\\Day3 - Test.txt");

            String line = sr.ReadLine();

            while (line != null)
            {
                string addString = "";
                int offset = 11;

                GetHigestNumber(line, 0, 12, ref offset, ref addString);

                Console.WriteLine(addString);

                totalSum += Int64.Parse(addString);

                line = sr.ReadLine();
            }
            sr.Close();

            Console.WriteLine(totalSum);
        }

        private void GetHigestNumber(string sequens, int startIndex, int maxStringSize, ref int offset, ref string addToString)
        {
            if (addToString.Length >= maxStringSize)
            {
                return;
            }

            char hightesValue = '0';
            int index = 0;

            for (int i = startIndex; i < sequens.Length - offset; i++)
            {
                if (sequens[i] > hightesValue)
                {
                    hightesValue = sequens[i];
                    index = i + 1;
                }
            }

            addToString += hightesValue;
            offset--;

            GetHigestNumber(sequens, index, maxStringSize, ref offset, ref addToString);

        }

    }

}

