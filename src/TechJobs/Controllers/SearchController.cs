using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm )
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            // search when search type is all
            if (searchType == "all")
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
            } else
            {
                // only when you are not searching for all
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            return View("Index");
        }

  
 

    }
}
