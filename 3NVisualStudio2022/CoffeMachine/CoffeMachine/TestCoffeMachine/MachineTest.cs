using CoffeMachine;
namespace TestCoffeMachine
{
    [TestClass]
    public class MachineTest
    {
        [TestMethod]
        public void InsertedInCent_WithValidPrice_UpdatesPriceInCent()
        {
            Machine machine= new Machine(100);
            machine.AddInsertedCent(100);
            int expected = 100;
            int actual = machine.InsertedInCent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void PriceInCent_WithNotValidPrice_ShouldThrowException()
        {
            Machine machine = new Machine(-1);

            Assert.ThrowsException<IndexOutOfRangeException>(() => machine.PriceInCent);
        }

        [TestMethod]
        public void InsertedInCent_WithNotValidPrice_ShouldThrowException()
        {
            Machine machine = new Machine(100,-1);
            Assert.ThrowsException<IndexOutOfRangeException>(()=>machine.InsertedInCent);
        }
    }
}