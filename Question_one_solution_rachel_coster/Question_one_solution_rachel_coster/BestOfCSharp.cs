using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_one_solution_rachel_coster
{
    //implimenting the IDisposable interface and dispose method to free data
    class BestOfCSharp
    //Showing off the garbage collector 
    { private const long maxGarbage = 10000;

        //Making junk data
        void MakingGarbage()
        {
            Version vt;

            for (int i = 0; i < maxGarbage; i++) {
                //making lots of junk data
                vt = new Version();
            }
        }

        //Collecting and destorying the junk data 
        public void CollectingGarbage(object a_class) {
            Console.WriteLine("---Garbage Collector---");
            //checking if parameter is null
            if (a_class == null) {
                throw new ArgumentNullException(nameof(a_class));
            }
            //Hightest generation the collector supports
            Console.WriteLine("The highest generation is: {0}", GC.MaxGeneration);

            MakingGarbage();

            //Current generation the collector is in 
            Console.WriteLine("Generation: {0}", GC.GetGeneration(a_class));
            //Total memory with junk 
            Console.WriteLine("Memory With Junk Data: {0}", GC.GetTotalMemory(false));
            //Perform collection at gen 0
            GC.Collect(0);
            //Total memory without junk 
            Console.WriteLine("Memory Without Junk Data: {0}", GC.GetTotalMemory(false));

            MakingGarbage();

            Console.WriteLine("Generation: {0}", GC.GetGeneration(a_class));
            Console.WriteLine("Memory With Junk Data: {0}", GC.GetTotalMemory(false));
            //Collects gen 1 
            GC.Collect(1);
            Console.WriteLine("Memory Without Junk Data: {0}", GC.GetTotalMemory(false));

            MakingGarbage();

            Console.WriteLine("Generation: {0}", GC.GetGeneration(a_class));
            Console.WriteLine("Memory With Junk Data: {0}", GC.GetTotalMemory(false));
            //Collects gen 2 
            GC.Collect(2);
            Console.WriteLine("Memory Without Junk Data: {0}", GC.GetTotalMemory(false));
        }

        //Creates a roman numerial based on three random integers
        public void RomanNumberalGenerator() {
            Console.WriteLine("---Local Functions---");

            Random r = new Random();
            int[] arr = new int[3];

            for (int i = 0; i < 3; i++) {
                //Created three random numbers
                arr[i] = r.Next(1, 1999);
                Console.WriteLine("Number: {0}", arr[i]);
                //Returned the roman numeral equivalent and converted it from a list to an array 
                string romanNum = string.Join("", Romaniser(arr[i]).ToArray());
                Console.WriteLine("Roman Numerals: {0}", romanNum);
            }

            //Converts the number into roman numerals 
            List<String> Romaniser(int rand) {
                //gets the number of digits from the number
                double digits = Math.Ceiling(Math.Log10(rand));

                List<int> numList = new List<int>();

                //splits the number into one index per digit
                while (rand > 0) {
                    numList.Add(rand % 10);
                    rand = rand / 10;
                }

                //reverses the list so that the list is in order of digits 
                numList.Reverse();

                List<String> romanNum = new List<String>();
                //checks the number of digits and creates the roman numerial accordingly
                if (digits == 4) {
                    for (int i = 0; i < digits; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                romanNum.Add("M");
                                break;
                            case 1:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("C"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("CD"); }
                                else if (numList[i] == 5) { romanNum.Add("D"); }

                                else if (numList[i] > 5 && numList[i] < 9) {
                                    romanNum.Add("D");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("C"); };
                                }

                                else { romanNum.Add("CM"); };
                                break;

                            case 2:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("X"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("XL"); }
                                else if (numList[i] == 5) { romanNum.Add("L"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("L");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("X"); };
                                }

                                else { romanNum.Add("XC"); };
                                break;

                            case 3:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("I"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("IV"); }
                                else if (numList[i] == 5) { romanNum.Add("V"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("V");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("I"); };
                                }

                                else { romanNum.Add("IX"); };
                                break;
                        }
                    }

                }

                else if (digits == 3) {
                    for (int i = 0; i < digits; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("C"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("CD"); }
                                else if (numList[i] == 5) { romanNum.Add("D"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("D");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("C"); };
                                }

                                else { romanNum.Add("CM"); };
                                break;

                            case 1:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("X"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("XL"); }
                                else if (numList[i] == 5) { romanNum.Add("L"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("L");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("X"); };
                                }

                                else { romanNum.Add("XC"); };
                                break;

                            case 2:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("I"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("IV"); }
                                else if (numList[i] == 5) { romanNum.Add("V"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("V");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("I"); };
                                }

                                else { romanNum.Add("IX"); };
                                break;
                        }
                    }

                }

                else if (digits == 2) {
                    for (int i = 0; i < digits; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("X"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("XL"); }
                                else if (numList[i] == 5) { romanNum.Add("L"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("L");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("X"); };
                                }

                                else { romanNum.Add("XC"); };
                                break;

                            case 1:
                                if (numList[i] < 4)
                                {
                                    for (int j = 0; j < numList[i]; j++) { romanNum.Add("I"); };
                                }

                                else if (numList[i] == 4) { romanNum.Add("IV"); }
                                else if (numList[i] == 5) { romanNum.Add("V"); }

                                else if (numList[i] > 5 && numList[i] < 9)
                                {
                                    romanNum.Add("V");
                                    for (int j = 0; j < numList[i] - 5; j++) { romanNum.Add("I"); };
                                }

                                else { romanNum.Add("IX"); };
                                break;
                        }
                    }

                }

                else {

                    if (numList[0] < 4)
                    {
                        for (int j = 0; j < numList[0]; j++) { romanNum.Add("I"); };
                    }

                    else if (numList[0] == 4) { romanNum.Add("IV"); }
                    else if (numList[0] == 5) { romanNum.Add("V"); }

                    else if (numList[0] > 5 && numList[0] < 9)
                    {
                        romanNum.Add("V");
                        for (int j = 0; j < numList[0] - 5; j++) { romanNum.Add("I"); };
                    }

                    else { romanNum.Add("IX"); };

                }
                return romanNum; 
            }
        }
    }
}
