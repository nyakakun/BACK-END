using Xunit;
using ScrumBoard;

namespace Board_Column_Tests
{
    public class BoardColumnTests
    {
        [Fact]
        public void Create_Column_With_Name()
        {
            string name = "name";

            var column = new BoardColumn(name);

            Assert.Equal(name, column.Name);
        }

        [Fact]
        public void Add_Objective()
        {
            string name = "name";
            var column = new BoardColumn(name);

            column.AddObjective("objective", "description", PriorytyType.High);

            Assert.Equal(1, column.GetAmountObjectives());
        }

        [Fact]
        public void Get_Objective_By_Name()
        {
            var column = new BoardColumn("name");
            var objective = new Objective("objective", "description", PriorytyType.High);

            column.AddObjective("objective", "description", PriorytyType.High);
            var resultObj = column.GetObjective("objective");

            Assert.Equal(resultObj.Name, objective.Name);
        }

        [Fact]
        public void Remove_Objective_By_Name()
        {
            var column = new BoardColumn("name");
            column.AddObjective("objective", "description", PriorytyType.High);

            column.RemoveObjective("objective");

            Assert.Equal(0, column.GetAmountObjectives());
        }


        [Fact]
        public void Cant_Remove_Objective_If_It_Does_Not_Exist()
        {
            var column = new BoardColumn("name");

            Assert.False(column.RemoveObjective("objective"));
        }
    }
}
