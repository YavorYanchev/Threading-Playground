using System;
using System.Threading;

namespace LockStatement
{
	public class Account
	{
		private decimal _balance;
		private readonly object _thisLock = new object();

		Random r = new Random();

		public Account(decimal initial)
		{
			_balance = initial;
		}


		public decimal Withdraw(decimal amount)
		{
			if (_balance < 0)
			{
				throw new Exception("Negative Balance");
			}

			lock (_thisLock)
			{
				if (_balance >= amount)
				{
					Console.WriteLine("Balance before Withdrawal : " + _balance);
					Console.WriteLine("Amount to Withdraw : -" +  amount);
					_balance -= amount;
					Console.WriteLine("Balance after Withdrawal : " + _balance);
					return amount;
				}
				else
				{
					return 0; //transaction rejected
				}
			}
		}

		public void DoTransactions()
		{
			for (int i = 0; i < 20; i++)
			{
				Withdraw(r.Next(1, 100));
			}
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
	        var threads = new Thread[10];
			var account = new Account(1000);
	        for (int i = 0; i < 10; i++)
	        {
		        var t = new Thread(account.DoTransactions);
		        threads[i] = t;
	        }

	        for (int i = 0; i < 10; i++)
	        {
		        threads[i].Start();
	        }

			//block main thread until all other threds have run to completion.
	        foreach (var t in threads)
		        t.Join();
        }
    }
}
