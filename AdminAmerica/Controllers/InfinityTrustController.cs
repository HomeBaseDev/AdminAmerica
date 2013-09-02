using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminAmerica.Models;

namespace AdminAmerica.Controllers
{
    public class InfinityTrustController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoices()
        {
            return View();
        }

        public ActionResult InvoiceSearch()
        {
            return PartialView();
        }

        public ActionResult InvoiceSearchResults(string bizName)
        {
            NBK455_homebasewebEntities dbConn = new NBK455_homebasewebEntities();

            List<vspclient> c = dbConn.vspclients
                .Where(b => b.BusinessName.Contains(bizName)).ToList();

            
            return PartialView(c);
        }

        public ActionResult InvoiceEdit()
        {
            return PartialView();
        }
    }
}
