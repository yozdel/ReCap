using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear=2015,Description="2.0 Motor 250 Beygir"},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=150,ModelYear=2016,Description="3.0 Motor 300 Beygir"},
                new Car{CarId=3,BrandId=2,ColorId=3,DailyPrice=80,ModelYear=2018,Description="1.4 Motor 130 Beygir"},
                new Car{CarId=4,BrandId=2,ColorId=4,DailyPrice=200,ModelYear=2015,Description="3.0 Motor 350 Beygir"},
                new Car{CarId=5,BrandId=2,ColorId=5,DailyPrice=500,ModelYear=2020,Description="4.6 Motor 650 Beygirr"},
                new Car{CarId=6,BrandId=3,ColorId=2,DailyPrice=125,ModelYear=2019,Description="2.2 Motor 250 Beygir"},
                new Car{CarId=7,BrandId=3,ColorId=3,DailyPrice=110,ModelYear=2017,Description="2.0 Motor 200 Beygir"},
                new Car{CarId=8,BrandId=4,ColorId=2,DailyPrice=150,ModelYear=2016,Description="2.0 Motor 250 Beygir"},
                new Car{CarId=9,BrandId=4,ColorId=1,DailyPrice=100,ModelYear=2018,Description="1.6 Motor 156 Beygir"},
                new Car{CarId=10,BrandId=4,ColorId=5,DailyPrice=110,ModelYear=2016,Description="2.0 Motor 250 Beygir"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car productToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(productToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            Car car = _cars.SingleOrDefault(c => c.CarId == carId);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == c.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
