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
            //carManager.Add(new Car {CarId=4,BrandId=2,ColorId=1,DailyPrice=0,ModelYear=2015,Description="jfdgfdgd" });
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }

           // Console.WriteLine(carManager.GetById(1).Description);
        }
    }
}
