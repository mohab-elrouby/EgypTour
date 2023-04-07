using Microsoft.Extensions.FileProviders;

namespace Presentation.Services
{
    public static class WriteDeleteFileService
    {
        public static string Write(IFormFile file, string directory)
        {
            string fileName = file.FileName;
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), directory, uniqueFileName);
            file.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        public static void Delete(string FilePath)
        {
            string fullPath = Directory.GetCurrentDirectory()+ "/wwwroot" + FilePath ;
            FileInfo file = new FileInfo(fullPath);
            if (file.Exists)
            {
                file.Delete();
            }
            else
            {
                throw new KeyNotFoundException("File Doesn't Exist");
            }
        }

    }
}
