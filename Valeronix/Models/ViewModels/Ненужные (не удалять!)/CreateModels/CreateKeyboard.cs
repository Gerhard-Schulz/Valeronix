using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Valeronix.Models.DatabaseModels;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.ViewModels.CreateModels
{
    public class CreateKeyboard
    {
        [DisplayName("Тип")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string TypeOfKeyboard { get; set; }

        [DisplayName("Модель")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int ModelOfDeviceId { get; set; }
        [ForeignKey("ModelOfDeviceId")]
        [ValidateNever]
        public ModelOfDevice ModelOfDevice { get; set; }

        [DisplayName("Цена")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public decimal Price { get; set; }

        [DisplayName("Фото")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public IFormFile PhotoUrl { get; set; }

        public Keyboard ToKeyboard()
        {
            return new Keyboard
            {
                TypeOfKeyboard = TypeOfKeyboard,
                ModelOfDeviceId = ModelOfDeviceId,
                Price = Price
            };
        }
    }
}
