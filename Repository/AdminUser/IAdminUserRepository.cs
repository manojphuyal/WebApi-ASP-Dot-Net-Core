using Shared.Library;
using Shared.AdminUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AdminUser
{
   public interface IAdminUserRepository
    {
        List<AdminUserModel> List();
        AdminUserModel GetById(int? id);
        DataRow Create(AdminUserModel model);
        DbResponse Update(AdminUserModel model);
        DbResponse Delete(AdminUserModel model);
    }
}
