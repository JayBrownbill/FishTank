using System.ComponentModel.DataAnnotations;

namespace RIPPL.FishTankManager.Models.Fishes
{
    internal class BabelFish : Fish
    {
        [Required]
        public override decimal FoodServingSize => 0.3m;
    }
}
