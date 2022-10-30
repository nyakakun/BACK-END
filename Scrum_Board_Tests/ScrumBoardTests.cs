using Xunit;
using ScrumBoard;


namespace Scrum_Board_Tests
{
    public class ScrumBoardTests
    {
        [Fact]
        public void Create_board_with_name()
        {
            string name = "name";
            
            var board = new Board(name);

            Assert.Equal(board.BoardName, name);
        }

        [Fact]
        public void Add_column_to_the_Board()
        {
            var board = new Board("name");

            board.AddColumn("name");

            Assert.Equal(1, board.GetCountColumns());
        }

        [Fact]
        public void Add_Objective()
        {
            var board = new Board("name");
            board.AddColumn("name");
            var resultColumn = new BoardColumn("name");
            resultColumn.AddObjective("name", "description", PriorytyType.High);

            board.AddObjective("name", "description", PriorytyType.High);

            Assert.Equal(board.GetColumn("name").Name, resultColumn.Name);
            
        }

        [Fact]
        public void Move_Objective()
        {
            var board = new Board("name");
            board.AddColumn("column1");
            board.AddColumn("column2");
            board.AddObjective("objective", "description", PriorytyType.High);

            board.MoveObjective("column1", "objective", "column2");

            var column1 = board.GetColumn("column1");
            var result = column1.GetObjective("objective");
            Assert.Null(result);

            result = board.GetColumn("column2").GetObjective("objective");
            Assert.NotNull(result);
            
        }

        [Fact] 
        public void Try_Move_Objective_From_Wrong_Colunm()
        {
            var board = new Board("name");
            board.AddColumn("column1");
            board.AddColumn("column2");
            board.AddObjective("objective", "description", PriorytyType.High);

            var result = board.MoveObjective("wrongColumn", "objective", "colunm2");

            Assert.False(result);
        }

        [Fact]
        public void Try_Move_Objective_To_Wrong_Column()
        {
            var board = new Board("name");
            board.AddColumn("column1");
            board.AddColumn("column2");
            board.AddObjective("objective", "description", PriorytyType.High);

            var result = board.MoveObjective("column1", "objective", "WrongColunm");

            Assert.False(result);
        }

        [Fact] 
        public void Try_Move_Wrong_Objective()
        {
            var board = new Board("name");
            board.AddColumn("column1");
            board.AddColumn("column2");
            board.AddObjective("objective", "description", PriorytyType.High);

            var result = board.MoveObjective("column1", "WrongObjective", "colunm2");

            Assert.False(result);
        }
    }

}
