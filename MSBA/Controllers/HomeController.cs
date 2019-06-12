using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSBA.Context;

namespace MSBA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectContext _dbContext;
        public HomeController(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";

            int count = Convert.ToInt32(Math.Ceiling((double)_dbContext.Projects.Count() / 10));
            ViewBag.ProjectCount = count;
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Paging(int id)
        {
            var pageSize = 10;


            var skip = pageSize * id;


            return Json(await _dbContext.Projects.Skip(skip).Take(10).ToListAsync());
        }
    }
}