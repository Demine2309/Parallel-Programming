using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgarmming
{
    #region Task Parallel Library in C#
    #region Theory
    /*
     ** Introduction to parallelism
     *  - With parallelism, we can use our processor to perform several actions simultanously. So with parallelism,
     *    we have the opportunity to improve the speed of certain processes of our programs.
     ** What is Parallel Programming in C#?
     *  - Parallel Programming in C# helps us divide a task into different parts and work those parts simultaneously 
     *  - The main benefit of parallelism is saving time. Time is saved by maximizing the use of computer resources.
     *    The idea is that if the computer allows the use of multi-threading, we can use these threads when we have a 
     *    task to solve. So, instead of underusing our processor using a single thread, we can use as many threads as 
     *    we can to speed up the processing of the task.
     *  - In C#, we mainly use two tools to work with parallelism, they are as follows:
     *      + The Task Parallel Library (TPL) - It is a library that makes life easier for us
     *      + Parallel LINQ (PLINQ)
     ** Why do we need Task Parallel Library in C#?
     *  - We can say that the multicore processor machines are now becoming standard and the aim is to improve the 
     *    performance by running a program on multiple processors in parallel.
     *  - Using the Task Parallel Library (TPL), we can express the parallelism in the existing sequential code, which
     *    means we can express the code as a Parallel task, which will be run concurrently on all the available processors.
     ** What is Parallel Programming in C#?
     *  - Parallel Programming in C# is a type of programming in which many calculations or the execution of processes are
     *    carried out simultaneously. The points to remember while working with Parallel Programming:
     *      + The tasks must be independent
     *      + The order of the execution does not matter
     ** C# support two types of Parallelism:
     *  - Data Parallelism: In data parallelism, we have a collection of values and we want to use the same operation on each
     *    of the elememts in the collection. This means each process does the same work on unique and independent pieces of data.
     *      + Example: Parallel.For; Parallel.ForEach
     *  - Task Parallelism: Task Parallelism occurs when we have a set of independent tasks that we want to perform in parallel.
     *    This means each process performs a different function or executes different code sections that are independent.
     *      + Example: Parallel.Invoke
     *  - 
     */
    #endregion
    #endregion

    #region Parallel For in C#
    #region Theory
    /*
     ** Parallel For Loop in C#
     ** What is Parallel For Loop in C#?
     *  - There are multiple overloaded versions of the Parallel For loop available in C#. In our example, we use 
     *    the following overloaded versions.
     *      1. public static ParallelLoopResult For(int fromInclusive, int toExclusive, Action<int> body): This
     *         method is used to execute a for loop in which iterations may run in parallel. Here, the parameter
     *         The parameter toExclusive specifies the end index, exclusive. And the parameter body specifies the 
     *         delegate that is invoked once per iteration. It returns a structure that contains information about 
     *         which portion of the loop is completed. It will throw ArgumentNullException if the body argument 
     *         is null.
     *  - Note: For is a static method belongs to the Parallel static class. So, we need to invoke the method using
     *    the class name followed by the dot operator.
     ** What is the difference between the Parallel For loop and Standard C# for loop?
     *  - The main difference between the Parallel For loop and the standard C# for loop is as follows:
     *      1. In the case of the standard C# for loop, the loop is going to run using a single thread whereas, 
     *         in the case of the Parallel For loop, the loop is going to execute using multiple threads.
     *      2. The second difference is that, in the case of the standard C# for loop, the loop is iterated in 
     *         sequential order whereas, in the case of the Parallel For loop, the order of the iteration is not
     *         going to be in sequential order.
     ** ParallelOptions Class in C#
     *  - The ParallelOptions class is one of the most useful classes when working with multithreading. This class
     *    provides options to limit the number of concurrently executing loop methods. 
     ** The Degree of Parallelism in C#:
     *  - Using the Degree of parallelism we can specify the maximum number of threads to be used to execute the 
     *    program.
     *  - Syntax:
     *      var options = new ParallelOptions()
     *      {
     *          MaxDegreeOfParallelism = 2;
     *      };
     *      
     *      int n = 10;
     *      Parallel.For(0, n, options, i => 
     *      {
     *          //...
     *      };
     *      + The MaxDegreeOfParallelism property affects the number of concurrent operations run by Parallel 
     *        method calls that are passed this ParallelOptions instance. A positive property value limits the
     *        number of concurrent operations to the set value. If it is -1, there is no limit on the number of
     *        concurrently running operations.
     */
    #endregion

    #region Parrallel For Loop in C#:
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //// Standard for loop in C#
    //        //Console.WriteLine("C# for loop!");
    //        //for(int i = 1; i <= 10; i++)
    //        //{
    //        //    Console.WriteLine(i);
    //        //}

    //        //Console.ReadKey();

    //        // But what happens if we want to execute the different iterations of this block of code simultaneously.
    //        // It's the reason why we learn about Parallel For Loop
    //        Console.WriteLine("C# Parallel For Loop");

    //        //It will start from 1 until 10
    //        //Here 1 is the start index which is Inclusive
    //        //Here 11 us the end index which is Exclusive
    //        //Here number is similar to i of our standard for loop
    //        //The value will be store in the variable number
    //        Parallel.For(1, 11, number =>
    //        {
    //            Console.WriteLine(number);
    //        });

    //        Console.ReadLine();

    //        // With standard for loop, we can predict the order in which the numbers would appear on the console, but 
    //        // with Parallel For Loop, we can't do that.
    //    }
    //}
    #endregion

    #region Example to understand the differences between Standard For Loop and Parallel For Loop in C#:
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("C# For Loop");
    //        int number = 10;
    //        for (int count = 0; count < number; count++)
    //        {
    //            //Thread.CurrentThread.ManagedThreadId returns an integer that 
    //            //represents a unique identifier for the current managed thread.
    //            Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
    //            //Sleep the loop for 10 miliseconds
    //            Thread.Sleep(10);
    //        }
    //        Console.WriteLine();

    //        Console.WriteLine("Parallel For Loop");
    //        Parallel.For(0, number, count =>
    //        {
    //            Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
    //            //Sleep the loop for 10 miliseconds
    //            Thread.Sleep(10);
    //        });
    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Example for a Better Understanding From a Performance Point of View.
    #region First, we will write the example using C# for loop and will see how much time it will take to complete the execution.
    //class Program
    //{
    //    static void Main()
    //    {
    //        //DateTime StartDateTime = DateTime.Now;
    //        Stopwatch stopWatch = new Stopwatch();

    //        Console.WriteLine("For Loop Execution start");
    //        stopWatch.Start();
    //        for (int i = 0; i < 10; i++)
    //        {
    //            long total = DoSomeIndependentTask();
    //            Console.WriteLine("{0} - {1}", i, total);
    //        }
    //        //DateTime EndDateTime = DateTime.Now;
    //        Console.WriteLine("For Loop Execution end ");
    //        stopWatch.Stop();
    //        Console.WriteLine($"Time Taken to Execute the For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

    //        Console.ReadLine();
    //    }

    //    static long DoSomeIndependentTask()
    //    {
    //        //Do Some Time Consuming Task here
    //        //Most Probably some calculation or DB related activity
    //        long total = 0;
    //        for (int i = 1; i <= 100000000; i++)
    //        {
    //            total += i;
    //        }
    //        return total;
    //    }
    //}
    #endregion

    #region Then we will write the same example using the Parallel For method and will see how much time it will take to complete the execution.
    //class Program
    //{
    //    static void Main()
    //    {
    //        DateTime StartDateTime = DateTime.Now;
    //        Stopwatch stopWatch = new Stopwatch();

    //        Console.WriteLine("Parallel For Loop Execution start");
    //        stopWatch.Start();

    //        Parallel.For(0, 10, i => {
    //            long total = DoSomeIndependentTask();
    //            Console.WriteLine("{0} - {1}", i, total);
    //        });

    //        DateTime EndDateTime = DateTime.Now;
    //        Console.WriteLine("Parallel For Loop Execution end ");
    //        stopWatch.Stop();
    //        Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

    //        Console.ReadLine();
    //    }

    //    static long DoSomeIndependentTask()
    //    {
    //        //Do Some Time Consuming Task here
    //        //Most Probably some calculation or DB related activity
    //        long total = 0;
    //        for (int i = 1; i < 100000000; i++)
    //        {
    //            total += i;
    //        }
    //        return total;
    //    }
    //}
    #endregion

    /*
     * So, the parallel version of the For loop gives you better performance as compared with the standard for loop. 
     * But this is not always true. Sometimes the standard for loop will give you better performance compared to the
     * Parallel For loop which we will discuss in our upcoming article.
     */
    #endregion

    #region Example to Understand MaxDegreeOfParallelism in C#
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Limiting the maximum degree of parallelism to 2
    //        var options = new ParallelOptions()
    //        {
    //            MaxDegreeOfParallelism = 2
    //        };
    //        int n = 10;
    //        Parallel.For(0, n, options, i =>
    //        {
    //            Console.WriteLine(@"value of i = {0}, thread = {1}",
    //            i, Thread.CurrentThread.ManagedThreadId);
    //            Thread.Sleep(10);
    //        });
    //        Console.WriteLine("Press any key to exist");
    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Terminating a Parallel For Loop in C#:
    // The below example shows how to break out of a For loop and also how to stop a loop. In this context,
    // “break” means completing all iterations on all threads that are prior to the current iteration on the
    // current thread, and then exiting the loop. “Stop” means to stop all iterations as soon as convenient.

    class Program
    {
        static void Main()
        {
            var BreakSource = Enumerable.Range(0, 1000).ToList();
            int BreakData = 0;
            Console.WriteLine("Using loopstate Break Method");
            Parallel.For(0, BreakSource.Count, (i, BreakLoopState) =>
            {
                BreakData += i;
                if (BreakData > 100)
                {
                    BreakLoopState.Break();
                    Console.WriteLine("Break called iteration {0}. data = {1} ", i, BreakData);
                }
            });
            Console.WriteLine("Break called data = {0} ", BreakData);

            var StopSource = Enumerable.Range(0, 1000).ToList();
            int StopData = 0;
            Console.WriteLine("Using loopstate Stop Method");
            Parallel.For(0, StopSource.Count, (i, StopLoopState) =>
            {
                StopData += i;
                if (StopData > 100)
                {
                    StopLoopState.Stop();
                    Console.WriteLine("Stop called iteration {0}. data = {1} ", i, StopData);
                }
            });

            Console.WriteLine("Stop called data = {0} ", StopData);
            Console.ReadKey();
        }
    }

    // In Parallel.For or Parallel.ForEach Loop in C#, you cannot use the same break or Exit statement that is used
    // in a sequential loop because those language constructs are valid for loops, and a parallel “loop” is actually
    // a method, not a loop. Instead, you use either the Stop or Break method.
    #endregion
    #endregion
}

