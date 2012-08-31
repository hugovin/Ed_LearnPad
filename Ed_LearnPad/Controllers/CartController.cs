using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ed_LearnPad.Controllers
{
    public class CartController : Controller
    {
       
        public JsonResult AddProduct(int title_id, string sku, int quantity)
        {


            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
