using Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class FileService:IFileService
    {
        private readonly IHostEnvironment _env;

        public FileService(IHostEnvironment env)
        {
            _env = env;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"> Get a file like a1.jpg </param>
        /// <param name="filePath">Get File Path -example wwwroot/images </param>
        /// <returns></returns>
        public async Task<string> FileSaveToServer(IFormFile file, string filePath)
        {

            string strRootPath = _env.ContentRootPath;
            Guid guid = Guid.NewGuid();
            //  string strNewImageName = guid.ToString() + movieDetailDto.Poster.FileName;
            string fileFormat = file.FileName.Substring(file.FileName.LastIndexOf('.'));

            fileFormat = fileFormat.ToLower();
            string strNewFileName = guid.ToString() + fileFormat;
            string strFilePath = Path.Combine(strRootPath + filePath + strNewFileName);

            using (FileStream fs = new FileStream(strFilePath, FileMode.Create))
            {
                file.CopyToAsync(fs);
                fs.Close();
                
            }
            return strNewFileName;
        }
        public async Task FileDeleteToServer(string filename,string path)
        {
            var newFilePath=path + filename;
            try
            {
                if (System.IO.File.Exists(newFilePath))
                {
                    System.IO.File.Delete(newFilePath);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
