namespace MVC.Model
{
    public class AutoIncreaseModel : IAutoIncreaseModel
    {
        public AutoIncreaseModel()
        {
            ChassisPerSecond = 1;
            EnginePerSecond = 1;
            BodyPerSecond = 1;
            RocketPerSecond = 1;
        }
        
        public int ChassisPerSecond { get; set; }
        public int EnginePerSecond { get; set; }
        public int BodyPerSecond { get; set; }
        public int RocketPerSecond { get; set; }
    }
}