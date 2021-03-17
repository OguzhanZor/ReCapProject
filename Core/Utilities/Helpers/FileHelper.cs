using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string NewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);

            string fileExtension = fileInfo.Extension;
            string path = Environment.CurrentDirectory+@"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            var result = $@"{path}\{newPath}";
            return result;
        }

        public static string Add(IFormFile formFile)
        {
            var path = Path.GetTempFileName();

            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            var result = NewPath(formFile);

            File.Move(path, result);

            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string path, IFormFile formFile)
        {
            // burada add ekleme olarak bir düsün

            var result = NewPath(formFile).ToString();
            if (path.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(path);
            return result;
        }
    }
}
