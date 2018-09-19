using System;
using BookeNeest.Domain.Contracts;
using BookeNeest.Domain.Contracts.Services;

namespace BookeNeest.LogicLayer.Services
{
    public class ImageService : ServiceBase, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string GetImageFilePath(Guid id)
        {
            // TODO: Create EntityId-based access to associated files 
            
            var path = $"~/Content/Images/Books/{id}.jpg";
            

            return path;
        }
    }
}
