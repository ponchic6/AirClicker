using UniRx;

namespace MVC.Model
{
    public class AircraftDetailsCount : IAircraftDetailsCount
    {
        public ReactiveProperty<float> AircraftCount { set; get; } = new();
        public ReactiveProperty<float> ChassisCount { get; set; } = new();
        public ReactiveProperty<float> EngineCount { get; set; } = new();
        public ReactiveProperty<float> AircraftBodyCount { get; set; } = new();
        public ReactiveProperty<float> RocketCount { get; set; } = new();

        public IReadOnlyReactiveProperty<float> ChassisCountReadOnly => ChassisCount;
        public IReadOnlyReactiveProperty<float> EngineCountReadOnly => EngineCount;
        public IReadOnlyReactiveProperty<float> AircraftBodyCountReadOnly => AircraftBodyCount;
        public IReadOnlyReactiveProperty<float> AircraftCountReadOnly => AircraftCount;
        public IReadOnlyReactiveProperty<float> RocketCountReadOnly => RocketCount;
    }
}