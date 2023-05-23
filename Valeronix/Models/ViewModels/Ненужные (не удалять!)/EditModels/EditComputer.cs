using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels.CreateModels;

namespace Valeronix.Models.ViewModels.EditModels
{
    public class EditComputer : CreateComputer
    {
        public EditComputer() { }

        public EditComputer(Computer computer)
        {
            Adapter = computer.Adapter;
            MemoryType = computer.MemoryType;
            MemoryVolume = computer.MemoryVolume;
            OzuMemory = computer.OzuMemory;
            OSId = computer.OSId;
            ProcessorId = computer.ProcessorId;
            VideoCardId = computer.VideoCardId;
            ModelOfDeviceId = computer.ModelOfDeviceId;
            Price = computer.Price;
        }

        public int Id { get; set; }
    }
}
