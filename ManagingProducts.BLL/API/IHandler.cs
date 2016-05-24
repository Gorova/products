using System.Collections.Generic;
using ManagingProducts.Common.IDTO;

namespace ManagingProducts.BLL.API
{
    public interface IHandler<TDto> where TDto : class, IBaseDto
    {
        IEnumerable<TDto> GetAll();

        TDto Get(int id);

        void Add(TDto data);

        void Update(TDto data);

        void Delete(int id);
    }
}
