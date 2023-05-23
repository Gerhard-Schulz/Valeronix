using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels.CreateModels;

namespace Valeronix.Models.ViewModels.EditModels
{
    public class EditVideoCard : CreateVideoCard
    {
        public EditVideoCard() { }

        public EditVideoCard(VideoCard videoCard)
        {
            Name = videoCard.Name;
            CreatorId = videoCard.CreatorId;
            Price = videoCard.Price;
        }

        public int Id { get; set; }
    }
}
