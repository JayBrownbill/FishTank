using RIPPL.FishTankManager.Models.Fishes;

namespace RIPPL.FishTankManager.Services.Interfaces
{
    public interface ITank
    {
        public string AddFish(Guid tankID, Fish fish);

        public string AddMultipleFish(Guid tankID, List<Fish> fish);

        public decimal Feed(Guid tankID, List<Fish> unfedFish);
    }
}
