using Shared.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.WorkCategory
{
    public class MainWorkCategory
    {
        public List<WorkCategoryModel> mainWorkCategory { get; set; }
    }
    public class WorkCategoryModel : DbResponse
    {
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string WorkType { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public List<WorkSubCategoryModel> WorkSubCategory { get; set; }
    }

    public class WorkSubCategoryModel
    {
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryCode { get; set; }
        public string SubCategoryName { get; set; }
    }
}
