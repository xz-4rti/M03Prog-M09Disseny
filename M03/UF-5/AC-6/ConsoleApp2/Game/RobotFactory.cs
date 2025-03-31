// Game/RobotFactory.cs
namespace Game
{
    public static class RobotFactory
    {
        public static Models.Robot CreateRobot(string model)
        {
            return model switch
            {
                "R2D2" => new Models.R2D2(),
                "C3PO" => new Models.C3PO(),
                "BB8" => new Models.BB8(),
                _ => throw new ArgumentException("Invalid robot model")
            };
        }
    }
}