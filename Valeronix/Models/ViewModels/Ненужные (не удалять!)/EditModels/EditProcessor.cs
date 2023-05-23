using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels.CreateModels;

namespace Valeronix.Models.ViewModels.EditModels
{
    public class EditProcessor : CreateProcessor
    {
        public EditProcessor() { }

        public EditProcessor(Processor processor) 
        {
            Name = processor.Name;
            Yadr = processor.Yadr;
            Potok = processor.Potok;
            CreatorId = processor.CreatorId;
            Price = processor.Price;
        }

        public int Id { get; set; }
    }
}
