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
            //CarManager carManager = new CarManager(new EfCarDal());
            //CarAddTest(carManager);
            //CarGetAllTest(carManager);
            //CarDeleteTest(carManager);
            //CarUpdateTest(carManager);
            //CarsByBrandIdTest(carManager);
            //Console.WriteLine("------------->");
            //CarGetAllTest(carManager);
            //CarsByColorId(carManager);
            //CarGetDetailsTest(carManager);


            //ColorManager color = new ColorManager(new EfColorDal());
            //ColorAddTest(color);
            //ColorGetAllTest(color);
            //color.Update(new Color { Id = 5, Name = "Green" });
            //color.Delete(new Color { Id =5 });//id değiştiriniz...
            //var resultColor = color.GetById(1);
            //Console.WriteLine(resultColor.Name);


            //BrandManager brand = new BrandManager(new EfBrandDal());
            //BrandAddTest(brand);
            //BrandGetAll(brand);
            //brand.Update(new Brand { Id = 4, Name = "BMW" });
            //brand.Delete(new Brand { Id = 4 });//id değiştiriniz...
            //BrandGetAll(brand);
            //var resultBrand = brand.GetById(3);
            //Console.WriteLine(resultBrand.Name);


        }

        private static void CarGetDetailsTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarName + " " + c.BrandName + " " + c.ColorName + " " + c.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message); 
            }
        }

        private static void BrandAddTest(BrandManager brand)
        {
            brand.Add(new Brand { Id = 1, Name = "Mercedes" });
            brand.Add(new Brand { Id = 2, Name = "Range Rover" });
            brand.Add(new Brand { Id = 3, Name = "Audi" });
            brand.Add(new Brand { Id = 4, Name = "Hundai" });
        }

        private static void BrandGetAll(BrandManager brand)
        {
            var result = brand.GetAll();
            if (result.Success)
            {
                foreach (var b in result.Data)
                {
                    Console.WriteLine(b.Id + " " + b.Name);
                }
            }
            
        }

        private static void ColorGetAllTest(ColorManager color)
        {
            foreach (var clr in color.GetAll().Data)
            {
                Console.WriteLine(clr.Id + " " + clr.Name);
            }
        }

        private static void ColorAddTest(ColorManager color)
        {
            color.Add(new Color { Id = 1, Name = "Red" });
            color.Add(new Color { Id = 2, Name = "Blue" });
            color.Add(new Color { Id = 3, Name = "White" });
            color.Add(new Color { Id = 4, Name = "Gray" });
        }

        private static void CarsByColorId(CarManager carManager)
        {
            foreach (var c in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(c.Description);
            }
        }

        private static void CarsByBrandIdTest(CarManager carManager)
        {
            foreach (var b in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(b.Description);
            }
        }

        private static void CarUpdateTest(CarManager carManager)
        {
            carManager.Update(new Car { Id = 1, BrandId = 0,Description="kiralık" });
            carManager.Update(new Car { Id = 2, Description = "kiralık" });
            carManager.Update(new Car { Id = 3, Description = "kiralık" });
        }

        private static void CarDeleteTest(CarManager carManager)
        {
            //id değiştiriniz
            carManager.Delete(new Car { Id = 1});
            carManager.Delete(new Car { Id = 2 });
            carManager.Delete(new Car { Id = 3 });
        }

        private static void CarGetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("araç id/ "+car.Id);
            }
        }

        private static void CarAddTest(CarManager carManager)
        {
            carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 450, Description = "kiralık" });
            carManager.Add(new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 350, Description = "kiralık" });
            carManager.Add(new Car { Id = 3, BrandId = 3, ColorId = 1, ModelYear = 2009, DailyPrice = 250, Description = "kiralık" });
        }
    }
}
