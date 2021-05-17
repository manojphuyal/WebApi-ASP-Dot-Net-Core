using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.WorkCategory;
using Shared.Library;
using Shared.WorkCategory;

namespace FreelanceWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WorkCategoryController : ControllerBase
    {
        private readonly IWorkCategoryRepository _category;
        public WorkCategoryController(IWorkCategoryRepository category)
        {
            this._category = category;
        }

        [HttpGet("GetList")]
        public IActionResult List()
        {
            var dt = (_category.List());
            return Ok(dt);
        }

        [Route("GetById/{id}")]
        [HttpPost]
        public IActionResult GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dt = (_category.GetById(id));
            return Ok(dt);
        }

        //[Route("GetById/{id}")]
        //[HttpPost]
        //public WorkCategoryModel GetById(int? id)
        //{
        //    var dt = (_category.GetById(id));
        //    return dt;
        //}

        [Route("Create")]
        [HttpPost]
        public DbResponse Create(WorkCategoryModel model)
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
        public DbResponse Update(WorkCategoryModel model)
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
        public DbResponse Delete(WorkCategoryModel model)
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