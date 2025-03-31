using System;

namespace SlotMachineGame.Models
{
    public class R2D2 : Robot
    {
        public int Version { get; }
        public int BattleScars { get; }

        public R2D2() : base("R2D2")
        {
            Version = new Random().Next(1, 10);
            BattleScars = new Random().Next(0, 20);
        }

        public override void ShowData()
        {
            Console.WriteLine($"🔧 R2D2 #{Id} (v{Version}) - {BattleScars} battles - Created: {CreationDate:T}");
        }
    }
}
