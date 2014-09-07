using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jenkins96HashBreaker
{
    class Program
    {
        private static List<ulong> Hashes;
        private static StreamWriter FoundHashesWriter = new StreamWriter("found.txt") { AutoFlush = true };

        static void Main(string[] args)
        {
            Console.WriteLine("Jenkins96HashBreaker");
            StreamReader missingHashReader = new StreamReader("missing.txt");
            
            Hashes = new List<ulong>();
            string hashLine;
            while ((hashLine = missingHashReader.ReadLine()) != null)
                Hashes.Add(UInt64.Parse(hashLine));
            Console.WriteLine("Hashes read: {0}", Hashes.Count);

            ulong totalFilenames = 2481152873203736576;
            ulong eighthFilenames = totalFilenames / 8;

            HashBreaker breaker;
            Thread[] LoopThreads = new Thread[9];
            /*
            for (ulong i = 0; i < 8; i++)
            {
                breaker = new HashBreaker(Hashes, FoundHashesWriter);
                LoopThreads[i] = new Thread(breaker.LoopThroughFilenames);
                LoopThreads[i].Name = String.Format("HashBreaker {0}", i);
                LoopThreads[i].Start(new HashBreakerStartParams(eighthFilenames * i, eighthFilenames * (i+1)));
                Console.WriteLine("Starting HashBreaker {0}", i);
            }
            */

            breaker = new HashBreaker(Hashes, FoundHashesWriter);
            LoopThreads[8] = new Thread(breaker.LoopThroughFilenames);
            LoopThreads[8].Name = String.Format("HashBreaker simple");
            LoopThreads[8].Start(new HashBreakerStartParams());
            Console.WriteLine("Starting HashBreaker simple");

            foreach (Thread SomeThread in LoopThreads)
                if (SomeThread != null)
                    SomeThread.Join();
 
            Console.WriteLine("End");
            Console.ReadKey();
        }

        
    }
}
