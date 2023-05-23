﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Hosting;
using Valeronix.Models.ViewModels;

namespace Valeronix.Models.DatabaseModels
{
    public class ModelOfDevice
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Name { get; set; }

        [DisplayName("Фото")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string PhotoUrl { get; set; }

        [DisplayName("Производитель")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        [ValidateNever]
        public Creator Creator { get; set; }

        public void Update(EditModelOfDevice editModel)
        {
            Name = editModel.Name;
            CreatorId = editModel.CreatorId;
        }
    }
}
