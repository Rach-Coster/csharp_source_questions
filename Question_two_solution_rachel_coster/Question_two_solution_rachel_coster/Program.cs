using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_two_solution_rachel_coster
{
    class Program {     
        private static int[] UniqueArray(int a_len)
        {
            Random rnd = new Random();
            var arr = Enumerable.Range(1, a_len).OrderBy(x => rnd.Next()).Take(a_len).ToArray();
            return arr; 
        }
        static void Main(string[] args)
          
        {
            int[] test = UniqueArray(52);
       
           Console.WriteLine("{0}", string.Join(" ",test ));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
