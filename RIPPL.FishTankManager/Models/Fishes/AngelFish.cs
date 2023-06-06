using System.ComponentModel.DataAnnotations;

namespace RIPPL.FishTankManager.Models.Fishes
{
    internal class AngelFish : Fish
    {
        [Required]
        public override decimal FoodServingSize => 0.2m;
    }
}