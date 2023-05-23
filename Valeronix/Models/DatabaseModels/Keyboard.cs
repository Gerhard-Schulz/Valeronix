﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valeronix.Models.DatabaseModels
{
    public class Keyboard
    {
        [Key]
        public int Id { get; set; }

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

        //[DisplayName("Фото")]
        //[Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        //public string PhotoUrl { get; set; }
    }
}
