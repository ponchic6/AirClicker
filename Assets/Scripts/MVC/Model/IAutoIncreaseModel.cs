namespace MVC.Model
{
    public interface IAutoIncreaseModel
    {
        public int ChassisPerSecond { get; set; }
        public int EnginePerSecond { get; set; }
        public int BodyPerSecond { get; set; }
        public int RocketPerSecond { get; set; }
    }
}