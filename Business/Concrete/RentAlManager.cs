using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentAlManager : IRentAlService
    {
        IRentAlDal _rentAlDal;

        public RentAlManager(IRentAlDal rentAlDal)
        {
            _rentAlDal = rentAlDal;
        }

        public IResult Add(RentAl rentAl)
        {
            var result = CheckReturnDate(rentAl.CarId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentAlDal.Add(rentAl);
            return new SuccessResult(result.Message);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentAlDal.GetRentAlDetails(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(RentAl rentAl)
        {
            _rentAlDal.Delete(rentAl);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<RentAl>> GetAll()
        {
            return new SuccessDataResult<List<RentAl>>(_rentAlDal.GetAll());
        }

        public IDataResult<RentAl> GetById(int id)
        {
            return new SuccessDataResult<RentAl>(_rentAlDal.Get(r => r.RentAlId == id));
        }

        public IDataResult<List<RentAlDetailDto>> GetRentAlDetailsDto(int carId)
        {
            return new SuccessDataResult<List<RentAlDetailDto>>(_rentAlDal.GetRentAlDetails(r => r.CarId == carId));
        }

        public IResult Update(RentAl rentAl)
        {
            _rentAlDal.Update(rentAl);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentAlDal.GetAll(r => r.CarId == carId);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalUpdatedReturnDateError);
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentAlDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalUpdatedReturnDate);
        }
    }
}
