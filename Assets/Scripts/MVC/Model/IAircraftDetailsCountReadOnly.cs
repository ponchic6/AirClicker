using UniRx;

namespace MVC.Model
{
    public interface IAircraftDetailsCountReadOnly
    {
        public IReadOnlyReactiveProperty<int> RocketCountReadOnly { get; }
        public IReadOnlyReactiveProperty<int> ChassisCountReadOnly { get; }
        public IReadOnlyReactiveProperty<int> EngineCountReadOnly { get; }
        public IReadOnlyReactiveProperty<int> AircraftBodyCountReadOnly { get; }
    }
}