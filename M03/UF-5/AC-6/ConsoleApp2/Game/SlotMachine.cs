// Game/SlotMachine.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Game.Models;
using Game.Services;

namespace Game
{
    public class SlotMachine
    {
        public static readonly Dictionary<string, (string emoji, int points)> RobotData = new()
        {
            { "R2D2", ("🤖", 3) },  // 3 points for R2D2
            { "C3PO", ("🟡", 2) },  // 2 points for C3PO
            { "BB8", ("⚽", 1) }    // 1 point for BB8
        };

        private readonly ProductionOrderManager<Robot> productionManager = new();
        private int totalPoints = 0;
        private int spinsLeft = 10;
        private readonly ConsoleColor[] slotColors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };
        private readonly HttpClient httpClient = new();

        public async Task Play()
        {
            Console.Clear();
            PrintHeader();
            PrintLegend();

            while (spinsLeft > 0)
            {
                PrintStatus();
                Console.WriteLine("\nPress any key to spin...");
                Console.ReadKey(true);

                await Spin();
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

        private async Task Spin()
        {
            Console.WriteLine("\nSpinning...");

            // Animation with API calls
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\r");
                var tempResult = await GenerateSpinResult();
                for (int j = 0; j < 3; j++)
                {
                    Console.ForegroundColor = slotColors[j];
                    Console.Write($"[{RobotData[tempResult[j]].emoji}] ");
                    Console.ResetColor();
                }
                await Task.Delay(100 + i * 20);
            }

            string[] result = await GenerateSpinResult();
            DisplayResult(result);
            ProcessResult(result);
        }

        private async Task<string[]> GenerateSpinResult()
        {
            try
            {
                var response = await httpClient.GetStringAsync("https://randomnumberapi.com/api/v1.0/random?min=1&max=4&count=3");
                var numbers = JsonConvert.DeserializeObject<int[]>(response);

                return numbers.Select(n =>
                    n switch
                    {
                        1 => "R2D2",
                        2 => "C3PO",
                        3 => "BB8",
                        4 => "R2D2", // Map 4 to R2D2 since we only have 3 models
                        _ => throw new Exception("Invalid number from API")
                    }).ToArray();
            }
            catch
            {
                // Fallback if API fails
                Random random = new();
                return Enumerable.Range(0, 3)
                    .Select(_ => RobotData.Keys.ElementAt(random.Next(RobotData.Count)))
                    .ToArray();
            }
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
                string playerName = Console.ReadLine()?.Trim() ?? "Anonymous";

                string fileName = "scores.txt";

                // Create the entry with all required fields
                string entry = $"{playerName}|{totalPoints}|{DateTime.Now:yyyy-MM-dd HH:mm}|" +
                             $"{productionManager.CountByModel("R2D2")}|" +
                             $"{productionManager.CountByModel("C3PO")}|" +
                             $"{productionManager.CountByModel("BB8")}";

                // Append to file
                File.AppendAllText(fileName, entry + Environment.NewLine);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Results saved successfully!");
                Console.ResetColor();

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
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("No leaderboard entries yet.");
                    return;
                }

                var leaderboard = File.ReadAllLines(fileName)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line =>
                    {
                        var parts = line.Split('|');
                        return new
                        {
                            Name = parts.Length > 0 ? parts[0] : "Unknown",
                            Points = parts.Length > 1 && int.TryParse(parts[1], out int points) ? points : 0,
                            Date = parts.Length > 2 ? parts[2] : "Unknown",
                            R2D2Count = parts.Length > 3 ? parts[3] : "0",
                            C3POCount = parts.Length > 4 ? parts[4] : "0",
                            BB8Count = parts.Length > 5 ? parts[5] : "0"
                        };
                    })
                    .OrderByDescending(entry => entry.Points)
                    .Take(3)
                    .ToList();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🏆 TOP 3 SCORES 🏆");
                Console.ResetColor();

                if (leaderboard.Count == 0)
                {
                    Console.WriteLine("No valid entries in leaderboard.");
                    return;
                }

                for (int i = 0; i < leaderboard.Count; i++)
                {
                    var entry = leaderboard[i];
                    Console.WriteLine($"{i + 1}. {entry.Name} - {entry.Points} points " +
                                    $"(R2D2: {entry.R2D2Count}, C3PO: {entry.C3POCount}, BB8: {entry.BB8Count}) - {entry.Date}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error displaying leaderboard: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}