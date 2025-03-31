using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SlotMachineGame.Models;
using SlotMachineGame.Services;

namespace SlotMachineGame.Game
{
    public class SlotMachine
{
   public static readonly Dictionary<string, (string emoji, int points)> RobotData = new()
    {
        { "R2D2", ("🤖", 3) },  // Robot emoji
        { "C3PO", ("🟡", 2) },  // Yellow circle (golden robot)
        { "BB8", ("⚽", 1) }    // Ball emoji (for BB8's round shape)
    };

    private static readonly Random Random = new();
    private readonly ProductionOrderManager<Robot> productionManager = new();
    private int totalPoints = 0;
    private int spinsLeft = 10;
    private readonly ConsoleColor[] slotColors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };

    public void Play()
    {
        Console.Clear();
        PrintHeader();
        PrintLegend();

        while (spinsLeft > 0)
        {
            PrintStatus();
            Console.WriteLine("\nPress any key to spin...");
            Console.ReadKey(true);
            
            Spin();
            spinsLeft--;
        }
        
        EndGame();
    }

    private void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== 🤖🎰 ROBOT FACTORY SLOT MACHINE 🎰🤖 ===");
        Console.ResetColor();
    }

    private void PrintLegend()
    {
        Console.WriteLine("\n💰 Legend:");
        foreach (var (model, data) in RobotData)
        {
            Console.WriteLine($"  {data.emoji} {model}: {data.points} pts each");
        }
        Console.WriteLine("  🎯 3-of-a-kind: +10 bonus");
        Console.WriteLine("  🎯 2-of-a-kind: +5 bonus");
    }

    private void PrintStatus()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nSpins left: {spinsLeft} | Total points: {totalPoints}");
        Console.ResetColor();
    }

    private void Spin()
    {
        Console.WriteLine("\nSpinning...");
        
        // Animation with different emojis
        string[] spinnerEmojis = { "⚡", "💫", "✨", "🌟", "🌠" };
        for (int i = 0; i < 10; i++)
        {
            Console.Write("\r");
            for (int j = 0; j < 3; j++)
            {
                Console.ForegroundColor = slotColors[j];
                Console.Write($"[{spinnerEmojis[Random.Next(spinnerEmojis.Length)]}] ");
                Console.ResetColor();
            }
            Thread.Sleep(100 + i * 20);
        }

        string[] result = GenerateSpinResult();
        DisplayResult(result);
        ProcessResult(result);
    }

    private string[] GenerateSpinResult()
    {
        return Enumerable.Range(0, 3)
            .Select(_ => RobotData.Keys.ElementAt(Random.Next(RobotData.Count)))
            .ToArray();
    }

    private void DisplayResult(string[] result)
    {
        Console.Write("\r");
        for (int i = 0; i < 3; i++)
        {
            Console.ForegroundColor = slotColors[i];
            Console.Write($"[{RobotData[result[i]].emoji} {result[i]}] ");
            Console.ResetColor();
        }
        Console.WriteLine();
    }

    private void ProcessResult(string[] result)
    {
        var robots = result.Select(RobotFactory.CreateRobot).ToList();
        robots.ForEach(productionManager.AddOrder);

        int bonus = CalculateBonus(result);
        int spinPoints = robots.Sum(r => RobotData[r.Model].points) + bonus;
        totalPoints += spinPoints;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nSpin results:");
        Console.WriteLine($"- Robots created: {string.Join(", ", result)}");
        Console.WriteLine($"- Base points: {spinPoints - bonus}");
        if (bonus > 0) Console.WriteLine($"- Bonus: +{bonus} 🎉");
        Console.WriteLine($"- Total this spin: {spinPoints}");
        Console.ResetColor();
    }

    private int CalculateBonus(string[] result)
    {
        var groups = result.GroupBy(x => x).ToList();
        
        if (groups.Any(g => g.Count() == 3))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🎰 JACKPOT! 3 OF A KIND! +10 BONUS 🎰");
            Console.ResetColor();
            return 10;
        }
        
        if (groups.Any(g => g.Count() == 2))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n🎯 NICE! 2 OF A KIND! +5 BONUS 🎯");
            Console.ResetColor();
            return 5;
        }
        
        return 0;
    }

    private void EndGame()
    {
        Console.Clear();
        PrintHeader();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== 🏁 GAME OVER 🏁 ===");
        Console.WriteLine($"🎯 FINAL SCORE: {totalPoints} points");
        Console.ResetColor();

        PrintProductionSummary();
        SaveResults();
    }

    private void PrintProductionSummary()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n=== 📊 PRODUCTION SUMMARY 📊 ===");
        Console.ResetColor();

        productionManager.DisplayOrders();

        Console.WriteLine("\n📈 Statistics:");
        Console.WriteLine($"- Total robots produced: {productionManager.TotalRobots()}");
        foreach (var model in RobotData.Keys)
        {
            Console.WriteLine($"- {model} robots: {productionManager.CountByModel(model)} " +
                             $"(Total points: {productionManager.PointsByModel(model)})");
        }
    }

    private void SaveResults()
    {
        try
        {
            Console.Write("\nEnter your name for the leaderboard: ");
            string playerName = Console.ReadLine() ?? "Anonymous";

            string fileName = "leaderboard.txt";
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm}|{playerName}|{totalPoints}|{productionManager.TotalRobots()}\n";

            File.AppendAllText(fileName, entry);
            DisplayLeaderboard(fileName);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error saving results: {ex.Message}");
            Console.ResetColor();
        }
    }

    private void DisplayLeaderboard(string fileName)
    {
        if (!File.Exists(fileName)) return;

        var leaderboard = File.ReadAllLines(fileName)
            .Select(line => line.Split('|'))
            .OrderByDescending(parts => int.Parse(parts[2]))
            .Take(3)
            .ToList();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n🏆 TOP 3 SCORES 🏆");
        Console.ResetColor();
        
        for (int i = 0; i < leaderboard.Count; i++)
        {
            var entry = leaderboard[i];
            Console.WriteLine($"{i+1}. {entry[1]} - {entry[2]} points ({entry[3]} robots) - {entry[0]}");
        }
    }
}
}
