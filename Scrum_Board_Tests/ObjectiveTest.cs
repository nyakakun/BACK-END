using Xunit;
using ScrumBoard;

namespace Objective_Tests
{
    public class ObjectiveTests
    {
        [Fact]
        public void Create_Objective_With_Name_Description_Prioryty()
        {
            string name = "name";
            string description = "description";

            var objective = new Objective(name, description, PriorytyType.High);

            Assert.Equal(name, objective.Name);
            Assert.Equal(description, objective.Description);
            Assert.Equal(PriorytyType.High, objective.Priority);
            
        }
    }
    
}
