using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ScrumBoard
{
    public enum PriorytyType
    {
        Low,
        Middle,
        High
    }

    public class Objective
    {
        public string Name { get; }
        public string Description { get; }

        public PriorytyType Priority { get; }

        public Objective(string name, string description, PriorytyType prioryty)
        {
            Name = name;
            Description = description;
            Priority = prioryty;
        }
    }
}
