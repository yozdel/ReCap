using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentAlDal : EfEntityRepositoryBase<RentAl, ReCapContext>, IRentAlDal
    {
        public List<RentAlDetailDto> GetRentAlDetails(Expression<Func<RentAl, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in filter is null ? context.RentAls : context.RentAls.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentAlDetailDto
                             {
                                 UserName = u.FirstName + " " + u.LastName,
                                 CarId = c.CarId,
                                 CarName = c.Description,
                                 CustomerName = cu.CompanyName,
                                 RentAlDetailId = r.RentAlId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                                 //Id = r.Id,
                                 //CarName = c.Name,
                                 //CustomerName = cu.CompanyName,
                                 //CarId = c.Id,
                                 //RentDate = r.RentDate,
                                 //ReturnDate = r.ReturnDate,
                                 //UserName = u.FirstName + " " + u.LastName

                             };

                return result.ToList();
            }
        }
    }
}
