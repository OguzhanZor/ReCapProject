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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DbReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> RentalDetailDtos()
        {
            using (DbReCapContext context = new DbReCapContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rental.Id,
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 CustomerId = customer.Id,
                                 UserId = user.Id,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                var qq = result.ToList();
                return qq;
            }
        }
    }
}


