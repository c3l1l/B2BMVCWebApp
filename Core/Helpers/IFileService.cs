using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public interface IFileService
    {
        Task<string> FileSaveToServer(IFormFile file, string filePath);
        Task FileDeleteToServer(string filename, string path);
    }
}
