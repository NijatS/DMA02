using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Text;

namespace LINQQueries
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Filtering a list of numbers to find even numbers(Easy)

			List<int> numbers = new List<int> { 1, 2, 3, 5, 6, 78, 2, 53, 8 };


			List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();


			//foreach (int number in evenNumbers)
			//	Console.WriteLine(number);



			//Projecting a list of strings to their lengths(Easy)

			List<string> strings = new() { "Text", "Text1", "Text12", "Text123" };

			List<int> lengths = strings.Select(x => x.Length).ToList();



			//lengths.ForEach(x => Console.WriteLine(x));

			//Sorting a list of people by age(Easy)



			List<Person> persons = new()
			{
			new Person()
			{
				Id= 1,
				Name = "Rubay",
				Age = 24
			},
			new Person()
			{
				Id= 2,
				Name = "Samir",
				Age = 25
			},
			new Person()
			{
				Id= 3,
				Name = "Nizameddin",
				Age = 21
			},
			new Person()
			{
				Id= 4,
				Name = "Asad",
				Age= 23
			},
			new Person()
			{
				Id= 5,
				Name = "Rahman Abi",
				Age = 26
			},
			new Person()
			{
				Id= 6,
				Name = "Murad",
				Age = 27
			},
			new Person()
			{
				Id= 7,
				Name = "Şabnam",
				Age  = 29
			},
			new Person()
			{
				Name = "Rustam",
				Age = 22
			},
			new Person()
			{
				Name = "Aynur",
				Age = 30
			},
			new Person()
			{
				Name = "Nahid",
				Age = 21
			},
			new Person()
			{
				Name = "Nijat",
				Age = 21
			},
			new Person()
			{
				Name = "Nurlan",
				Age = 24
			}
			};

			//people = people.OrderBy(p => p.Age).ToList();

			//foreach(Person person in people) 
			//	Console.WriteLine($"Name:{person.Name}  Age:{person.Age}");


			//Finding the sum of a list of integers(Easy)

			//Console.WriteLine("Sum of numbers: " + numbers.Sum());

			//Finding the maximum age in a list of people(Medium)

			// Console.WriteLine(people.Max(p => p.Age));

			//Calculating the average age of people(Medium)

			//Console.WriteLine(people.Average(p=>p.Age));



			//Finding all people whose names start with a specific letter(Hard)

			List<Person> personListSWN = persons.Where(p => p.Name.StartsWith('N')).ToList();

			List<Person> personListCWN = persons.Where(p => p.Name.Contains('N')).ToList();

			List<Person> personListEWN = persons.Where(p => p.Name.ToLower().EndsWith(char.ToLower('N'))).ToList();


			//personListEWN.ForEach(person => Console.WriteLine($"Name:{person.Name}  Age:{person.Age}"));





			//Getting the first element in a list that satisfies a condition(Easy)


			Person? personAge21 = persons.Where(p => p.Age == 21).FirstOrDefault();

			//if (personAge21 != null)
			//	Console.WriteLine($"Name:{personAge21.Name}  Age:{personAge21.Age}");




			List<Person>? peopleAge21 = persons.Where(p => p.Age == 21).Skip(1).Take(2).ToList();

			//foreach (var person in peopleAge21)
			//	Console.WriteLine($"Name:{person.Name}  Age:{person.Age}");


			//Skipping elements while a condition is true and then taking the rest(Easy)  SkipWhile

			numbers = new List<int> { 5, 10, 3, 5, 6, 10, 2, 15, 8 };

			//List<int> newNumbers =  numbers.Where(n=>n % 5 != 0).ToList();

			List<int> newNumbers = numbers.SkipWhile(n => n % 5 == 0).ToList();

			//newNumbers.ForEach(n => Console.WriteLine(n));


			//Selecting distinct values from a list (Medium)

			List<int> distinctNumbers = numbers.Distinct().ToList();
			//distinctNumbers.ForEach(n => Console.WriteLine(n));


			//Concatenating two lists(Medium)


			List<int> secondList = new() { 4, 6, 8, 9 };

			List<int> concatList = numbers.Concat(secondList).Distinct().ToList();

			//concatList.ForEach(n => Console.WriteLine(n));



			//Reversing a list(Medium)


			numbers.Reverse();

			List<int> ReverseNumbers = numbers;
			//ReverseNumbers.ForEach(n => Console.WriteLine(n));



			//Finding the person with the minimum age in a list(Hard)

			persons.Min(p => p.Age);
			Person person = persons.Where(p => p.Age == persons.Min(p => p.Age)).FirstOrDefault();

			//if (person != null)
			////Console.WriteLine($"Name:{person.Name}  Age:{person.Age}");




			//Checking if any elements in a list match a condition(Easy) 5-e bolunen


			//Console.WriteLine(numbers.Any(n => n % 21 == 0));


			//Selecting a range of elements(Medium) Skip Take

			//people.Skip(5).Take(5).ToList().ForEach(p => Console.WriteLine($"{p.Name} {p.Age}"));

			//Checking if all elements in a list match a condition(Medium)

			//Console.WriteLine(numbers.All(num => num%3 ==0));


			//Creating a list of custom objects with LINQ(Medium)   new Person { Name = "John", Age = 30 }, Select
			//var anonynmPeople = people.Select(p => new
			//{
			//	Name = p.Name,
			//	Age = p.Age,
			//	Grade = 90
			//}).ToList();

			//anonynmPeople.ForEach(p => Console.WriteLine(p.Grade));
			//Performing an inner join with complex objects(Hard) Student Grade


			List<Grade> grades = new List<Grade>()
			{
				new Grade()
				{
					StudentId = 1,
					Point = 95
				},
				new Grade() {
					StudentId = 2,
					Point = 90
				}
			};





			var query = from grade in grades
						join people in persons
						on grade.StudentId equals people.Id
						select new
						{
							people.Id,
							people.Name,
							grade.Point
						};


			query.ToList().ForEach(p =>
			{
                Console.WriteLine($"ID:{p.Id}  Name:{p.Name}   Point:{p.Point}");
            });


			//Finding the last element in a list that satisfies a condition(Easy)
			//Selecting specific properties from a list of objects(Medium)
			//Finding the average value in a list(Easy)
			//Selecting elements until a condition is met(Medium) TakeWhile
			//Selecting the top N elements from a list(Medium)


		}
	}
}
