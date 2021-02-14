using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal());
            GetAllMethod(carService);
            GetByIdMethot(carService);

          

        }
        static void GetAllMethod(ICarService carService)
        {
            var result = carService.CarDetailDtos();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {   //Console.WriteLine(item.Id + " " + item.ModelYear + " " + item.BrandId + " " + item.ColorId + " " + item.DailyPrice + " " + item.Description);
                    Console.WriteLine(item.BrandName + " " + item.ColorName + " " + item.DailyPrice);
                }

            }
            else
                Console.WriteLine(result.Message);

            Console.WriteLine("Hello World!");
        }

        static void GetByIdMethot(ICarService carService)
        {
           
            var result = carService.GetById(1);
            if (result.Success)
            {
                Console.WriteLine(result.Data.Id + " " + result.Data.ModelYear + " " + result.Data.Description);

            }
            else
                Console.WriteLine(result.Message);
        }
    }
}
