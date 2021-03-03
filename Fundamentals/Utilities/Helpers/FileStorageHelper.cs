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

            var destinationFullPath = uploadPath(file);
            File.Move(sourcePath, destinationFullPath);
            return destinationFullPath;
        }

        public static string UpdateFile(string sourcePath, IFormFile file)
        {
            var newFileFullPath = uploadPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(newFileFullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return newFileFullPath;
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

            string path = Environment.CurrentDirectory + "\\Storage\\CarImages\\";
            var fileName = Guid.NewGuid().ToString() + fileExension;

            string destinationFullPath = $@"{path}\{fileName}";
            return destinationFullPath;
        }
    }
}