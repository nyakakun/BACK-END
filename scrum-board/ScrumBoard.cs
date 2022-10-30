using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScrumBoard
{
    public class Board
    {
        private const int _columnLimit = 10;
        public string BoardName { get; }
        private List<BoardColumn> _columns;

        public Board(string name)
        {
            BoardName = name;
            _columns = new List<BoardColumn>();
        }

        public int GetCountColumns()
        {
            return _columns.Count;
        }

        public BoardColumn? GetColumn(string name)
        {
            return _columns.Find(col => col.Name == name);
        }
        
        public void AddColumn(string name)
        {
            if(_columns.Count < _columnLimit)
            {
                _columns.Add(new BoardColumn(name));
            }
            else
            {
                Console.WriteLine("Amount columns cant be more than 10");
            }
        }

        public bool AddObjective(string name, string description, PriorytyType prioryty)
        {
            if (_columns.Count() == 0) return false;
            _columns[0].AddObjective(name, description, prioryty);
            return true;
        }

        public bool MoveObjective(string nameColumn, string nameObjective, string targetColumn)
        {
            var column = _columns.Find(Col => Col.Name == nameColumn);
            if(column == null) return false;

            var objective = column.GetObjective(nameObjective);
            if(objective == null) return false;

            var targetCol = _columns.Find(Col => Col.Name == targetColumn);
            if(targetCol == null) return false;

            column.RemoveObjective(nameObjective);
            targetCol.AddObjective(objective.Name, objective.Description, objective.Priority);
            return true;
        }

        public void ShowBoard()
        {
            foreach(BoardColumn col in _columns)
            {
                Console.WriteLine(col.Name, ":");
                col.ShowObjectives();
            }
        }

    }
}
