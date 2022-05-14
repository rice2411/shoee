using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NameShoes.Models;
using NameShoes.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NameShoes.Controllers
{
    public class HomeController : Controller
    {
  
        private IWebHostEnvironment webHostEnvironment;
        private readonly IShoeRepository shoeRepository;
        private readonly IColorRepository colorRepository;

        public HomeController(IShoeRepository shoeRepository, IWebHostEnvironment webHostEnvironment, IColorRepository colorRepository)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.shoeRepository = shoeRepository;
            this.colorRepository = colorRepository;

        }

        public IActionResult Index()
        {
       
            ViewBag.Shoes = shoeRepository.GetList();
            ViewBag.Color = colorRepository.GetList();
            return View();
        }
     
        public IActionResult Search(string key)
        {
            if (key == null)
            {
                ViewBag.Shoes = shoeRepository.GetList();
                ViewBag.Color = colorRepository.GetList();
                return View("~/Views/Home/Index.cshtml");

            }
            var formatedKey = key.Trim();
          
            var shoes = shoeRepository.GetList() as IEnumerable<Shoe>;

            ViewBag.Color = colorRepository.GetList();
            ViewBag.Shoes = shoes.Where(s => s.Name.ToLower().Contains(formatedKey.ToLower()));
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult Filter(int id)
        {

            var shoes = shoeRepository.GetList() as IEnumerable<Shoe>;
       
            ViewBag.Color = colorRepository.GetList();
            ViewBag.Shoes = shoes.Where(s => s.Color.Id == id);
            return View("~/Views/Home/Index.cshtml");
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
