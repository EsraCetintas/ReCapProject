using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [SecuredOperation("user")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarExists(rental.CarId), CheckRentalDate(rental));
            if (result!=null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("user")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Rental>();
            }
            return new SuccessDataResult<Rental>(result);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [SecuredOperation("user")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId).Data;
            if (result == null)
            {
                return new ErrorResult(Messages.CarNotExists);
            }
            return new SuccessResult();

        }

        private IResult CheckRentalDate(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach(var result in results)
            {
                if (rental.ReturnDate == null)
                {
                    return new ErrorResult(Messages.NotRental);
                }
                else if ((rental.RentDate <= result.RentDate) && (rental.ReturnDate <= result.ReturnDate))
                {
                    return new ErrorResult(Messages.NotRental);
                }
                else if ((rental.RentDate <= result.RentDate) && (rental.ReturnDate >= result.ReturnDate))
                {
                    return new ErrorResult(Messages.NotRental);
                }
                else if ((rental.RentDate >= result.RentDate) && (rental.ReturnDate <= result.ReturnDate))
                {
                    return new ErrorResult(Messages.NotRental);
                }
            }

            return new SuccessResult();
        }
    }
}
