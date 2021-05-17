using Shared.Library;
using Shared.WorkCategory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.WorkCategory
{
   public interface IWorkCategoryRepository
    {
        MainWorkCategory List();
        WorkCategoryModel GetById(int? id);
        DataRow Create(WorkCategoryModel model);
        DbResponse Update(WorkCategoryModel model);
        DbResponse Delete(WorkCategoryModel model);
    }
}
