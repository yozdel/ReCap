using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentAlDal : IEntityRepository<RentAl>
    {
        List<RentAlDetailDto> GetRentAlDetails(Expression<Func<RentAl, bool>> filter = null);
    }
}
