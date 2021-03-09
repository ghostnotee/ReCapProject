using System;
using System.IO;
using Fundamentals.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Fundamentals.Utilities.Helpers
{
    public class FileStorageHelper
    {
        public static IResult UploadFile(IFormFile file)
        {

            if (file.Length == 0)
            {
                return new ErrorResult("Please attach file");
            }

            string sourceFileName = Path.GetTempFileName();

            using (var stream = new FileStream(sourceFileName, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string destFileName = CreateFullPath(file);
            File.Move(sourceFileName, destFileName);
            return new SuccessResult(destFileName);
        }

        public static IResult DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (System.Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static IResult UpdateFile(IFormFile file, string currentImageFile)
        {
            if (file.Length == 0)
            {
                return new ErrorResult("Please attach file");
            }

            string destFileName = CreateFullPath(file);

            using (var stream = new FileStream(destFileName, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            File.Delete(currentImageFile);

            return new SuccessResult(destFileName);
        }

        private static string CreateFullPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string photoRootDirectory = Path.Combine(Environment.CurrentDirectory, "Storage", "Images");
            string fileName = Guid.NewGuid().ToString() + fileExtension;

            return Path.Combine(photoRootDirectory, fileName);
        }
    }
}