// Curt Lynch
// 3/2/2023
// PiDarts entry point

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiDarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num_darts = 1, num_threads = 1, hits = 0;
            Stopwatch watch = new Stopwatch();

            Console.WriteLine("PiDarts Pi Calculator");
            Console.WriteLine("Enter the number of dart throws per thread.");
            num_darts = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of threads to use");
            num_threads = int.Parse(Console.ReadLine());
            Console.WriteLine("Calculating please wait...");
            watch.Start();

            List<Thread> threads = new List<Thread>();
            List<FindPiThread> dart_boards = new List<FindPiThread>();

            for (int i = 0; i < num_threads; i++)
            {
                FindPiThread board = new FindPiThread(num_darts);
                dart_boards.Add(board);
                Thread thread = new Thread(new ThreadStart(board.throwDarts));
                threads.Add(thread);
                thread.Start();
                Thread.Sleep(16);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            foreach(FindPiThread board in dart_boards)
            {
                hits += board.Hits;
            }

            double pi = 4.0 * ((double)hits / (num_darts * num_threads));
            watch.Stop();
            Console.WriteLine("Pi calculation complete!");
            Console.WriteLine("Pi calculated to be " + pi);
            Console.WriteLine("This calculation took " + watch.Elapsed.TotalSeconds + " seconds to complete.");
            Console.ReadKey();
        }
    }
}
