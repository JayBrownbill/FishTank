using System.ComponentModel.DataAnnotations;

namespace RIPPL.FishTankManager.Models.Fishes
{
    internal class GoldFish : Fish
    {
        [Required]
        public override decimal FoodServingSize => 0.1m;
    }
}
