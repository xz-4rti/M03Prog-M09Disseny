using System;

namespace SlotMachineGame.Models
{
    public class BB8 : Robot
    {
        public float Version { get; }
        public int SpinCount { get; }

        public BB8() : base("BB8")
        {
            Version = (float)Math.Round(new Random().NextDouble() * 4 + 1, 1);
            SpinCount = new Random().Next(0, 100);
        }

        public override void ShowData()
        {
            Console.WriteLine($"🌀 BB8 #{Id} (v{Version}) - Spun {SpinCount}x - Created: {CreationDate:T}");
        }
    }
}
