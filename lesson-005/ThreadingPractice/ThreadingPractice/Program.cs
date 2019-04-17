using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingPractice
{
    class Program
    {
        // Andrew Brudnak
        // CIS262AD - C# Level II - Class # 31838
        // September 22nd, 2018 
        // Lesson 05
        static void Main(string[] args)
        {
            Thread threadA = new Thread(ThreadA);
            Thread threadB = new Thread(ThreadB);
            Console.WriteLine("Press enter, this application will count as high as it can until you press enter again.");
            Console.ReadLine();
            Console.WriteLine("*** COUNTING NOW ***");
            Console.WriteLine(string.Empty);
            threadA.Start();
            threadB.Start();
            Console.WriteLine("Reminder: Press enter again and the program will stop counting.");
            Console.ReadLine();
            threadA.Abort();
            threadB.Abort();
            Console.WriteLine($"Thread A: {resultA}");
            Console.WriteLine($"Thread B: {resultB}");
            Console.ReadLine();
        }

        static int resultA = 0;
        static void ThreadA()
        {
            while (true)
            {
                resultA++;
            }
        }

        static int resultB = 0;
        static void ThreadB()
        {
            while (true)
            {
                resultB++;
            }
        }
    }
}
