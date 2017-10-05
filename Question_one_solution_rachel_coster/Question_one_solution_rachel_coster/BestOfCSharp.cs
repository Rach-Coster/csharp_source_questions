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
    {   private const long maxGarbage = 10000;
        
        //Making junk data
        void MakingGarbage()
        {
            Version vt; 

            for(int i = 0; i < maxGarbage; i++) {
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
       
            Console.Read();
        }
    }
}
