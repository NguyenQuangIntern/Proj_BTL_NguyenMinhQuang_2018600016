using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj_BTL_NguyenMinhQuang_2018600016.Models
{
    public class ProductDAO
    {
        Flute db = null;
        public ProductDAO()
        {
            db = new Flute();
        }
        public List<tblProduct> ListProductsByCate(int cat)
        {
            var list = db.tblProducts.Where(p => p.Categoryid == cat);
            return list.ToList();
        }

    }
}