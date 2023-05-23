using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Valeronix.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.ViewModels.CreateModels
{
    public class CreateMonitor
    {
        [DisplayName("Тип экрана")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string TypeOfMonitor { get; set; }

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

        public MonitorMagaz ToMonitor()
        {
            return new MonitorMagaz
            {
                TypeOfMonitor = TypeOfMonitor,
                ModelOfDeviceId = ModelOfDeviceId,
                Price = Price
            };
        }
    }
}
