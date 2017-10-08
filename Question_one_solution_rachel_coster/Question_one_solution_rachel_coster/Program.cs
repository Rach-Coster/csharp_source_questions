using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_one_solution_rachel_coster
{
    class Program
    {
        static void Main(string[] args)
        {
            var bestOf = new BestOfCSharp();
            //showing off garbage generator
            bestOf.CollectingGarbage(bestOf);

            //showing off local functions 
            bestOf.RomanNumeralGenerator();

            //showing off switch statements with parameters 
            bestOf.rectangularLove();

            Console.Read();
        }
    }
}
