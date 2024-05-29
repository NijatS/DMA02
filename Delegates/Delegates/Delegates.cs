using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
	public class Delegates
	{
		public delegate void Delegate();

		public List<string> names = new List<string>()
		{
			"Name1","Name21","Name3"
		};
		//*Create a multicast delegate that calls two methods: one that prints a message and another that prints the current date and time.

	   public void RunDelegate()
		{
			Delegate testDelegate = new(() =>
			{
				Console.WriteLine("Hello,World!");
			});

			testDelegate += () =>
			{
				Console.WriteLine(DateTime.Now);
			};


			//foreach (string name in names)
			//{
			//	if (name.Contains('1'))
			//		Console.WriteLine(name);
			//}

			//names = names.Where(name => name.StartsWith('A')).ToList();

			//foreach (string name in names) 
			//	Console.WriteLine(name);



			testDelegate.Invoke();
		}
	}
}
