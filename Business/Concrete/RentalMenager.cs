using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalMenager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalMenager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //_rentalDal.Add(rental);
            //return new SuccessResult("Rentall eklendi");
            if (rental.RentDate == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Rentall eklendi");
            }
            else
            {
                return new ErrorResult("araba kiralaması başarısız.");
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Rental silindi");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), "Rentallar listeleniyor");
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId), "İstenilen rental listelendi");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Rental Güncellendi");
        }

        public IDataResult<List<RentalDetailDto>> CarDetailDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.RentalDetailDtos(),"Rental Detayları listelendi");
        }
    }
}
