using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.DatabaseModels
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Name { get; set; }
    }
}
