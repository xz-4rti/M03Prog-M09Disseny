// Models/BB8.cs
using System;

namespace Game.Models
{
    public class BB8 : Robot
    {
        public float Version { get; }
        public int SpinCount { get; }
        public int FlightCount { get; }

        public BB8() : base("BB8")
        {
            Version = (float)Math.Round(new Random().NextDouble() * 4 + 1, 1);
            SpinCount = new Random().Next(0, 100);
            FlightCount = new Random().Next(0, 50);
        }

        public override void ShowData()
        {
            Console.WriteLine($"🌀 BB8 #{Id} (v{Version}) - Flights: {FlightCount}, Spun {SpinCount}x - Created: {CreationDate:T}");
        }
    }
}