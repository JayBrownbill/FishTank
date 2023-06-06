using System.ComponentModel.DataAnnotations;

namespace RIPPL.FishTankManager.Models.Fishes
{
    public abstract class Fish
    {
        [Required]
        public Guid ID { get; } = Guid.NewGuid();
        [Required]
        public abstract decimal FoodServingSize { get; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool HasBeenFed { get; set; }
    }
}