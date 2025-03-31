public static class RobotFactory
{
    public static Robot CreateRobot(string model)
    {
        return model switch
        {
            "R2D2" => new R2D2(),
            "C3PO" => new C3PO(),
            "BB8" => new BB8(),
            _ => throw new ArgumentException("Invalid robot model")
        };
    }
}