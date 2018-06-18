using System;
using System.Threading;

namespace PassingAndRetrievingDataFromThreads
{

	class ThreadWithState
	{
		private readonly string _boilerplate;
		private readonly int _value;

		//obtains state information
		public ThreadWithState(string text, int number)
		{
			_boilerplate = text;
			_value = number;
		}

		public void ThreadProc()
		{
			Console.WriteLine(_boilerplate, _value);
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
			//Using ParameterizedTHreadStart delegate is not a type-safe way to pass data,
			//because Thread.Start method overload accepts any object.

			//Alternative is to encapsulate the thread procedure and the data in a helper class
			//and to use ThreadStart delegate to execute the thread procedure.

			//supply state information required by the task.
			var tws = new ThreadWithState("This report displays the number {0}.", 42);

	        var t = new Thread(tws.ThreadProc);
			t.Start();
	        Console.WriteLine("Main thread does some work, then waits.");
	        t.Join();
	        Console.WriteLine("Independent task has completed; main thread ends.");
        }
    }
}
