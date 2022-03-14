using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models.Common;
using Models.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Entities;
using System;

namespace BusinessLayer.Common
{
    public class CommonService : ICommonService
    {
        private readonly DataContext _context;


        public CommonService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<ListItemModel>>> GetListItemByListItemCategorySystemName(string listItemCategoryName)
        {
            
            var listItems = await (from lic in _context.ListItemCategory
                                   join li in _context.ListItem on lic.ListItemCategoryId equals li.ListItemCategoryId
                                   where lic.ListItemCategorySystemName == listItemCategoryName
                                   select new ListItemModel
                                   {
                                       ListItemId = li.ListItemId,
                                       ListItemName = li.ListItemName,
                                       ListItemSystemName = li.ListItemSystemName
                                   }).ToListAsync();

            if (listItems.Any())
            {
                return Result<List<ListItemModel>>.Success(listItems);
            }
            else
            {
                return Result<List<ListItemModel>>.Success(null);
            }
        }
    }
}