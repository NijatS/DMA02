using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace Delegates
{
	internal class Program
	{
		public delegate void GreetDelegate(string name);
		public delegate int SumTwoIntegersDeleagete(int num1,int num2);
		public delegate T SumTwoNumbersDelegates<T>(T num1,T num2);
		static void Main(string[] args)
		{
			//*Create a delegate that takes a string as a parameter and prints a greeting message.
			//*Create a delegate that takes two integers and returns their sum.
			//*Use an anonymous method with a delegate that prints a message.
			//*Use a generic delegate that can work with different data types.


			GreetDelegate greetDelegate = new GreetDelegate(PrintHello); //Method
			GreetDelegate greetDelegate2 = new GreetDelegate((string name) =>
			{
				Console.WriteLine($"Greet {name}2");
			}); //AnonymousMethod


			SumTwoIntegersDeleagete sumTwoIntegersDeleagete = new SumTwoIntegersDeleagete((int num1, int num2) =>
			{
				return num1 + num2;
			});



			SumTwoNumbersDelegates<double> delegates = new((double num1, double num2) =>
			{
				return num1 + num2;
			});



			//Console.WriteLine(delegates(1.5, 8.7));





			//greetDelegate("Test");
			//greetDelegate2.Invoke("Test");
			//Console.WriteLine(sumTwoIntegersDeleagete(5, 5));


			Delegates delegates1 = new();

			delegates1.RunDelegate();




		}

		static void PrintHello(string name)
			=> Console.WriteLine($"Greet {name}");
	}
}
