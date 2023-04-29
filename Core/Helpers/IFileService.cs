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
        public Task<string> FileSaveToServer(IFormFile file, string filePath);

    }
}
