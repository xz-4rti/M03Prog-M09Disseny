using System;

namespace SlotMachineGame.Models
{
    public abstract class Robot
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Model { get; protected set; }
        public DateTime CreationDate { get; }

        protected Robot(string model)
        {
            Id = nextId++;
            Model = model;
            CreationDate = DateTime.Now;
        }

        public abstract void ShowData();
    }
}
