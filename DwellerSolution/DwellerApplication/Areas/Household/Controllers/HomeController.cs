using DwellerApplication.Areas.Household.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Net;

namespace DwellerApplication.Areas.Household.Controllers
{
    [Area("Household")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ErrorHandlingModel errorHandlingModel = new ErrorHandlingModel();
            errorHandlingModel.testNr = 5;

            return View(errorHandlingModel);
        }

        public IActionResult AssignHouse()
        {
            ErrorHandlingModel errorHandlingModel = new ErrorHandlingModel();
            errorHandlingModel.testNr = 5;

            return View(errorHandlingModel);
        }
    }
}
