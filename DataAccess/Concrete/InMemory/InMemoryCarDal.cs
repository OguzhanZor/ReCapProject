using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=15,ModelYear="1995",DailyPrice=150,Description="Acıklama"},
                new Car {Id=2,BrandId=2,ColorId=68,ModelYear="1996",DailyPrice=12,Description="Acıklama"},
                new Car {Id=3,BrandId=2,ColorId=25,ModelYear="1997",DailyPrice=1852,Description="Acıklama"},
                new Car {Id=4,BrandId=1,ColorId=17,ModelYear="1998",DailyPrice=1954,Description="Acıklama"},
                new Car {Id=5,BrandId=2,ColorId=12,ModelYear="1999",DailyPrice=160,Description="Acıklama"}
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<CarDetailDto> CarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            Car carToGet = _cars.SingleOrDefault(p => p.Id == id);
            return carToGet;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }


    }
}
