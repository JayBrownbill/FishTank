using RIPPL.FishTankManager.Models;
using RIPPL.FishTankManager.Models.Fishes;
using RIPPL.FishTankManager.Services.Interfaces;

namespace RIPPL.FishTankManager.Services
{
    internal class Tank : ITank
    {
        public FishTank tank = new FishTank();
        public List<Fish> fishes = new List<Fish>();

        public decimal Feed(Guid tankID, List<Fish> unfedFish)
        {
            decimal totalServingsRequired = 0m;
            unfedFish.ForEach(fish => totalServingsRequired += fish.FoodServingSize);

            return totalServingsRequired;
        }

        public string AddFish(Guid tankID, Fish fish)
        {
            if (fish == null || string.IsNullOrEmpty(fish.Name))
                throw new ArgumentNullException(nameof(fish));

            CheckCapacity();
            fishes.Add(fish);
            tank.Fishes = fishes;

            return $"{fish.Name} has been added to the tank!";
        }

        public string AddMultipleFish(Guid tankID, List<Fish> fish)
        {
            if (fish.Any(fish => fish == null || string.IsNullOrEmpty(fish.Name)))
                throw new ArgumentNullException(nameof(fish));

            CheckCapacity();
            fishes.AddRange(fish);
            tank.Fishes = fishes;

            return $"{fish.Count} fish have successfully been added to the tank!";

        }

        public void CheckCapacity()
        {
            if (tank.IsOverMaxCapacity())
            {
                throw new InvalidOperationException($"Cannot add fish to tank due to: {nameof(FishTank.MaxCapacity)}");
            }
        }
    }
}