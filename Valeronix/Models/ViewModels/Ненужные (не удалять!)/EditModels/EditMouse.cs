using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels.CreateModels;

namespace Valeronix.Models.ViewModels.EditModels
{
    public class EditMouse : CreateMouse
    {
        public EditMouse() { }

        public EditMouse(Mouse mouse) 
        {
            ModelOfDeviceId = mouse.ModelOfDeviceId;
            Price = mouse.Price;
        }

        public int Id { get; set; }
    }
}
