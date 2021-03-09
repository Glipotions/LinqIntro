using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqIntro
{
	class Program
	{
		static void Main(string[] args)
		{

			List<Category> categories = new List<Category>()
			{
				new Category{CategoryId=1,CategoryName="Hatchback"},
				new Category{CategoryId=2,CategoryName="Ticari"}
			};

			List<Car> cars = new List<Car>{
				new Car{Id=1,CarName="BMW",CategoryId=1,DailyPrice=128000,ModelYear=2010,Description="Sport Car" },
				new Car{Id=2,CarName="SKODA",CategoryId=1,DailyPrice=130000,ModelYear=2012,Description="Sport Car" },
				new Car{Id=3,CarName="FORD",CategoryId=2,DailyPrice=95000,ModelYear=2015,Description="Van" },
				new Car{Id=4,CarName="BMW",CategoryId=2,DailyPrice=116000,ModelYear=2018,Description="Minibüs" },
				new Car{Id=5,CarName="MERCEDES",CategoryId=2,DailyPrice=145000,ModelYear=2019,Description="Sport Car" }
			};

			//Test(cars);

			//AnyTest(cars);

			//FindTest(cars);

			//FindAllTest(cars);

			//AscDescTest(cars);

			//QueryTypeTest(cars);

			//ClassicLinqTest(cars);

			var result = from c in cars
						 join cg in categories
						 on c.CategoryId equals cg.CategoryId
						 where c.ModelYear>2011
						 orderby c.DailyPrice
						 select new CarDto { Id = c.Id,CategoryName=cg.CategoryName,CarName = c.CarName, DailyPrice = c.DailyPrice };
			foreach (var car in result)
			{
				//Console.WriteLine(car.CarName+" - "+car.CategoryName);
				Console.WriteLine("{0} -- {1}",car.CarName,car.CategoryName);
			}

		}

		private static void ClassicLinqTest(List<Car> cars)
		{
			var result = from c in cars
						 where c.DailyPrice > 120000
						 orderby c.DailyPrice descending, c.CarName ascending
						 select new CarDto { Id = c.Id, CarName = c.CarName, DailyPrice = c.DailyPrice };
			foreach (var car in result)
			{
				Console.WriteLine(car.CarName);
			}
		}

		private static void QueryTypeTest(List<Car> cars)
		{
			var result = from c in cars
						 where c.DailyPrice > 120000
						 orderby c.DailyPrice descending, c.CarName ascending
						 select c;
			foreach (var car in result)
			{
				Console.WriteLine(car.CarName);
			}
		}

		private static void AscDescTest(List<Car> cars)
		{
			var result = cars.Where(c => c.Description.Contains("Sport")).OrderBy(c => c.DailyPrice).ThenByDescending(c => c.ModelYear);
			foreach (var car in result)
			{
				Console.WriteLine(car.CarName);
			}
		}

		private static void FindAllTest(List<Car> cars)
		{
			var result = cars.FindAll(c => c.Description.Contains("Spor"));
			Console.WriteLine(result.Count);
		}

		private static void FindTest(List<Car> cars)
		{
			var result = cars.Find(c => c.Id == 2);
			Console.WriteLine(result.CarName);
		}

		private static void AnyTest(List<Car> cars)
		{
			var result = cars.Any(c => c.CarName == "BMW");
			Console.WriteLine(result);
		}

		private static void Test(List<Car> cars)
		{
			var result = cars.Where(c => c.DailyPrice > 120000 && c.ModelYear > 2011);
			foreach (var car in cars)
			{
				Console.WriteLine(car.CarName);
			}
		}



	}
	public class CarDto
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string CarName { get; set; }
		public double DailyPrice { get; set; }
	}

	public class Car
	{
		public int Id { get; set; }
		public string CarName { get; set; }
		public int CategoryId { get; set; }
		public int ModelYear { get; set; }
		public double DailyPrice { get; set; }
		public string Description { get; set; }

	}

	public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}


}
