using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarAddTest(carManager);
            CarGetAllTest(carManager);

            //CarDeleteTest(carManager);
            //Console.WriteLine("------------->");
            //CarGetAllTest(carManager);



            Console.WriteLine("------------->");

            CarUpdateTest(carManager);


            foreach (var b in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(b.Description);
            }

            Console.WriteLine("b");

            foreach (var c in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(c.Description);
            }

        }

        private static void CarUpdateTest(CarManager carManager)
        {
            carManager.Update(new Car { Id = 1, BrandId = 0 });
        }

        private static void CarDeleteTest(CarManager carManager)
        {
            //id değiştiriniz
            carManager.Delete(new Car { Id = 2, BrandId =0, ColorId = 1, ModelYear = 2020, DailyPrice = 350, Description = "Mercedes" });
        }

        private static void CarGetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("araç id/ "+car.Id);
            }
        }

        private static void CarAddTest(CarManager carManager)
        {
            carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 0, ModelYear = 2020, DailyPrice = 0, Description = "Audi" });
        }
    }
}
