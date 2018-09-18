using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookeNeest.Domain.Contracts.Services
{
    public interface IImageService
    {
        string GetFilePath(Guid id);
    }
}
