using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnicalTest.Models;
using TechnicalTest.Services;

namespace TechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAgeCalculator _ageCalculator;


        public HomeController(ILogger<HomeController> logger, IAgeCalculator ageCalculator)
        {
            _logger = logger;
            _ageCalculator = ageCalculator;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <returns>Age in years,Months and Days </returns>
        [HttpPost]
        public ActionResult Index(DateTime selectedDate)
        {
            //calling CalculateAge method from IAgeCalculator to calculate age based on selected date.
            var resultAge = _ageCalculator.CalculateAge(selectedDate);
            if (resultAge.Message != String.Empty)
            {
                ViewBag.Message = "Date of birth should not be greater than today's date";
            }
            else
            {
                ViewBag.Message = "As per calander age is " + "Years : " + resultAge.Age + " , Months: " + resultAge.Month + " , Days: " + resultAge.Days;
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}