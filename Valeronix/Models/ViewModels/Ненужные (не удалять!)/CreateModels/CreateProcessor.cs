using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Valeronix.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.ViewModels.CreateModels
{
    public class CreateProcessor
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Name { get; set; }

        [DisplayName("Количесство ядер")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int Yadr { get; set; }

        [DisplayName("Количество потоков")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int Potok { get; set; }

        [DisplayName("Производитель")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        [ValidateNever]
        public Creator Creator { get; set; }

        [DisplayName("Цена")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public decimal Price { get; set; }

        [DisplayName("Фото")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public IFormFile PhotoUrl { get; set; }

        public Processor ToProcessor()
        {
            return new Processor
            {
                Name = Name,
                Yadr = Yadr,
                Potok = Potok,
                CreatorId = CreatorId,
                Price = Price
            };
        }
    }
}
