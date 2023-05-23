using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valeronix.Models.DatabaseModels
{
    public class VideoCard
    {
        [Key]
        public int Id { get; set; }

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

        //[DisplayName("Фото")]
        //[Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        //public string PhotoUrl { get; set; }
    }
}
