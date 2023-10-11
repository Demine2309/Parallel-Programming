using System.Threading;

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
     *
     */
    #endregion

    #region Parrallel For Loop in C#:
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    #endregion
    #endregion
}

