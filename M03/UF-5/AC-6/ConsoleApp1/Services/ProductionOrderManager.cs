using System;
using System.Collections.Generic;
using System.Linq;
using SlotMachineGame.Models;

namespace SlotMachineGame.Services
{
    public class ProductionOrderManager<T> where T : Robot
{
    private readonly List<T> orders = new();

    public void AddOrder(T order) => orders.Add(order);

    public void DisplayOrders()
    {
        Console.WriteLine("\n🤖 Production Orders:");
        foreach (var order in orders)
        {
            order.ShowData();
        }
    }

    public int TotalRobots() => orders.Count;
    public int CountByModel(string model) => orders.Count(r => r.Model == model);
    
    public int PointsByModel(string model) => 
        orders.Where(r => r.Model == model)
              .Sum(r => SlotMachine.RobotData[r.Model].points);
}
}
