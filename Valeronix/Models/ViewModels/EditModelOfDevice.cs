using Valeronix.Models.DatabaseModels;

namespace Valeronix.Models.ViewModels
{
    public class EditModelOfDevice : CreateModelOfDevice
    {
        public EditModelOfDevice() { }

        public EditModelOfDevice(ModelOfDevice modelOfDevice)
        {
            Name = modelOfDevice.Name;
            CreatorId = modelOfDevice.CreatorId;
        }

        public int Id { get; set; }
    }
}
