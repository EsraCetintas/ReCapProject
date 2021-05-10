using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal: EfEntityRepositoryBase<Rental, ReCapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id

                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id

                             join user in context.Users
                             on customer.UserId equals user.Id

                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join color in context.Colors
                             on car.ColorId equals color.Id



                             select new RentalDetailDto
                             {
                                 RentalId = rental.Id,
                                 CarId = car.Id,
                                 CustomerId = customer.Id,
                                 Brand = brand.Name,
                                 Color = color.Name,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 DailyPrice=car.DailyPrice,
                                 ModelYear=car.ModelYear,
                                 Email = user.Email,
                                 RentDate = rental.RentDate,
                                 ReturnDate = (DateTime)rental.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
