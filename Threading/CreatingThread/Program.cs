using System;
using System.Threading;

namespace CreatingThread
{
	public class Program
    {
	    public static void Main()
        {
			var serverObject = new ServerClass();

			var instanceCaller = new Thread(serverObject.InstanceMethod);

			instanceCaller.Start();
	        Console.WriteLine("The Main() thread calls this after "
	                          + "starting the new InstanceCaller thread.");

			var staticCaller = new Thread(ServerClass.StaticMethod);

			//Start the thread
			staticCaller.Start();

	        Console.WriteLine("The Main() thread calls this after "
	                          + "starting the new StaticCaller thread.");
		}
    }

	public class ServerClass
	{
		// The method that will be called when the thread is started.
		public void InstanceMethod()
		{
			Console.WriteLine(
				"ServerClass.InstanceMethod is running on another thread.");

			// Pause for a moment to provide a delay to make
			// threads more apparent.
			Thread.Sleep(3000);
			Console.WriteLine(
				"The instance method called by the worker thread has ended.");
		}

		public static void StaticMethod()
		{
			Console.WriteLine(
				"ServerClass.StaticMethod is running on another thread.");

			// Pause for a moment to provide a delay to make
			// threads more apparent.
			Thread.Sleep(5000);
			Console.WriteLine(
				"The static method called by the worker thread has ended.");
		}
	}
}
