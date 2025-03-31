// Models/C3PO.cs
using System;

namespace Game.Models
{
    public class C3PO : Robot
    {
        public int RepairCount { get; }
        public bool IsPolished { get; }

        public C3PO() : base("C3PO")
        {
            RepairCount = new Random().Next(0, 5);
            IsPolished = new Random().Next(2) == 0;
        }

        public override void ShowData()
        {
            Console.WriteLine($"🌟 C3PO #{Id} - Repaired {RepairCount}x - " +
                            $"{(IsPolished ? "Shiny!" : "Needs polishing")} - Created: {CreationDate:T}");
        }
    }
}