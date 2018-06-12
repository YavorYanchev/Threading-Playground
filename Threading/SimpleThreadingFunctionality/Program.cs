using System;
using System.Threading;

namespace SimpleThreadingFunctionality
{
    class Program
    {
        static void Main(string[] args)
        {
	        Console.WriteLine("Main thread: Start a second thread.");
			var t = new Thread(ThreadProc);
			t.Start();
			//Thread.Sleep(0);

	        for (var i = 0; i < 4; i++)
	        {
		        Console.WriteLine("Main thread: Do some work.");
		        Thread.Sleep(0);
	        }

	        Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
	        t.Join();
	        Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
	        Console.ReadLine();
		}

	    public static void ThreadProc()
	    {
		    for (var i = 0; i < 10; i++)
		    {
			    Console.WriteLine("ThreadProc: {0}", i);
			    // Yield the rest of the time slice.
			    Thread.Sleep(0);
		    }
	    }
	}
}
