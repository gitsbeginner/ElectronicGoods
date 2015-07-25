using RequestMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList.Mvc;
using PagedList;
namespace RequestMaster.Controllers
{
     [Authorize]
    public class RequestController : Controller
    {
        // GET: Request
        
        public ActionResult Index()
        {
            return View();
        }
 
        [HttpPost]
        //Заявка должна быть обработана в течение одного дня
        public ActionResult Index(Request responseModel)
        {
            double processDays = 1;
            using (RequestContext context = new RequestContext())
            {
                Request new_request = new Request
                {
                    Category = responseModel.Category,
                    ShortDescription = responseModel.ShortDescription,
                    DetailsDescription = responseModel.DetailsDescription,
                    IsWarranty = responseModel.IsWarranty,
                    ManufacturingFirm = responseModel.ManufacturingFirm,
                    ContactData = responseModel.ContactData,
                    InitialDate = DateTime.Now,
                    DeadlineRequest = DateTime.Now.AddDays(processDays),
                    State = "Новая",
                    MasterID = 1,
                    ClientID = User.Identity.GetUserId()
                };
              
                context.Requests.Add(new_request);
                context.SaveChanges();
            }
            if (User.IsInRole("admin"))
            {
                return GetAllRequests(null);
            }
            return GetRequestsById(null);
        }
        public ActionResult GetAllRequests(int?page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var colection = new RequestContext().Requests.OrderByDescending(x => x.InitialDate);
            return View(colection.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetRequestsById(int? page)
        {
            string id = User.Identity.GetUserId();
            var collection = new RequestContext().Requests.Where(x => x.ClientID == id).OrderByDescending(x => x.InitialDate);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View("GetAllRequests", collection.ToPagedList(pageNumber,pageSize));
         }
        public  ActionResult DeleteRequest(int request_id)
        {
            using(RequestContext context = new RequestContext())
            {
                context.Requests.Remove(context.Requests.Where(x=>x.ID==request_id).FirstOrDefault());
                context.SaveChanges();
            }

            if (User.IsInRole("admin"))
            {
                 return  GetAllRequests(null); 
            }
            return  GetRequestsById(null);
        }
        public ActionResult EditRequest(int request_id)
        {
            return View(new RequestContext().Requests.FirstOrDefault(x => x.ID == request_id));
        }
        [HttpPost]
         public ActionResult EditRequest(Request request)
        {
            var search_id = request.ID;
            using (RequestContext context = new RequestContext())
            {
                Request search_request = context.Requests.Where(x => x.ID == search_id).FirstOrDefault();
                search_request.Category = request.Category;
                search_request.ShortDescription = request.ShortDescription;
                search_request.DetailsDescription = request.DetailsDescription;
                search_request.IsWarranty = request.IsWarranty;
                search_request.ManufacturingFirm = request.ManufacturingFirm;
                search_request.ContactData = request.ContactData;
                context.SaveChanges();
            }
            if (User.IsInRole("admin"))
            {
                return GetAllRequests(null);
            }
            return GetRequestsById(null);
        }
    }
}