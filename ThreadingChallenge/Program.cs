using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ThreadingChallenge
{
    internal class Program
    {

        private static SemaphoreSlim semaphore;
        private static Random random = new Random();

        private static List<string> lines = new List<string>()
        {
                "Task A",
                "Task B",
                "Task C",
                "Task D",
                "Task E",
                "Task F",
                "Task G",
                "Task H",
                "Task I",
                "Task J",
                "Task K",
                "Task L",
                "Task M",
                "Task N",
                "Task O",
                "Task P",
                "Task Q",
                "Task R",
                "Task S",
                "Task T",
                "Task U",
                "Task V",
                "Task W",
                "Task X",
                "Task Y",
                "Task Z"
        };

        public static void Main()
        {
            // Create the semaphore with maximum 3 task at a time.
            semaphore = new SemaphoreSlim(0, 3);
            Console.WriteLine("{0} tasks can enter the semaphore.",
                              semaphore.CurrentCount);
            Task[] tasks = new Task[26];

            // Create and start five numbered tasks.
            for (int i = 0; i < lines.Count; i++)
            {
                // It helps keeping track of the index of the list.
                int j = i;
                tasks[i] = Task.Run(() =>
                {
                    // Each task begins by requesting the semaphore.
                    Console.WriteLine("T{0} begins and waits for the semaphore.",
                                      lines[j]);

                    int semaphoreCount;
                    semaphore.Wait();
                    try
                    {
                        Console.WriteLine("{0} enters the semaphore.", lines[j]);

                        // The task sleeps for 1-5 seconds
                        int sleepTime = random.Next(1000, 5000);
                        WriteLine(sleepTime.ToString());
                        Thread.Sleep(sleepTime);
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                    }
                    Console.WriteLine("{0} releases the semaphore; previous count: {1}.",
                                      lines[j], semaphoreCount);
                });
            }

            // Wait for half a second, to allow all the tasks to start and block.
            Thread.Sleep(500);

            // Restore the semaphore count to its maximum value.
            Console.Write("Main thread calls Release(3) --> ");
            semaphore.Release(3);
            Console.WriteLine("{0} tasks can enter the semaphore.",
                              semaphore.CurrentCount);
            // Main thread waits for the tasks to complete.
            Task.WaitAll(tasks);

            Console.WriteLine("Main thread exits.");
        }
    }
}