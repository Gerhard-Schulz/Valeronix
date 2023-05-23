using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valeronix.Models.DatabaseModels
{
    public class OS
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Name { get; set; }

        [DisplayName("Производитель")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        [ValidateNever]
        public Creator Creator { get; set; }
    }
}
