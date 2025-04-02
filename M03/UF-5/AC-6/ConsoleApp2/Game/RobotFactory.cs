// Game/RobotFactory.cs
namespace Game
{
    public static class RobotFactory
    {
        public static Models.Robot CreateRobot(string model)
        {
            switch(model)
            {
                case "R2D2":
                    return new Models.R2D2();
                case "C3PO":
                    return new Models.C3PO();
                case "BB8":
                    return new Models.BB8();
                default:
                    throw new ArgumentException("Invalid robot model");
            }
        }
    }
}