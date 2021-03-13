using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results.Concrete;
using Business.Constants;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using System.Linq;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage , IFormFile formFile)
        {

            IResult result = BusinessRules.Run(CheckIfFotoLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(formFile);

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {

            IResult result = BusinessRules.Run(
               FileHelper.Delete(_carImageDal.Get(c=>c.ImagePath==carImage.ImagePath).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckIfFotoLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, formFile);
           
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfFotoLimit(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.FotoLimited);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\arac1.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList());
        }


    }
}
