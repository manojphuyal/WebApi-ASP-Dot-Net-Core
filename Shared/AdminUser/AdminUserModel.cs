using Shared.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.AdminUser
{
    public class AdminUserModel : DbResponse
    {
        public string FullName { get; set; }
        public string Post { get; set; }
        public string Role { get; set; }
        public string ImageLink { get; set; }
        public string Email { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string IDCardLink { get; set; }
        public string IsActive { get; set; }
        public string Password { get; set; }
    }
}
