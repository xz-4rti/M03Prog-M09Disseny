using System;
using System.Threading.Tasks;
using Game;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        await new SlotMachine().Play();
    }
}
