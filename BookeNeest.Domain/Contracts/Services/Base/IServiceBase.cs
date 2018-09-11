using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookeNeest.Domain.Contracts.Services
{
    public interface IServiceBase<TEntityDto> where TEntityDto : class
    {
        TEntityDto FindById(Guid entityId);
        IList<TEntityDto> FindByName(string entityName);
        void AddNew(TEntityDto entityDto);
    }
}
