using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valeronix.Models.DatabaseModels
{
    public class Processor
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Модель")]
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

        //[DisplayName("Фото")]
        //[Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        //public string PhotoUrl { get; set; }
    }
}
