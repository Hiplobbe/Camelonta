using DBHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public Reservation GetReservation(string guid)
        {
            //Extra security would be to make the user also input their personal number
            return DbHandler.getReservation(guid);
        }

        public bool SaveReservation(Reservation reserv)
        {
            //Validation should be made here

            try
            {
                DbHandler.insertReservation(reserv);

                return true;
            }
            catch(Exception e)
            {
                //Logging should be made here

                return false;
            }            
        }
    }
}