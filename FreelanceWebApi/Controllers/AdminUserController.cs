using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.AdminUser;
using Shared.AdminUser;
using Shared.Library;
using Shared.WorkCategory;

namespace FreelanceWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserRepository _category;
        public AdminUserController(IAdminUserRepository category)
        {
            this._category = category;
        }

        [HttpGet("GetList")]
        public List<AdminUserModel> List()
        {
            var dt =  _category.List(); 
            return dt;
        }

        [Route("GetById/{id}")]
        [HttpPost]
        public AdminUserModel GetById(int? id)
        {
            var dt = (_category.GetById(id));
            return dt;
        }

        [Route("Create")]
        [HttpPost]
        public DbResponse Create(AdminUserModel model)
        {
            var dbresponse = new DbResponse();
            var dt = (_category.Create(model));
            if (dt == null)
            {
                dbresponse.Code = "1";
                dbresponse.Message = "null value";
                dbresponse.Extra = "null value";
            }
            else
            {
                dbresponse.Code = dt["Code"].ToString();
                dbresponse.Message = dt["Message"].ToString();
                dbresponse.Extra = dt["Extra"].ToString();
            }
            return dbresponse;
        }

        [Route("Update")]
        [HttpPost]
        public DbResponse Update(AdminUserModel model)
        {
            var dbresponse = new DbResponse();
            var dt = (_category.Update(model));
            if (dt == null)
            {
                dbresponse.Code = "1";
                dbresponse.Message = "null value";
                dbresponse.Extra = "null value";
            }
            else
            {
                dbresponse.Code = dt.Code;
                dbresponse.Message = dt.Message;
                dbresponse.Extra = dt.Extra;
            }
            return dbresponse;
        }

        [Route("Delete")]
        [HttpPost]
        public DbResponse Delete(AdminUserModel model)
        {
            var dbresponse = new DbResponse();
            var dt = (_category.Delete(model));
            if (dt == null)
            {
                dbresponse.Code = "1";
                dbresponse.Message = "null value";
                dbresponse.Extra = "null value";
            }
            else
            {
                dbresponse.Code = dt.Code;
                dbresponse.Message = dt.Message;
                dbresponse.Extra = dt.Extra;
            }
            return dbresponse;
        }
    }
}