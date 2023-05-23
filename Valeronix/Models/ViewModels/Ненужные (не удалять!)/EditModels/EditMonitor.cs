using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels.CreateModels;

namespace Valeronix.Models.ViewModels.EditModels
{
    public class EditMonitor : CreateMonitor
    {
        public EditMonitor() { }

        public EditMonitor(MonitorMagaz monitor)
        {
            TypeOfMonitor = monitor.TypeOfMonitor;
            ModelOfDeviceId = monitor.ModelOfDeviceId;
            Price = monitor.Price;
        }

        public int Id { get; set; }
    }
}
