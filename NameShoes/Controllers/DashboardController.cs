using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NameShoes.Models;
using NameShoes.Services;
using System.Collections.Generic;
using System.Linq;

namespace NameShoes.Controllers
{
    public class DashboardController : Controller
    {

        private IWebHostEnvironment webHostEnvironment;
        private readonly IShoeRepository shoeRepository;
        private readonly IColorRepository colorRepository;

        public DashboardController(IShoeRepository shoeRepository, IWebHostEnvironment webHostEnvironment, IColorRepository colorRepository)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.shoeRepository = shoeRepository;
            this.colorRepository = colorRepository;

        }
        public IActionResult Edit(int id)
        {
            var model = shoeRepository.Get(id) as Shoe;
            ViewBag.Color = colorRepository.GetList();
            return View(model);
        }
        public IActionResult SubmitEdit(Shoe shoe)
        {
            var colors = colorRepository.GetList() as IEnumerable<Color>;
            var model = shoe;
            model.Color = colors.Where(c => c.Id == shoe.ColorId).FirstOrDefault();
            shoeRepository.Edit(model);
            ViewBag.Shoes = shoeRepository.GetList();
            ViewBag.Color = colorRepository.GetList();
            return View("~/Views/Dashboard/Index.cshtml");
        }
        public IActionResult Delete(int id)
        {
    

            shoeRepository.Delete(id);
            ViewBag.Shoes = shoeRepository.GetList();
            ViewBag.Color = colorRepository.GetList();
            return View("~/Views/Dashboard/Index.cshtml");
        }
        public IActionResult Create(ShoeRequest shoe)
        {
            var colors = colorRepository.GetList() as IEnumerable<Color>;
            var color = colors.Where(c => c.Id == shoe.Color).FirstOrDefault();
            var model = new Shoe()
            {
                Name = shoe.Name,
                Price = shoe.Price,
                Color = color,
                Image = shoe.Image
            };
            shoeRepository.Create(model);
            ViewBag.Shoes = shoeRepository.GetList();
            ViewBag.Color = colorRepository.GetList();
            return View("~/Views/Dashboard/Index.cshtml");
        }
        public IActionResult Index()
        {
            ViewBag.Shoes = shoeRepository.GetList();
            ViewBag.Color = colorRepository.GetList();
            return View();
        }
    }
}
