using System;
using System.IO;
using Fundamentals.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Fundamentals.Utilities.Helpers
{
    public class FileStorageHelper
    {
        public static string UploadFile(IFormFile file)
        {
            string sourcePath = Path.GetTempFileName();
            if (file != null)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var destinationFilePath = uploadPath(file);
            File.Move(sourcePath, destinationFilePath);
            return destinationFilePath;
        }

        public static string UpdateFile(string sourcePath, IFormFile file)
        {
            var result = uploadPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }

        public static IResult DeleteFile(string path)
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

        public static string uploadPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"/Storage/CarImages/";
            var fileName = Guid.NewGuid().ToString() + fileExension;

            string destinationFilePath = $@"{path}\{fileName}";
            return destinationFilePath;
        }
    }
}