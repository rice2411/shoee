using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NameShoes.Models
{
    public class ShoeRequest
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng giá")]
        public int? Price { get; set; }
     
        public int Color { get; set; }
        public string Image { get; set; }
        public IFormFile formFile { get; set; }
    }
}
