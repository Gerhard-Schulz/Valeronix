using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Valeronix.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations;

namespace Valeronix.Models.ViewModels.CreateModels
{
    public class CreateComputer
    {
        [DisplayName("Адаптер")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string Adapter { get; set; }

        [DisplayName("Память (тип)")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string MemoryType { get; set; }

        [DisplayName("Память (объём)")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string MemoryVolume { get; set; }

        [DisplayName("Оперативная память")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public string OzuMemory { get; set; }

        [DisplayName("Операционная система")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int OSId { get; set; }
        [ForeignKey("OSId")]
        [ValidateNever]
        public OS OS { get; set; }

        [DisplayName("Процессор")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int ProcessorId { get; set; }
        [ForeignKey("ProcessorId")]
        [ValidateNever]
        public Processor Processor { get; set; }

        [DisplayName("Видео карта")]
        [Required(ErrorMessage = "Это поле должно быть обязательно заполнено")]
        public int VideoCardId { get; set; }
        [ForeignKey("VideoCardId")]
        [ValidateNever]
        public VideoCard VideoCard { get; set; }

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

        public Computer ToComputer()
        {
            return new Computer
            {
                Adapter = Adapter,
                MemoryType = MemoryType,
                MemoryVolume = MemoryVolume,
                OzuMemory = OzuMemory,
                OSId = OSId,
                ProcessorId = ProcessorId,
                VideoCardId = VideoCardId,
                ModelOfDeviceId = ModelOfDeviceId,
                Price = Price
            };
        }
    }
}
