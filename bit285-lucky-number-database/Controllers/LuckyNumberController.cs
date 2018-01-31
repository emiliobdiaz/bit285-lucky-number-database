using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        // GET: LuckyNumber
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };

            // Created a class and set a property using DbSet.
            dbc.LuckyNumbers.Add(myLuck);
            // This will be our database creation.
            dbc.SaveChanges();
            int id = myLuck.LuckyNumberID;

            return View(myLuck);
        }

        [HttpGet]

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m => m.LuckyNumberID == 1).First();

            // Change the Balance in the Database
            if(databaseLuck.Balance>0)
            {
                databaseLuck.Balance -= 1;
            }

            // Update the Number in the Database using the form submission value
            databaseLuck.Number = lucky.Number;

            // Save to the Database
            dbc.SaveChanges();

            return View(databaseLuck);
        }
    }
}