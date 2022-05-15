using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NameShoes.Models;
using NameShoes.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Color = colorRepository.GetList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShoeRequest shoe) 
        {
            if (ModelState.IsValid)
            {
                var colors = colorRepository.GetList() as IEnumerable<Color>;
                var color = colors.Where(c => c.Id == shoe.Color).FirstOrDefault();
                var model = new Shoe()
                {
                    Name = shoe.Name,
                    Price = (int)shoe.Price,
                    Color = color
                };

                var fileName = string.Empty;
                if (shoe.formFile != null)
                {
                    string uploadImg = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{shoe.formFile.FileName}";
                    var filePath = Path.Combine(uploadImg, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        shoe.formFile.CopyTo(fs);
                    }
                }
                model.Image = fileName;



                shoeRepository.Create(model);
                ViewBag.Shoes = shoeRepository.GetList();
                ViewBag.Color = colorRepository.GetList();
                return View("~/Views/Dashboard/Index.cshtml");
            }
            ViewBag.Color = colorRepository.GetList();
            return View(shoe);
        }
        public IActionResult Index()
        {
            ViewBag.Shoes = shoeRepository.GetList();
            ViewBag.Color = colorRepository.GetList();
            return View();
        }
    }
}
