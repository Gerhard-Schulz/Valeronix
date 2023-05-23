using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels.CreateModels;

namespace Valeronix.Models.ViewModels.EditModels
{
    public class EditKeyboard : CreateKeyboard
    {
        public EditKeyboard() { }

        public EditKeyboard(Keyboard keyboard) 
        {
            TypeOfKeyboard = keyboard.TypeOfKeyboard;
            ModelOfDeviceId = keyboard.ModelOfDeviceId;
            Price = keyboard.Price;
        }

        public int Id { get; set; }
    }
}
