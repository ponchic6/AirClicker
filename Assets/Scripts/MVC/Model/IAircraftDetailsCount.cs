using UniRx;

namespace MVC.Model
{
    public interface IAircraftDetailsCount : IAircraftDetailsCountReadOnly
    {
        public ReactiveProperty<int> RocketCount { get; set; }
        public ReactiveProperty<int> ChassisCount { get; set; }
        public ReactiveProperty<int> EngineCount { get; set; }
        public ReactiveProperty<int> AircraftBodyCount { get; set; }
    }
}