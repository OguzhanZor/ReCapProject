using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());
            GetAllMethod(carService);
            GetByIdMethot(carService);

          

        }
        static void GetAllMethod(ICarService carService)
        {
            foreach (var item in carService.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.ModelYear + " " + item.BrandId + " " + item.ColorId + " " + item.DailyPrice + " " + item.Description);
            }
            Console.WriteLine("Hello World!");
        }

        static void GetByIdMethot(ICarService carService)
        {
            var car = carService.GetById(2);
            Console.WriteLine(car.Id + " " + car.ModelYear + " " + car.Description);
        }
    }
}
