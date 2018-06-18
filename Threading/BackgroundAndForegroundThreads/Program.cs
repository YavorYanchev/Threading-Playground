using System;
using System.Threading;

namespace BackgroundAndForegroundThreads
{
    class Program
    {
	    public static void Main()
        {
			var shortTest = new BackgroundTest(10);
			var foregroundThread = new Thread(shortTest.RunLoop);

			var longTest = new BackgroundTest(50);
			var backgroundThread = new Thread(longTest.RunLoop);
	        backgroundThread.IsBackground = true;

			foregroundThread.Start();
			backgroundThread.Start();
        }
    }

	class BackgroundTest
	{
		private readonly int _maxIterations;

		public BackgroundTest(int maxIterations)
		{
			_maxIterations = maxIterations;
		}

		public void RunLoop()
		{
			for (int i = 0; i < _maxIterations; i++)
			{
				Console.WriteLine("{0} count: {1}",
					Thread.CurrentThread.IsBackground ?
						"Background Thread" : "Foreground Thread", i);
				Thread.Sleep(250);
			}
			Console.WriteLine("{0} finished counting.",
				Thread.CurrentThread.IsBackground ?
					"Background Thread" : "Foreground Thread");
		}
	}
}
