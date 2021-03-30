using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            CarAddTest(carManager);
            CarGetAllTest(carManager);
            Console.WriteLine("------------->");
            CarDeleteTest(carManager);

            Console.WriteLine("BrandId");

            CarGetAllBrandId(carManager);

            Console.WriteLine("------------->");

            CarUpdateTest(carManager);

            CarGetAllBrandId(carManager);

        }

        private static void CarGetAllBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
        }

        private static void CarUpdateTest(CarManager carManager)
        {
            carManager.Update(new Car { Id = 6, BrandId = 30 });
        }

        private static void CarDeleteTest(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 7, BrandId = 15, ColorId = 1, ModelYear = 2020, DailyPrice = 350, Description = "Kiralık Araç" });
        }

        private static void CarGetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }
        }

        private static void CarAddTest(CarManager carManager)
        {
            carManager.Add(new Car { Id = 6, BrandId = 5, ColorId = 0, ModelYear = 2012, DailyPrice = 250, Description = "Kiralık Araç" });
            carManager.Add(new Car { Id = 7, BrandId = 15, ColorId = 1, ModelYear = 2020, DailyPrice = 350, Description = "Kiralık Araç" });
        }
    }
}
