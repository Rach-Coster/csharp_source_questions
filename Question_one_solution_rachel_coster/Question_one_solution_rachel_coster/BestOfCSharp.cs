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
    {
        private const long maxGarbage = 10000;

        private struct Person {
            public int width;
            public int height;
            public int leftX;
            public int bottomY;
        }

        public struct Rect {
            public int top;
            public int bottom;
            public int left;
            public int right; 
        }
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
        public void RomanNumeralGenerator() {
            Console.WriteLine("---Local Functions---");

            Random r = new Random();
            int[] arr = new int[3];

            for (int i = 0; i < 3; i++) {
                //Created three random numbers
                arr[i] = r.Next(1, 1999);
                Console.WriteLine("Number is: " + arr[i]);
                //Returned the roman numeral equivalent and converted it from a list to an array 
                string romanNum = string.Join("", Romaniser(arr[i]).ToArray());
                Console.WriteLine("Roman Numeral is: " + romanNum);
            }

            //Converts the number into roman numerals 
            List<String> Romaniser(int a_rand) {
                //gets the number of digits from the number
                double digits = a_rand.ToString().Length;
 
                List<int> numList = new List<int>();

                //splits the number into one index per digit
                while (a_rand > 0) {
                    numList.Add(a_rand % 10);
                    a_rand = a_rand / 10;
                }

                List<String> romanNum = new List<String>();
                //checks theo number of digits and creates the roman numerial accordingly
                for(int i = (int) digits; i > 0; i--) {
                    switch (i) { 
                        case 4:
                            romanNum.Add("M");
                            break;
                        case 3 when (numList.ElementAt(i - 1) < 4):
                            for (int j = 0; j < numList.ElementAt(i - 1); j++) { romanNum.Add("C"); };
                            break;
                        case 3 when (numList.ElementAt(i - 1) == 4):
                            romanNum.Add("CD");
                            break;
                        case 3 when (numList.ElementAt(i - 1) == 5):
                            romanNum.Add("D");
                            break;
                        case 3 when (numList.ElementAt(i - 1) > 5 && numList.ElementAt(i - 1) < 9):
                            romanNum.Add("D");
                            for (int j = 0; j < numList.ElementAt(i - 1) - 5; j++) { romanNum.Add("C"); };
                            break;
                        case 3 when (numList.ElementAt(i - 1) == 9):
                            romanNum.Add("CM");
                            break; 
                        case 2 when (numList.ElementAt(i - 1) < 4):
                            for (int j = 0; j < numList.ElementAt(i - 1); j++) { romanNum.Add("X"); };
                            break;
                        case 2 when (numList.ElementAt(i - 1) == 4):
                            romanNum.Add("XL");
                            break; 
                        case 2 when (numList.ElementAt(i - 1) == 5):
                            romanNum.Add("L");
                            break;
                        case 2 when (numList.ElementAt(i - 1) > 5 && numList.ElementAt(i - 1) < 9):
                            romanNum.Add("L");
                            for (int j = 0; j < numList.ElementAt(i - 1) - 5; j++) { romanNum.Add("X"); }
                            break;
                        case 2 when (numList.ElementAt(i - 1) == 9):
                            romanNum.Add("XC");
                            break;
                        case 1 when (numList.ElementAt(i - 1) < 4):
                            for (int j = 0; j < numList.ElementAt(i - 1); j++) { romanNum.Add("I"); };
                            break;
                        case 1 when (numList.ElementAt(i - 1) == 4):
                            romanNum.Add("IV");
                            break;
                        case 1 when (numList.ElementAt(i - 1) == 5):
                            romanNum.Add("V");
                            break;
                        case 1 when (numList.ElementAt(i - 1) > 5 && numList.ElementAt(i - 1) < 9):
                            romanNum.Add("V");
                            for (int j = 0; j < numList.ElementAt(i - 1) - 5; j++) { romanNum.Add("I"); };
                            break;
                        case 1 when (numList.ElementAt(i - 1) == 9):
                            romanNum.Add("IX");
                            break;
                    }
                }
                return romanNum; 
            }
        }

        //Question Sourced From: https://www.interviewcake.com/question/python/rectangular-love
        public void rectangularLove() {
            Console.WriteLine("---Switch Statements With Perameters---");

            Random rand = new Random();
            
            //creating person 1 obj 
            Person person1 = new Person {
                width = rand.Next(1,10),
                height = rand.Next(1, 10),
                leftX = rand.Next(1, 10),
                bottomY = rand.Next(1, 10)
            };

            //printing person 1's data 
            Console.WriteLine("Person 1: left {0} right {1} top {2} bottom {3} ", person1.leftX, person1.leftX + person1.width, person1.bottomY + person1.height, person1.bottomY);

            //creating person 2 obj 
            Person person2 = new Person {
                width = rand.Next(1, 10),
                height = rand.Next(1, 10),
                leftX = rand.Next(person1.leftX - 3, person1.leftX + person1.width + 3),
                bottomY = rand.Next(person1.bottomY - 3, person1.bottomY + person1.height + 3)
            };

            //printing person 2's data 
            Console.WriteLine("Person 2: left {0} right {1} top {2} bottom {3} ", person2.leftX, person2.leftX + person2.width, person2.bottomY + person2.height, person2.bottomY); 

            Rect intersection = findIntersection(person1, person2); 
            //finding the intersection between the rectangles if there are any
            // return 0,0,0,0 if there is none 
            Rect findIntersection(Person a_person1, Person a_person2)
            {
                //create rectangle objs 
                Rect rect1 = new Rect { };
                Rect rect2 = new Rect { };

                //arithmetic for finding the top, bottom, left and right of rects 
                // 1 and 2
                rect1.left = a_person1.leftX;
                rect1.right = rect1.left + a_person1.width;
                rect1.bottom = a_person1.bottomY;
                rect1.top = rect1.bottom + a_person1.height;

                rect2.left = a_person2.leftX;
                rect2.right = rect2.left + a_person2.width;
                rect2.bottom = a_person2.bottomY;
                rect2.top = rect2.bottom + a_person2.height;

                //making an intersect obj
                Rect intersect = new Rect { };

                //getting cases for intersection
                //bitshift to convert two booleans into a int for the case number
                int x = (Convert.ToInt16(rect1.left > rect2.left) << 1) + Convert.ToInt16(rect1.right > rect2.right);
                int y = (Convert.ToInt16(rect1.top < rect2.top) << 1) + Convert.ToInt16(rect1.bottom < rect2.bottom);
                
                //Printing out the case x and y numbers to show what case the x and y values
                // are going into 
                Console.WriteLine("Case x: " + x + " Case y: " + y);

                //case 0 a) if rect1 == rect2
                //case 0 b) 
                //    if left and right are not intersecting return 0 for all properties 
                //case 0 c) 
                //    intersection left is rect2 left and intersection right is rect 1 right
                //case 1
                //    intersection left is rect2 left and intersection right is rect 2 right 
                //case 2
                //    intersection left is rect1 left and intersection right is rect1 right 
                //case 3 a)
                //    if not intersecting return 0 for all properties 
                //case 3 b) 
                //    intersect left is rect1 left and intersect right is rect 2 right 
                switch (x)
                {
                    case 0 when (rect1.left == rect2.left && rect1.right == rect2.right):
                        intersect.left = rect1.left;
                        intersect.right = rect1.right;
                        break;
                    case 0 when (rect1.left > rect2.right || rect1.right < rect2.left):
                        intersect.left = 0;
                        intersect.right = 0;
                        intersect.top = 0;
                        intersect.bottom = 0;
                        Console.WriteLine("The couple is not compatible.");
                        return intersect;
                    case 0:
                        intersect.left = rect2.left;
                        intersect.right = rect1.right;
                        break;
                    case 1:
                        intersect.left = rect2.left;
                        intersect.right = rect2.right;
                        break;
                    case 2:
                        intersect.left = rect1.left;
                        intersect.right = rect1.right;
                        break;
                    case 3 when (rect1.left > rect2.right || rect1.right < rect2.left):
                        intersect.left = 0;
                        intersect.right = 0;
                        intersect.top = 0;
                        intersect.bottom = 0;
                        Console.WriteLine("The couple is not compatible.");
                        return intersect;
                    case 3:
                        intersect.left = rect1.left;
                        intersect.right = rect2.right;
                        break;
                }

                //cases are identical as switch x except top and bottom 
                switch (y)
                {
                    case 0 when (rect1.top == rect2.top && rect1.bottom == rect2.bottom):
                        intersect.top = rect1.top;
                        intersect.bottom = rect1.bottom;
                        break;
                    case 0 when (rect1.top < rect2.bottom || rect1.bottom > rect2.top):
                        intersect.top = 0;
                        intersect.bottom = 0;
                        intersect.left = 0;
                        intersect.right = 0;
                        Console.WriteLine("The couple is not compatible.");
                        return intersect;
                    case 0:
                        intersect.top = rect2.top;
                        intersect.bottom = rect1.bottom;
                        break;
                    case 1:
                        intersect.top = rect2.top;
                        intersect.bottom = rect2.bottom;
                        break;
                    case 2:
                        intersect.top = rect1.top;
                        intersect.bottom = rect1.bottom;
                        break;
                    case 3 when (rect1.top < rect2.bottom || rect1.bottom > rect2.top):
                        intersect.left = 0;
                        intersect.right = 0;
                        intersect.top = 0;
                        intersect.bottom = 0;
                        Console.WriteLine("The couple is not compatible.");
                        return intersect;
                    case 3:
                        intersect.top = rect1.top;
                        intersect.bottom = rect2.bottom;
                        break;
                }

                Console.WriteLine("The couple is compatible!");
                return intersect;
            }
            //printing the intersect
            Console.WriteLine("Intersect Left: " + intersection.left + " Intersect Right: " + intersection.right + " Intersection Top: " + intersection.top + " Intersection Bottom: " + intersection.bottom);
        }
    }
}
