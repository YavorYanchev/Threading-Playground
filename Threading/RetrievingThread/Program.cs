using System;
using System.Threading;

namespace RetrievingThread
{
    class Program
    {
	    private static Object obj = new Object();
        static void Main(string[] args)
        {
	        ThreadPool.QueueUserWorkItem(ShowThreadInformation);
			var th1 = new Thread(ShowThreadInformation);
			th1.Start();
        }

	    private static void ShowThreadInformation(Object state)
	    {
		    lock (obj)
		    {
			    var th = Thread.CurrentThread;
			    Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
			    Console.WriteLine("   Background thread: {0}", th.IsBackground);
			    Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
			    Console.WriteLine("   Priority: {0}", th.Priority);
			    Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
			    Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
			    Console.WriteLine();
			}
	    }
    }
}
