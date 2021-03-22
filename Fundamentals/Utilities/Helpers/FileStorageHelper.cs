using System;
using System.Collections.Generic;
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

            var destFileName = CreateFullPath(file);
            File.Move(sourceFileName, destFileName.GetValueOrDefault("PathToSavedOnServer"));
            return new SuccessResult(destFileName.GetValueOrDefault("DbRoute"));
        }

        public static IResult DeleteFile(string path)
        {
            try
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory,path));
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

            var destFileName = CreateFullPath(file);

            using (var stream = new FileStream(destFileName.GetValueOrDefault("PathToSavedOnServer"), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            File.Delete(currentImageFile);

            return new SuccessResult(destFileName.GetValueOrDefault("DbRoute"));
        }

        private static Dictionary<string, string> CreateFullPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string photoRootDirectory = Path.Combine(Environment.CurrentDirectory, "Storage", "Images");
            string fileName = Guid.NewGuid().ToString() + fileExtension;

            string dbRoute = Path.Combine("Storage", "Images", fileName);
            string pathToSavedOnServer = Path.Combine(photoRootDirectory, fileName);

            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("DbRoute", dbRoute);
            result.Add("PathToSavedOnServer", pathToSavedOnServer);

            return result;

        }
    }
}