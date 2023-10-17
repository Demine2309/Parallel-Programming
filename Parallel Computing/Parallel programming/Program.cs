﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

    //class Program
    //{
    //    static void Main()
    //    {
    //        var BreakSource = Enumerable.Range(0, 1000).ToList();
    //        int BreakData = 0;
    //        Console.WriteLine("Using loopstate Break Method");
    //        Parallel.For(0, BreakSource.Count, (i, BreakLoopState) =>
    //        {
    //            BreakData += i;
    //            if (BreakData > 100)
    //            {
    //                BreakLoopState.Break();
    //                Console.WriteLine("Break called iteration {0}. data = {1} ", i, BreakData);
    //            }
    //        });
    //        Console.WriteLine("Break called data = {0} ", BreakData);

    //        var StopSource = Enumerable.Range(0, 1000).ToList();
    //        int StopData = 0;
    //        Console.WriteLine("Using loopstate Stop Method");
    //        Parallel.For(0, StopSource.Count, (i, StopLoopState) =>
    //        {
    //            StopData += i;
    //            if (StopData > 100)
    //            {
    //                StopLoopState.Stop();
    //                Console.WriteLine("Stop called iteration {0}. data = {1} ", i, StopData);
    //            }
    //        });

    //        Console.WriteLine("Stop called data = {0} ", StopData);
    //        Console.ReadKey();
    //    }
    //}

    // In Parallel.For or Parallel.ForEach Loop in C#, you cannot use the same break or Exit statement that is used
    // in a sequential loop because those language constructs are valid for loops, and a parallel “loop” is actually
    // a method, not a loop. Instead, you use either the Stop or Break method.
    #endregion
    #endregion

    #region Parallel Foreach Loop in C#
    #region Theory
    /*
     ** Parallel.ForEach Loop in C#
     *  - Parallel ForEach is the equivalent of a normal foreach, which can occur in parallel. It is usefull when we want to iterate through 
     *    a collection and we need to do relatively hard work on each item in the collection.
     *  - It should be clear that the work we neef to do is CPU bound since we have already seen that its is the ideal type od work for the 
     *    parallel class.
     *  - NOTE: We need to use parallel loops such as Parallel.For and Parallel.ForEach method to speed up operations where an expensive,
     *    independent CPU-Bound operation needs to be performed for each input of a sequence.
     ** A sequential Foreach Loop Syntax in C#
     *  - Ex: List<int> integerList = Enumrable.Range(1, 10).ToList();
     *        Parallel.ForEach(integerList, i =>
     *        {
     *              //...
     *        });
     *  - There are many overload versions available for this method. This is the simplest overloaded version that accepts two arguments:
     *      + The first one is the collection of objects that will be enumerated (This can be any collection that implements IEnumrable<T>)
     *      + The second parameter accepts an Action delegate, usually expressed as a lambda expression that determines the action to take
     *        for each item in the collection. The delegate's parameter contains the item from the collection that is to be processed during
     *        the iteration.
     ** Using Degree of Parallelism in C# with Parallel ForEach Loop
     *  - Using the Degree of Parallelism in C# we can specify the maximum number of threads to be used to execute the parallel foreach loop
     *  - Syntax:   var options = new ParallelOptions()
     *              {
     *                  MaxDegreeOfParallelism = 2
     *              };
     *              List<int> integerList = Enumrable.Range(1, 10).ToList();
     *              Parralel.ForEach(integerList, options, i =>
     *              {   
     *                  long total = DoSomeIndependentTimeConsumingTask();
     *                  Console.WriteLine("{0} - {1}", i, total);
     *              });
     *  - The MaxDegreeOfParallelism property affects the number of concurrent operations run by Parallel method calls that are passed to this
     *    ParallelOptions instance. A positive property value limits the number of concurrent operations to the set value. If it is -1, there 
     *    is no limit on the number of concurrently running operations.
     *  - By default, For and ForEach will utilize however many threads the underlying scheduler provides, so changing MaxDegreeOfParallelism 
     *    from the default only limits how many concurrent tasks will be used.
     ** How to control the degree of concurrency i.e. How to restrict the number of threads to be created?
     *  - We can restrict the number of concurrent threads created during the execution of a parallel loop by using the MaxDegreeOfParallelism 
     *    property of ParallelOptions class. By assigning some integer value to MaxDegreeOfParallelism, we can restrict the degree of this 
     *    concurrency and can restrict the number of processor cores to be used by our loops. The default value of this property is -1, which
     *    means there is no restriction on concurrently running operations.
     ** Speed Benefits of Parallelism in C#
     *  - In other words, we have always obtained better results when using parallelism.
     *  - However, as we know, nothing is free in this life and parallelism is not the exception. We will not always obtain better results 
     *    when introducing parallelism in our applications. This is because there is a cost to preparing the use of multithreading. That is
     *    why it is always advisable to take measurements to see whether the use of parallelism exceeds the cost.
     ** Is it Worth using Parallelism in C#?
     *
     */
    #endregion

    #region Parallel Foreach Loop Examples in C#
    // First, we will write an example using the standard sequential Foreach loop and will see how much time it will take to complete the
    // excution. Then we will write the same example using the Parallel ForEach Loop method and will see how much time it will take to 
    // complete the execution of the same example.
    #region Standard Foreach Loop
    //class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch stopwatch = new Stopwatch();

    //        Console.WriteLine("Standard Foreach Loop Started");
    //        stopwatch.Start();
    //        List<int> integerList = Enumerable.Range(1, 10).ToList();
    //        foreach (int i in integerList)
    //        {
    //            long total = DoSomeIndependentTimeconsumingTask();
    //            Console.WriteLine("{0} - {1}", i, total);
    //        };

    //        Console.WriteLine("Standard Foreach Loop Ended");
    //        stopwatch.Stop();

    //        Console.WriteLine($"Time Taken by Standard Foreach Loop in Miliseconds {stopwatch.ElapsedMilliseconds}");
    //        Console.ReadLine();
    //    }

    //    static long DoSomeIndependentTimeconsumingTask()
    //    {
    //        //Do Some Time Consuming Task here
    //        long total = 0;
    //        for (int i = 1; i <= 100000000; i++)
    //        {
    //            total += i;
    //        }
    //        return total;
    //    }
    //}
    #endregion

    #region Parallel ForEach Loop 
    //class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch stopwatch = new Stopwatch();

    //        Console.WriteLine("Parallel Foreach Loop Started");
    //        stopwatch.Start();
    //        List<int> integerList = Enumerable.Range(1, 10).ToList();

    //        Parallel.ForEach(integerList, i =>
    //        {
    //            long total = DoSomeIndependentTimeconsumingTask();
    //            Console.WriteLine("{0} - {1}", i, total);
    //        });
    //        Console.WriteLine("Parallel Foreach Loop Ended");
    //        stopwatch.Stop();

    //        Console.WriteLine($"Time Taken by Parallel Foreach Loop in Miliseconds {stopwatch.ElapsedMilliseconds}");
    //        Console.ReadLine();
    //    }

    //    static long DoSomeIndependentTimeconsumingTask()
    //    {
    //        //Do Some Time Consuming Task here
    //        long total = 0;
    //        for (int i = 1; i < 100000000; i++)
    //        {
    //            total += i;
    //        }
    //        return total;
    //    }
    //}
    #endregion
    #endregion

    #region Example to Understand Degree of Parallelism in C#
    // In the below example, we are executing the Parallel Foreach method without using Degree of Parallelism. That means we are not limiting
    // the number of threads to execute the Parallel Foreach method.
    #region No limit threads
    //class Program
    //{
    //    static void Main()
    //    {
    //        List<int> integerList = Enumerable.Range(0, 10).ToList();
    //        Parallel.ForEach(integerList, i =>
    //        {
    //            Console.WriteLine(@"value of i = {0}, thread = {1}", i, Thread.CurrentThread.ManagedThreadId);
    //        });
    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Restrict the number of Threads
    //class Program
    //{
    //    static void Main()
    //    {
    //        List<int> integerList = Enumerable.Range(0, 10).ToList();
    //        var options = new ParallelOptions() { MaxDegreeOfParallelism = 2 };

    //        Parallel.ForEach(integerList, options, i =>
    //        {
    //            Console.WriteLine(@"value of i = {0}, thread = {1}", i, Thread.CurrentThread.ManagedThreadId);
    //        });
    //        Console.ReadLine();
    //    }
    //}
    #endregion
    #endregion

    #region Is it Worth using Parallelism in C#?
    //  In the below example, the same task is going to be performed using both C# Standard For Loop and Parallel Foreach Loop. But here the
    //  task is not an expensive or time-consuming task. It is just a simple task.

    //class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch stopwatch = new Stopwatch();

    //        Console.WriteLine("Standard Foreach Loop Started");
    //        stopwatch.Start();
    //        List<int> integerList = Enumerable.Range(1, 10).ToList();
    //        foreach (int i in integerList)
    //        {
    //            DoSomeIndependentTask(i);
    //        };

    //        stopwatch.Stop();
    //        Console.WriteLine("Standard Foreach Loop Ended");
    //        Console.WriteLine($"Time Taken by Standard Foreach Loop in Miliseconds {stopwatch.ElapsedMilliseconds}");


    //        Console.WriteLine("\nParallel Foreach Loop Started");
    //        stopwatch.Restart();

    //        Parallel.ForEach(integerList, i =>
    //        {
    //            DoSomeIndependentTask(i);
    //        });

    //        stopwatch.Stop();
    //        Console.WriteLine("Parallel Foreach Loop Ended");

    //        Console.WriteLine($"Time Taken by Parallel Foreach Loop in Miliseconds {stopwatch.ElapsedMilliseconds}");

    //        Console.ReadLine();
    //    }

    //    static void DoSomeIndependentTask(int i)
    //    {
    //        Console.WriteLine($"Number: {i}");
    //    }
    //}

    // Now, if you run the code you will observe that the Parallel version of the foreach loop takes more time as compared to the
    // standard foreach loop. This is because the parallel foreach creates multiple threads which will take some time which is not in
    // the case of a standard foreach loop as a single thread is going to execute the tasks.
    #endregion
    #endregion

    #region Parallel Invoke in C#
    #region Theory
    /*
     *  - If you observe it is taking less time than the sequential execution. But this is not always going to be the same 
     *    i.e. sometimes the sequential execution will take less time than the parallel execution if the task that we are 
     *    going to perform is very less. So, always it is recommended to do a performance measurement before selecting 
     *    whether you want to execute methods parallelly or sequentially.
     ** ParallelOptions Class in C#
     *  - As we already discussed, using the ParallelOptions class instance, we can limit the number of concurrently
     *    executing loop methods. The same thing can also be done with the Invoke method. So, using the Degree of parallelism
     *    we can specify the maximum number of threads to be used to execute the program.
     *    
     */
    #endregion

    #region Example to understand Parallel Invoke Method in C#
    // The Parallel Invoke method in C# is used to launch multiple tasks that are going to be executed in parallel.
    // Let us first create one example where we will invoke three independent methods sequentially and then we will
    // rewrite the same example where we invoke the same three independent methods parallelly using the Parallel 
    // Invoke method.

    #region Sequential approach
    //public class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch stopWatch = new Stopwatch();

    //        stopWatch.Start();
    //        //Calling Three methods sequentially
    //        Method1();
    //        Method2();
    //        Method3();
    //        stopWatch.Stop();

    //        Console.WriteLine($"Sequential Execution Took {stopWatch.ElapsedMilliseconds} Milliseconds");
    //        Console.ReadKey();
    //    }

    //    static void Method1()
    //    {
    //        Thread.Sleep(200);
    //        Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }

    //    static void Method2()
    //    {
    //        Thread.Sleep(200);
    //        Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }

    //    static void Method3()
    //    {
    //        Thread.Sleep(200);
    //        Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion

    #region Parallel.Invoke
    //public class Program
    //{
    //    static void Main()
    //    {
    //        Stopwatch stopWatch = new Stopwatch();

    //        stopWatch.Start();

    //        //Calling Three methods Parallely
    //        Parallel.Invoke(
    //             Method1, Method2, Method3
    //        );

    //        stopWatch.Stop();
    //        Console.WriteLine($"Parallel Execution Took {stopWatch.ElapsedMilliseconds} Milliseconds");

    //        Console.ReadKey();
    //    }

    //    static void Method1()
    //    {
    //        Thread.Sleep(200);
    //        Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }

    //    static void Method2()
    //    {
    //        Thread.Sleep(200);
    //        Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }

    //    static void Method3()
    //    {
    //        Thread.Sleep(200);
    //        Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion
    #endregion

    #region Example to Invoke Different Types of Methods using Parallel.Invoke in C#
    // The following example demonstrates how to use the Parallel Invoke method in C# with normal methods, anonymous
    // methods (delegates), and lambda expressions.
    //public class Program
    //{
    //    static void Main()
    //    {
    //        Parallel.Invoke(
    //             NormalAction, // Invoking Normal Method
    //             delegate ()   // Invoking an inline delegate 
    //             {
    //                 Console.WriteLine($"Method 2, Thread={Thread.CurrentThread.ManagedThreadId}");
    //             },
    //            () =>   // Invoking a lambda expression
    //            {
    //                Console.WriteLine($"Method 3, Thread={Thread.CurrentThread.ManagedThreadId}");
    //            }
    //        );
    //        Console.WriteLine("Press any key to exist.");
    //        Console.ReadKey();
    //    }
    //    static void NormalAction()
    //    {
    //        Console.WriteLine($"Method 1, Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    // The Parallel Invoke method is used to execute a set of operations(actions) in parallel.As you can see in the
    // above output three threads are created to execute three actions which prove that this parallel Invoke Method
    // executes the actions in parallel.
    #endregion

    #region Example to Understand ParallelOptions Class in C# with Parallel Invoke Method
    // In the following example, we are creating seven actions without specifying a limit to the number of parallel tasks. So,
    // in this example, it may be possible that all seven actions can be executed concurrently.

    //public class ParallelInvoke
    //{
    //    static void Main()
    //    {
    //        Parallel.Invoke(
    //                () => DoSomeTask(1),
    //                () => DoSomeTask(2),
    //                () => DoSomeTask(3),
    //                () => DoSomeTask(4),
    //                () => DoSomeTask(5),
    //                () => DoSomeTask(6),
    //                () => DoSomeTask(7)
    //            );
    //        Console.ReadKey();
    //    }
    //    static void DoSomeTask(int number)
    //    {
    //        Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
    //        //Sleep for 5000 milliseconds
    //        Thread.Sleep(5000);
    //        Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion

    #region Example to Limit the Number of Threads to Execute the Methods:
    //public class ParallelInvoke
    //{
    //    static void Main()
    //    {
    //        //Allowing three task to execute at a time
    //        ParallelOptions parallelOptions = new ParallelOptions
    //        {
    //            MaxDegreeOfParallelism = 3
    //        };
    //        //parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount - 1;

    //        //Passing ParallelOptions as the first parameter
    //        Parallel.Invoke(
    //                parallelOptions,
    //                () => DoSomeTask(1),
    //                () => DoSomeTask(2),
    //                () => DoSomeTask(3),
    //                () => DoSomeTask(4),
    //                () => DoSomeTask(5),
    //                () => DoSomeTask(6),
    //                () => DoSomeTask(7)
    //            );
    //        Console.ReadKey();
    //    }
    //    static void DoSomeTask(int number)
    //    {
    //        Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
    //        //Sleep for 500 milliseconds
    //        Thread.Sleep(5000);
    //        Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion

    #region Invoking Methods with Input and Return Type using Parallel.Invoke:
    // As of now, we have discussed the method which does not take any parameter and the return type of those methods is void.
    // Now, let us proceed and try to understand how to invoke methods using Parallel.Invoke with input values and also see how
    // to store the return value of a method.

    //public class Program
    //{
    //    static void Main()
    //    {
    //        int intResult = 0;
    //        string strResult = string.Empty;
    //        //Calling Three methods Parallely
    //        Parallel.Invoke(
    //            () => intResult = Method1(),
    //            () => strResult = Method2("Pranaya"),
    //            () => Method3(100)
    //        );

    //        Console.WriteLine($"Method1 Result: {intResult}");
    //        Console.WriteLine($"Method2 Result: {strResult}");
    //        Console.WriteLine($"Parallel Execution Completed");

    //        Console.ReadKey();
    //    }
    //    static int Method1()
    //    {
    //        Task.Delay(200);
    //        Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //        return 100;
    //    }
    //    static string Method2(string name)
    //    {
    //        Task.Delay(200);
    //        Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //        return "Hello:" + name;
    //    }
    //    static void Method3(int number)
    //    {
    //        Task.Delay(200);
    //        Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion
    #endregion

    #region Maximum Degree of Parallelism in C#
    #region Theory
    /*
     ** How to use Maximum Degree of Parallelism in C#?
     *  - Until now, when we use parallelism, we are allowing as many threads as possible from our computer to be used to solve 
     *    the task that we have. However, this is not necessarily something we are going to want. Sometimes we would want to limit
     *    the resources used for a task in order to be able to handle other tasks that we may have pending.
     *  - We can configure this by defining the maximum degree of parallelism. With a maximum degree of parallelism, we can indicate
     *    how many simultaneous threads we will have working on the code that we want to execute in parallel.
     ** ParallelOptions Class in C#
     *  - The ParallelOptions class is one of the most useful classes when working with multithreading. This class provides options
     *    to limit the number of concurrently executing threads to execute our parallel code as well as provide options to cancel
     *    the parallel execution.
     ** How to use Maximum Degree of Parallelism in C#?
     *  - The ParallelOptions class in C# provides the following constructor which we can use to create an instance of ParallelOptions 
     *    class.
     *      1. ParallelOptions(): It initializes a new instance of the System.Threading.Tasks.ParallelOptions class.
     *  - The ParallelOptions class provides the following three propeties:
     *      1. public TaskScheduler TaskScheduler {get; set;}: It is used to get or set the TaskScheduler associated with this 
     *         ParallelOptions instance. Setting this property to null indicates that the current scheduler should be used. It 
     *         returns the task scheduler that is associated with this instance.
     *      2. public int MaxDegreeOfParallelism {get; set;}: It is used to get or set the maximum number of concurrent tasks enabled
     *         by this ParallelOptions instance. It returns an integer that represents the maximum degree of parallelism. It will throw
     *         ArgumentOutOfRangeException if the property is being set to zero or to a value that is less than -1. -1 is the default 
     *         value which sets that there is no limitation of the concurrent tasks to be executed.
     *      3. public CancellationToken CancellationToken {get; set;}: It is used to get or set the CancellationToken associated with
     *         this ParallelOptions instance. It returns the token that is associated with this instance.
     *  - So, in order to use Maximum Degree of Parallelism in C#, we need to create an instance of ParallelOptions class and we need 
     *    to set the MaxDegreeOfParallelism properties to an integer number indicating the number of threads to execute the code.
     *  + Ex:   var options = new ParallelOptions()
     *          {
     *              MaxDegreeOfParallelism = 3;
     *          };
     *  - C# provides Environment.ProcessorCount property will give us the number of logical processors on the machine on which the 
     *    application is running. So, we need to set the Maximum Degree of Parallelism in C# as follows.
     *  + Ex:   var options = new ParallelOptions()
     *          {
     *              MaxDegreeOfParallelism = Enviroment.ProcessorCount - 1;
     *          };
     *  - 
     */
    #endregion

    #region Example without using ParallelOption Class in C#
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Parallel.For(1, 11, i =>
    //        {
    //            Thread.Sleep(500);
    //            Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
    //        });
    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Example using ParallelOption Class
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Limiting the maximum degree of parallelism to 3
    //        var options = new ParallelOptions()
    //        {
    //            MaxDegreeOfParallelism = 3
    //        };

    //        //A maximum of three threads are going to execute the code parallelly
    //        Parallel.For(1, 11, options, i =>
    //        {
    //            Thread.Sleep(500);
    //            Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
    //        });

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Enviroment.ProcessorCount
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Getting the Number of Processor count
    //        int processorCount = Environment.ProcessorCount;

    //        Console.WriteLine($"Processor Count on this Machine: {processorCount}\n");

    //        //Limiting the maximum degree of parallelism to processorCount - 1
    //        var options = new ParallelOptions()
    //        {
    //            //You can hard code the value as follows
    //            //MaxDegreeOfParallelism = 7
    //            //But better to use the following statement
    //            MaxDegreeOfParallelism = Environment.ProcessorCount - 1
    //        };

    //        Parallel.For(1, 11, options, i =>
    //        {
    //            Thread.Sleep(500);
    //            Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
    //        });

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Maximum Degree of Parallelism Example using Parallel Foreach Loop
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Limiting the maximum degree of parallelism to ProcessorCount - 1
    //        var options = new ParallelOptions()
    //        {
    //            //MaxDegreeOfParallelism = 7
    //            MaxDegreeOfParallelism = Environment.ProcessorCount - 1
    //        };

    //        List<int> integerList = Enumerable.Range(0, 10).ToList();
    //        Parallel.ForEach(integerList, options, i =>
    //        {
    //            Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
    //        });

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Maximum Degree of Parallelism Example using Parallel Invoke method in C#
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var parallelOptions = new ParallelOptions()
    //        {
    //            MaxDegreeOfParallelism = 3
    //            //MaxDegreeOfParallelism = Environment.ProcessorCount - 1
    //        };

    //        //Passing ParallelOptions as the first parameter
    //        Parallel.Invoke(
    //                parallelOptions,
    //                () => DoSomeTask(1),
    //                () => DoSomeTask(2),
    //                () => DoSomeTask(3),
    //                () => DoSomeTask(4),
    //                () => DoSomeTask(5),
    //                () => DoSomeTask(6),
    //                () => DoSomeTask(7)
    //            );

    //        Console.ReadLine();
    //    }

    //    static void DoSomeTask(int number)
    //    {
    //        Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
    //        //Sleep for 5000 milliseconds
    //        Thread.Sleep(5000);
    //        Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion
    #endregion

    #region How to Cancel Parallel Operations in C#
    #region Theory
    /*
     ** How to Cancel Parallel Operations in C#?
     *  - We can use the Cancellation Token to cancel operations in Parallel Programming. The ParallelOptions Class
     *    provides the option to cancel the parallel execution.
     *  - The ParallelOptions Class Provides the following three properties:
     *      1. public TaskScheduler TaskScheduler {get; set;}: This property is used to get or set the TaskScheduler 
     *         associated with the ParallelOptions instance. Setting this property to null indicates that the current 
     *         scheduler should be used. It returns the task scheduler that is associated with this instance.
     *      2. public int MaxDegreeOfParallelism {get; set;}: This property is used to get or set the maximum number 
     *         of concurrent tasks enabled by the ParallelOptions instance. It returns an integer that represents the 
     *         maximum degree of parallelism.
     *      3. public CancellationToken CancellationToken {get; set;}: This property is used to get or set the 
     *         CancellationToken associated with the ParallelOptions instance. It returns the token that is associated
     *         with the ParallelOptions instance.
     *  - In order to Cancel the Parallel Operations in C#, first, we need to create an instance of ParallelOptions 
     *    class and then we need to create an instance of CancellationTokenSource and then we need to set the 
     *    CancellationToken properties of ParallelOptions instance to the token of the CancellationTokenSource instance.
     *  + Ex:   var CTS = new CancellationTokenSource();
     *          
     *          CTS.CancelAfter(TimeSpan.FromSeconds(5));
     *          
     *          var parallelOptions = new ParallelOptions()
     *          {
     *              CancellationToken = CTS.Token;
     *          };
     *          
     */
    #endregion

    #region Example without Cancelling the Parallel Operation 
    // In the below example, we have set the degree of parallelism to 2 i.e. a maximum of two threads execute the methods
    // parallelly.

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Create an instance of ParallelOptions class
    //        var parallelOptions = new ParallelOptions()
    //        {
    //            MaxDegreeOfParallelism = 2,
    //        };

    //        try
    //        {
    //            Stopwatch stopwatch = new Stopwatch();
    //            stopwatch.Start();
    //            //Passing ParallelOptions as the first parameter
    //            Parallel.Invoke(
    //                    parallelOptions,
    //                    () => DoSomeTask(1),
    //                    () => DoSomeTask(2),
    //                    () => DoSomeTask(3),
    //                    () => DoSomeTask(4),
    //                    () => DoSomeTask(5),
    //                    () => DoSomeTask(6),
    //                    () => DoSomeTask(7)
    //                );
    //            stopwatch.Stop();
    //            Console.WriteLine($"Time Taken to Execute all the Methods : {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }

    //        Console.ReadLine();
    //    }

    //    static void DoSomeTask(int number)
    //    {
    //        Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
    //        //Sleep for 2 seconds
    //        Thread.Sleep(TimeSpan.FromSeconds(2));
    //        Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    #endregion

    #region Example to Understand How to Cancel Parallel Operations
    // In the below example, we are canceling the Parallel Execution after 4 seconds.

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Create an Instance of CancellationTokenSource
    //        var CTS = new CancellationTokenSource();

    //        //Set when the token is going to cancel the parallel execution
    //        CTS.CancelAfter(TimeSpan.FromSeconds(5));

    //        //Create an instance of ParallelOptions class
    //        var parallelOptions = new ParallelOptions()
    //        {
    //            MaxDegreeOfParallelism = 2,
    //            //Set the CancellationToken value
    //            CancellationToken = CTS.Token
    //        };

    //        try
    //        {
    //            Stopwatch stopwatch = new Stopwatch();
    //            stopwatch.Start();
    //            //Passing ParallelOptions as the first parameter
    //            Parallel.Invoke(
    //                    parallelOptions,
    //                    () => DoSomeTask(1),
    //                    () => DoSomeTask(2),
    //                    () => DoSomeTask(3),
    //                    () => DoSomeTask(4),
    //                    () => DoSomeTask(5),
    //                    () => DoSomeTask(6),
    //                    () => DoSomeTask(7)
    //                );
    //            stopwatch.Stop();
    //            Console.WriteLine($"Time Taken to Execute all the Methods : {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
    //        }
    //        //When the token cancelled, it will throw an exception
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //        finally
    //        {
    //            //Finally dispose the CancellationTokenSource and set its value to null
    //            CTS.Dispose();
    //            CTS = null;
    //        }
    //        Console.ReadLine();
    //    }

    //    static void DoSomeTask(int number)
    //    {
    //        Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
    //        //Sleep for 2 seconds
    //        Thread.Sleep(TimeSpan.FromSeconds(2));
    //        Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
    //    }
    //}
    // When you run the application, please observe the output carefully. Here, it started the execution parallelly
    // by using two threads. 
    #endregion

    #region Canceling Parallel Operation Example using Parallel Foreach Loop
    // In the below example, the collection contains 20 elements which means the Parallel Foreach loop will execute 20
    // times. And here we set the MaxDegreeOfParallelism property to 2 which means a maximum of two threads will execute
    // the loop parallelly. 

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //Create an Instance of CancellationTokenSource
    //        var CTS = new CancellationTokenSource();

    //        //Set when the token is going to cancel the parallel execution
    //        CTS.CancelAfter(TimeSpan.FromSeconds(5));

    //        //Create an instance of ParallelOptions class
    //        var parallelOptions = new ParallelOptions()
    //        {
    //            MaxDegreeOfParallelism = 2,
    //            //Set the CancellationToken value
    //            CancellationToken = CTS.Token
    //        };

    //        try
    //        {
    //            List<int> integerList = Enumerable.Range(0, 20).ToList();
    //            Parallel.ForEach(integerList, parallelOptions, i =>
    //            {
    //                Thread.Sleep(TimeSpan.FromSeconds(1));
    //                Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
    //            });

    //        }
    //        //When the token canceled, it will throw an exception
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //        finally
    //        {
    //            //Finally dispose the CancellationTokenSource and set its value to null
    //            CTS.Dispose();
    //            CTS = null;
    //        }
    //        Console.ReadLine();
    //    }
    //}
    #endregion
    #endregion

    #region Atomic Methods Thread Safety and Race Conditions in C#
    #region Theory
    /*
     ** Atomic Methods
     *  - So far, with the Parallel Methods (For, Foreach, and Invoke) we have worked and performed the task independently.
     *    In the sense that they do not need external data or shared data to work. But this is not always going to be the 
     *    case. Sometimes we will want to share data between threads.
     *  - An important concept to consider is the concept of Atomic Methods. Atomic Methods can be used comfortably in a 
     *    multithreaded environment because they guarantee determinism, that is we will always obtain the same result, no 
     *    matter how many threads try to execute the method simultaneously.
     ** Characteristics of Atomic Methods
     *  1. First, if one thread is executing an atomic method, then another thread cannot see an intermediate state that is 
     *     the operation has either not started or has already been completed. But there is no intermediate state between the
     *     beginning and end.
     *  2. Second, the operation will be completed successfully or will fail completely without making any modifications. This
     *     part is similar to database transactions where either all operations are successful or none are performed if there
     *     is at least one error.
     ** How to Achieve Atomicity in C#?
     *  - There are several ways to achieve Atomicity in C#. The most common way is to use locks. Locks allow us to block 
     *    other threads from executing a piece of code when the lock is activated. If you are working with collections, then 
     *    another option is to use concurrent collections, which are specially designed to handle multithread scenarios.
     *  - If we do not use proper mechanisms, then we will end up with unexpected results, corrupted data, or incorrect values.
     ** Thread Safety in #?
     *  - An important concept in a parallelism environment is thread-safe. When we say that a method is thread-safe, we are 
     *    saying that we can execute this method simultaneously from multiple threads without causing any kind of error. We 
     *    know that we have thread safety when the application data is not corrupted if two or more threads try to perform
     *    operations on the same data at the same time.
     ** How to Achive Thread Safety in C#?
     *  - Well, it all depends on what we do within the method. If within the method We added an external variable. Then we 
     *    could have a problem with unexpected results in that variable. Something that we can use to mitigate this is to use
     *    a synchronization mechanism like using Interlocked or using locks.
     *  - If we need to transform objects, then we can use immutable objects to avoid the problems of corrupting those objects. 
     *    Ideally, we should work with pure functions. Pure functions are those that return the same value for the same arguments 
     *    and do not cause secondary effects.
     ** Race Conditions in C#
     *  - Race conditions occur in C# when we have a variable shared by several threads and these threads want to modify the 
     *    variables simultaneously. The problem with this is that depending on the order of the sequence of operations done on a 
     *    variable by different threads, the value of the variable will be different. Operations are simple as increasing by one.
     *  - Race conditions occur in C# when we have a variable shared by several threads and these threads want to modify the 
     *    variables simultaneously. The problem with this is that depending on the order of the sequence of operations done on a 
     *    variable by different threads, the value of the variable will be different. Operations are simple as increasing by one.
     *  - In fact, it is divided into three parts reading, increasing, and writing. Given the fact that we have three operations, 
     *    two threads can execute them in such a way that even if we increase the value of a variable twice, only one increase 
     *    takes effect.
     ** How to Solve the above Problem in C#? (Try to update the variable simultaneously)
     *  - Interlocked in C#:
     *      + The Interlocked Class in C# allows us to perform certain operations in an atomic way, which makes this operation 
     *        safe to do from different threads on the same variable. That means Interlocked class gives us a few methods that 
     *        allow us to perform certain operations safely or atomically, even if the code is going to be executed by several 
     *        threads simultaneously.
     *  - Lock in C#:
     *      + we can have a block of code that will only be executed by one thread at a time. That is, we limit a part of our 
     *        code to be sequential, even if several threads try to execute that code at the same time. We use locks when we need
     *        to perform several operations or an operation not covered by Interlocked.
     *      + Something important to take into account is that ideally what we do inside a lock block should be relatively fast. 
     *        This is because the threads are blocked while waiting for the release of the lock. And if you have multiple threads 
     *        blocked for a longer period of time, this can have an impact on the speed of your application.
     ** What is Interlocked Class in C#?
     *  - Following are the methods provided by the C# Interlocked class:
     *      1. Increment(): This method is used to increment a variable’s value and store its result. Int32 and Int64 integers 
     *         are its legal parameters.
     *      2. Increment(): This method is used to increment a variable’s value and store its result. Int32 and Int64 integers 
     *         are its legal parameters.
     *      3. Exchange(): This method is used to exchange values between variables. This method has seven overloaded versions 
     *         based on the different types it can accept as its parameter
     *      4. CompareExchange(): This method compares two variables and stores the result of the comparison in another variable.
     *         This method also has seven overloaded versions
     *      5. Add(): This method is used to add two integer variables and update the result in the first integer variable. It is 
     *         used to add integers of type Int32 as well as Int64.
     *      6. Read(): This method is used to reads an integer variable. It is used to read an integer of type Int64.
     */
    #endregion

    #region Example to understand Interlocked 
    // First, we will see the example without using Interlocked and see the problem, and then we will rewrite the same example
    // using Interlocked and will see how interlocked solve the thread safety problem.

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var ValueWithoutInterlocked = 0;
    //        Parallel.For(0, 100000, i =>
    //        {
    //            //Incrementing the value
    //            ValueWithoutInterlocked++;
    //        });
    //        Console.WriteLine("Expected Result: 100000");
    //        Console.WriteLine($"Actual Result: {ValueWithoutInterlocked}");
    //        Console.ReadKey();
    //    }
    //}
    // Now, run the above code multiple times and you will get different results each time

    // The Increment method increments a specified variable and stores the result, as an atomic operation. So, here we need to
    // specify the variable with the ref keyword as shown in the below example.

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var ValueInterlocked = 0;
    //        Parallel.For(0, 100000, _ =>
    //        {
    //            //Incrementing the value
    //            Interlocked.Increment(ref ValueInterlocked);
    //        });
    //        Console.WriteLine("Expected Result: 100000");
    //        Console.WriteLine($"Actual Result: {ValueInterlocked}");
    //        Console.ReadKey();
    //    }
    //}
    // So, the Interlocked Class provides atomic operations for variables that are shared by multiple threads. That means the
    // synchronization mechanism Interlocked allows us to avoid having race conditions by making the increment operation Atomic.
    #endregion

    #region Example to Understand the Lock
    //class Program
    //{
    //    static object lockObject = new object();

    //    static void Main(string[] args)
    //    {
    //        var ValueWithLock = 0;
    //        Parallel.For(0, 100000, _ =>
    //        {
    //            lock (lockObject)
    //            {
    //                //Incrementing the value
    //                ValueWithLock++;
    //            }
    //        });
    //        Console.WriteLine("Expected Result: 100000");
    //        Console.WriteLine($"Actual Result: {ValueWithLock}");
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region InterLocked.Add Method
    // There are two overloaded versions of the Add method available in Interlocked Class.They are as follows:
    // 1. public static long Add(ref long location1, long value): This method adds two 64-bit integers and replaces the first integer
    //    with the sum, as an atomic operation.
    // 2. public static int Add(ref int location1, int value): This method adds two 32-bit integers and replaces the first integer with
    //    the sum, as an atomic operation.It returns the new value stored at location1.
    // - The following are the Parameters:
    // 1. location1: A variable containing the first value to be added.The sum of the two values is stored in location1.
    // 2. value: The value to be added to the location1 variable.
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        long SumValueWithoutInterlocked = 0;
    //        long SumValueWithInterlocked = 0;
    //        Parallel.For(0, 100000, number =>
    //        {
    //            SumValueWithoutInterlocked = SumValueWithoutInterlocked + number;
    //            Interlocked.Add(ref SumValueWithInterlocked, number);
    //        });

    //        Console.WriteLine($"Sum Value Without Interlocked: {SumValueWithoutInterlocked}");
    //        Console.WriteLine($"Sum Value With Interlocked: {SumValueWithInterlocked}");

    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region Exchange and CompareExchange Method of Interlocked Class:
    // The Exchange method of Interlocked Class in C# is atomically exchanging the values of the specified variables. The second
    // value could be a hard-coded value or a variable. Only the first variable in the first parameter will be replaced by the second.

    // The CompareExchange method of Interlocked Class in C# is used to combine two operations. Comparing two values and storing the
    // third value in one of the variables, based on the outcome of the comparison. If both are equal then replace the one used as the
    // first parameter with the supplied value

    class Program
    {
        static long x;
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(SomeMethod));
            thread1.Start();
            thread1.Join();

            // Written [20]
            Console.WriteLine(Interlocked.Read(ref Program.x));

            Console.ReadKey();
        }

        static void SomeMethod()
        {
            // Replace x with 20.
            Interlocked.Exchange(ref Program.x, 20);

            // CompareExchange: if x is 20, then change to current DateTime.Now.Day or any integer variable.
            long result = Interlocked.CompareExchange(ref Program.x, DateTime.Now.Day, 20);
            //long result = Interlocked.CompareExchange(ref Program.x, 50, 20);

            // Returns original value from CompareExchange
            Console.WriteLine(result);
        }
    }
    #endregion
    #endregion
}


