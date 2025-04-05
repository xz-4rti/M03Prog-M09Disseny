// Services/ProductionOrderManager.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Game.Models;

namespace Game.Services
{
    public class ProductionOrderManager<T> where T : Robot
    {
        private readonly List<T> orders = new();

        public void AddOrder(T order) => orders.Add(order);

        public void DisplayOrders()
        {
            Console.WriteLine("\n🤖 Production Orders:");
            orders.ForEach(order => order.ShowData());
            Console.WriteLine($"Total: {orders.Count} orders\n");
        }

        public int TotalRobots() => orders.Count;
        public int CountByModel(string model) => orders
            .Count(r => r.Model == model);
        
        public int PointsByModel(string model) => orders
            .Where(r => r.Model == model)
            .Sum(r => SlotMachine.RobotData[r.Model].points);
    }
}