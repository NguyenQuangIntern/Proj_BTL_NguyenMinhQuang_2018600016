using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj_BTL_NguyenMinhQuang_2018600016.Models
{
    public class CategoryDAO
    {
        Flute db = null;
        public CategoryDAO()
        {
            db = new Flute();
        }
        public List<tblCategory> ListCategory()
        {
            return db.tblCategories.ToList();
        }

        public tblCategory ListCategoryByCatId(int catid)
        {
            return db.tblCategories.Find(catid); //para phải là pmkey trong bảng
        }

    }
}