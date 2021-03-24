using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbReCapContext>, ICarDal
    {
        public string aaaaa() { return "dsadsa"; }
        public List<CarDetailDto> CarDetailDtos()
        {
            using (DbReCapContext context = new DbReCapContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                             on p.BrandId equals b.Id
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 ModelYear = p.ModelYear,
                                 ColorId = c.Id,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice,
                                 Description=p.Description
                             };
                return result.ToList();
            }
        }
    }
}
