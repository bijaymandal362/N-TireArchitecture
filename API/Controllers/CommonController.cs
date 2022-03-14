using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class CommonController : BaseApiController
    {
        private readonly ICommonService _iCommonService;
        public CommonController(ICommonService iCommonService)
        {
            _iCommonService = iCommonService;
        }

        [HttpGet("GetListItemByListItemCategorySystemName/{listItemCategorySystemName}")]

        public async Task<IActionResult> GetListItemByListItemCategorySystemName(string listItemCategorySystemName)
        {
         
            return  HandleResult(await _iCommonService.GetListItemByListItemCategorySystemName(listItemCategorySystemName));
        }

    }
}