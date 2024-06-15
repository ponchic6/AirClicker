using UniRx;

namespace MVC.Model
{
    public interface IAircraftDetailsCount : IAircraftDetailsCountReadOnly
    {   
        public ReactiveProperty<float> AircraftCount { get; set; }
        public ReactiveProperty<float> RocketCount { get; set; }
        public ReactiveProperty<float> ChassisCount { get; set; }
        public ReactiveProperty<float> EngineCount { get; set; }
        public ReactiveProperty<float> AircraftBodyCount { get; set; }
    }
}