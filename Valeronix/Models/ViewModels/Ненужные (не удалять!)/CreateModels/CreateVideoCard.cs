using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Valeronix.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.ViewModels.CreateModels
{
    public class CreateVideoCard
    {
        [DisplayName("Модель")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Name { get; set; }

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

        public VideoCard ToVideoCard()
        {
            return new VideoCard
            {
                Name = Name,
                CreatorId = CreatorId,
                Price = Price
            };
        }
    }
}
