using FluentAssertions;
using RIPPL.FishTankManager.Models;
using RIPPL.FishTankManager.Models.Fishes;
using RIPPL.FishTankManager.Services;

namespace RIPPL.FishTankManager.Tests
{
    public class TankManagerTests : IDisposable
    {
        private readonly List<Fish> _fishes;
        private readonly Tank _tank;
        private List<Fish> _collectionOfAllFish;
        public TankManagerTests()
        {
            _fishes = new List<Fish>();
            _tank = new Tank();
            _collectionOfAllFish = new List<Fish>()
            {
                new GoldFish(){Name = "Nemo"},
                new BabelFish(){Name = "Dory"},
                new AngelFish() { Name = "NotNemo" }
            };
        }

        [Fact]
        public void TankFeed_AllFishTypes_ReturnsCorrectFeedAmount()
        {
            var expectedFood = 0.6m;
            _fishes.AddRange(_collectionOfAllFish);
            _tank.Feed(_tank.tank.ID, _fishes).Should().Be(expectedFood);
        }

        [Fact]
        public void TankFeed_EmptyCollection_ReturnsZeroFeed()
        {
            _tank.Feed(_tank.tank.ID, _fishes).Should().Be(0m);
        }

        [Fact]
        public void AddFish_TankCollectionUpdates()
        {
            _tank.AddFish(_tank.tank.ID, new GoldFish() { Name = "Freddy" });
            _tank.fishes.Count.Should().Be(1);
        }

        [Fact]
        public void AddMultipleFish_TankCollectionUpdates()
        {
            _fishes.AddRange(_collectionOfAllFish);
            _tank.AddMultipleFish(_tank.tank.ID, _fishes);
            _tank.fishes.Count.Should().Be(_fishes.Count);
        }

        [Fact]
        public void AddFish_InvalidWithoutName_ThrowArgumentNullException()
        {
            _tank
                .Invoking(tm => tm.AddFish(_tank.tank.ID, new GoldFish()))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddFish_NullFish_ThrowArgumentNullException()
        {
            GoldFish fish = null;

            _tank
                .Invoking(tm => tm.AddFish(_tank.tank.ID, fish))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void AddFish_TankAtMaxCapacity_ThrowInvalidOperationException(int maxCapacity)
        {
            // Arrange fish tank to already contain max amount of fish.
            _tank.tank.MaxCapacity = maxCapacity;
            _tank.AddMultipleFish(_tank.tank.ID, _collectionOfAllFish);

            _tank
                .Invoking(tm => tm.AddMultipleFish(_tank.tank.ID, _collectionOfAllFish))
                .Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void CheckCapacity_MaxCapacity_ThrowInvalidOperationException()
        {
            int maxCapacity = 1;
            _tank.AddMultipleFish(_tank.tank.ID, _collectionOfAllFish);

            _tank
                .Invoking(tm => tm.CheckCapacity())
                .Should().Throw<InvalidOperationException>();
        }

        public void Dispose()
        {
            _fishes.Clear();
        }
    }
}