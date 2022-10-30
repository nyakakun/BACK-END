using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard
{
    public class BoardColumn
    {
        public string Name { get;}
        private List<Objective> _objectives;

        public BoardColumn(string name)
        {
            Name = name;
            _objectives = new List<Objective>();
        }

        public int GetAmountObjectives()
        {
            return _objectives.Count;
        }

        public void AddObjective(string name, string description, PriorytyType prioryty)
        {
           _objectives.Add(new Objective(name, description, prioryty));
        }

        public Objective? GetObjective(string name)
        {
            return _objectives.Find(Obj => Obj.Name == name);
        }
                

        public bool RemoveObjective(string name)
        {
            var obj = _objectives.Find(Obj => Obj.Name == name);
            if (obj != null)
            {
                _objectives.RemoveAt(_objectives.IndexOf(obj));
                return true;
            }
            return false;
        }

        public void ShowObjectives()
        {
            foreach (Objective obj in _objectives)
            {
                Console.WriteLine("  ", obj.Name);
                Console.WriteLine("  ", obj.Description);
                Console.WriteLine("  ", obj.Priority);
                Console.WriteLine();
            }
        }

        
    }
}

