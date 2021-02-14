using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentAlService
    {
        IDataResult<List<RentAl>> GetAll();
        IDataResult<RentAl> GetById(int id);
        IDataResult<List<RentAlDetailDto>> GetRentAlDetailsDto(int carId);
        IResult Add(RentAl rentAl);
        IResult Update(RentAl rentAl);
        IResult Delete(RentAl rentAl);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
    }
}
