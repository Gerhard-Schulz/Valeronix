using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Valeronix.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.ViewModels
{
    public class CreateModelOfDevice
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Name { get; set; }

        [DisplayName("Фото")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public IFormFile PhotoUrl { get; set; }

        [DisplayName("Производитель")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        [ValidateNever]
        public Creator Creator { get; set; }

        public ModelOfDevice ToModelOfDevice()
        {
            return new ModelOfDevice
            {
                Name = Name,
                CreatorId = CreatorId
            };
        }
    }
}
