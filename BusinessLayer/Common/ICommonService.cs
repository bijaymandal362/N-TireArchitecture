using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;
using Models.Core;

namespace BusinessLayer.Common
{
    public interface ICommonService
    {
         Task<Result<List<ListItemModel>>> GetListItemByListItemCategorySystemName(string listItemCategoryName);
    }
}