using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Controllers
{
    public class ITController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
