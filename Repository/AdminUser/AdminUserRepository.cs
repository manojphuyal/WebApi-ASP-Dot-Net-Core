
using Microsoft.Extensions.Configuration;
using Repository.Data;
using Shared.Library;
using Shared.AdminUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AdminUser
{
    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly IDataAccess _dataAccess;
        public AdminUserRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<AdminUserModel> List()
        {
            var sql = "Exec proc_AdminUser @flag='GetAll'";
            var dt = _dataAccess.ExecuteDataTable(sql);
            List<AdminUserModel> list = new List<AdminUserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                var details = new AdminUserModel();
                //pd.Id = row["Id"];
                details.FullName = dr["FullName"].ToString();
                details.Post = dr["Post"].ToString();
                details.Role = dr["Role"].ToString();
                details.ImageLink = dr["ImageLink"].ToString();
                details.Email = dr["Email"].ToString();
                details.Password = dr["Password"].ToString();
                details.CreatedDate = dr["CreatedDate"].ToString();
                details.CreatedBy = dr["CreatedBy"].ToString();
                details.IDCardLink = dr["IDCardLink"].ToString();
                details.IsActive = dr["IsActive"].ToString();
                list.Add(details);
            }
            return list;
        }
        public AdminUserModel GetById(int? id)
        {
            var sql = "Exec proc_AdminUser @flag='GetById'";
            sql += ", @id=" + id;
            var dt = _dataAccess.ExecuteDataRow(sql);
            AdminUserModel details = new AdminUserModel();
            if (dt.Table.Rows.Count == 1)
            {
                details.FullName = dt["FullName"].ToString();
                details.Post = dt["Post"].ToString();
                details.Role = dt["Role"].ToString();
                details.ImageLink = dt["ImageLink"].ToString();
                details.Email = dt["Email"].ToString();
                details.Password = dt["Password"].ToString();
                details.CreatedDate = dt["CreatedDate"].ToString();
                details.CreatedBy = dt["CreatedBy"].ToString();
                details.IDCardLink = dt["IDCardLink"].ToString();
                details.IsActive = dt["IsActive"].ToString();
            }
            else
            {

            }
            return details;
        }
        public DataRow Create(AdminUserModel model)
        {
            var sql = "Exec proc_AdminUser @flag='Create'";
            sql += ", @FullName=" + _dataAccess.FilterString(model.FullName.ToString());
            sql += ", @Post=" + _dataAccess.FilterString(model.Post.ToString());
            sql += ", @Role=" + _dataAccess.FilterString(model.Role.ToString());
            sql += ", @ImageLink=" + _dataAccess.FilterString(model.ImageLink.ToString());
            sql += ", @Email=" + _dataAccess.FilterString(model.Email.ToString());
            sql += ", @Password=" + _dataAccess.FilterString(model.Password.ToString());
            sql += ", @CreatedBy=" + _dataAccess.FilterString(model.CreatedBy.ToString());
            sql += ", @IDCardLink=" + _dataAccess.FilterString(model.IDCardLink.ToString());
            sql += ", @IsActive=" + _dataAccess.FilterString(model.IsActive.ToString());
            var ct = _dataAccess.ExecuteDataRow(sql);
            return ct;
        }
        public DbResponse Update(AdminUserModel model)
        {
            var sql = "Exec proc_AdminUser @flag='Update'";
            sql += ", @id=" + model.Id;
            sql += ", @FullName=" + _dataAccess.FilterString(model.FullName.ToString());
            sql += ", @Post=" + _dataAccess.FilterString(model.Post.ToString());
            sql += ", @Role=" + _dataAccess.FilterString(model.Role.ToString());
            sql += ", @ImageLink=" + _dataAccess.FilterString(model.ImageLink.ToString());
            sql += ", @Email=" + _dataAccess.FilterString(model.Email.ToString());
            sql += ", @Password=" + _dataAccess.FilterString(model.Password.ToString());
            sql += ", @CreatedBy=" + _dataAccess.FilterString(model.CreatedBy.ToString());
            sql += ", @IDCardLink=" + _dataAccess.FilterString(model.IDCardLink.ToString());
            sql += ", @IsActive=" + _dataAccess.FilterString(model.IsActive.ToString());
            var dt = _dataAccess.ExecuteDataRow(sql);
            if (dt != null)
            {
                var response = new DbResponse
                {
                    Code = dt["Code"].ToString(),
                    Message = dt["Message"].ToString(),
                    Extra = dt["Extra"].ToString()

                };
                return response;
            }
            else
            {
                DbResponse result = new DbResponse();
                return result;
            }
        }
        public DbResponse Delete(AdminUserModel model)
        {
            var sql = "Exec proc_AdminUser @flag='Delete'";
            sql += ", @id=" + model.Id;
            var dt = _dataAccess.ExecuteDataRow(sql);
            if (dt != null)
            {
                var response = new DbResponse
                {
                    Code = dt["Code"].ToString(),
                    Message = dt["Message"].ToString(),
                    Extra = dt["Extra"].ToString()

                };
                return response;
            }
            else
            {
                DbResponse result = new DbResponse();
                return result;
            }
        }
    }
}
