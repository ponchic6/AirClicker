using UniRx;

namespace MVC.Model
{
    public interface IAircraftDetailsCountReadOnly
    {   
        public IReadOnlyReactiveProperty<float> AircraftCountReadOnly { get; }
        public IReadOnlyReactiveProperty<float> RocketCountReadOnly { get; }
        public IReadOnlyReactiveProperty<float> ChassisCountReadOnly { get; }
        public IReadOnlyReactiveProperty<float> EngineCountReadOnly { get; }
        public IReadOnlyReactiveProperty<float> AircraftBodyCountReadOnly { get; }
    }
}