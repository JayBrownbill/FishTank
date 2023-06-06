using RIPPL.FishTankManager.Models.Fishes;
using System.ComponentModel.DataAnnotations;

namespace RIPPL.FishTankManager.Models
{
    public class FishTank
    {
        [Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        public string Description { get; set; } = string.Empty;

        public int MaxCapacity { get; set; } = 3;

        public List<Fish> Fishes { get; set; } = new List<Fish>();
        public int CurrentPopulation { get => Fishes.Count; }
        public int TypesOfFish { get; set; }

        public bool IsOverMaxCapacity()
        {
            return CurrentPopulation >= MaxCapacity;
        }
    }
}
