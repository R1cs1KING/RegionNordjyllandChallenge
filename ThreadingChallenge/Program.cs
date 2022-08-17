using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingChallenge
{
    internal class Program
    {

        private static SemaphoreSlim semaphore;
        // A padding interval to make the output more orderly.
        private static int padding;

        private static List<string> lines = new List<string>() {
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
            // Create the semaphore.
            semaphore = new SemaphoreSlim(0, 3);
            Console.WriteLine("{0} tasks can enter the semaphore.",
                              semaphore.CurrentCount);
            Task[] tasks = new Task[lines.Count];

            // Create and start five numbered tasks.
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines.Count);
                tasks[i] = Task.Run(() =>
                {
                    // Each task begins by requesting the semaphore.
                    Console.WriteLine("Task {0} begins and waits for the semaphore.",
                                      Task.CurrentId);

                    int semaphoreCount;
                    semaphore.Wait();
                    try
                    {
                        Interlocked.Add(ref padding, 100);

                        Console.WriteLine("Task {0} enters the semaphore.", Task.CurrentId);

                        // The task just sleeps for 1+ seconds.
                        Thread.Sleep(1000 + padding);
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                    }
                    Console.WriteLine("Task {0} releases the semaphore; previous count: {1}.",
                                      Task.CurrentId, semaphoreCount);
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