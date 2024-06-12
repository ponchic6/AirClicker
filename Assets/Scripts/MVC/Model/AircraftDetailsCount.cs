using UniRx;

namespace MVC.Model
{
    public class AircraftDetailsCount : IAircraftDetailsCount
    {
        public ReactiveProperty<int> ChassisCount { get; set; } = new();
        public ReactiveProperty<int> EngineCount { get; set; } = new();
        public ReactiveProperty<int> AircraftBodyCount { get; set; } = new();
        public ReactiveProperty<int> RocketCount { get; set; } = new();

        public IReadOnlyReactiveProperty<int> ChassisCountReadOnly => ChassisCount;
        public IReadOnlyReactiveProperty<int> EngineCountReadOnly => EngineCount;
        public IReadOnlyReactiveProperty<int> AircraftBodyCountReadOnly => AircraftBodyCount;
        public IReadOnlyReactiveProperty<int> RocketCountReadOnly => RocketCount;
    }
}