using CoffeMachine;
namespace TestCoffeMachine
{
    [TestClass]
    public class MachineTest
    {

        [TestMethod]
        public void PriceInCent_WithValidPrice_IsCorrect()
        {
            Machine machine = new Machine(100);
            int expected = 100;
            int actual = machine.PriceInCent;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InsertedInCent_WithValidPrice_UpdatesPriceInCent()
        {
            Machine machine = new Machine(100);
            machine.AddInsertedCent(100);
            int expected = 100;
            int actual = machine.InsertedInCent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetInsertedCents_IsCorrect_UpdateInsertedInCent()
        {
            Machine machine = new Machine(100, 50);
            machine.ResetInsertedCent;
            int expected = 0;
            int actual = machine.InsertedInCent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InsertedInCent_WithNotValidPrice_ShouldThrowException()
        {
            Machine machine = new Machine(100);


            Assert.ThrowsException<IndexOutOfRangeException>(() => machine.AddInsertedCent(-1));
        }

        [TestMethod]
        public void ReadyForCoffee_Illegal_State_ShouldThrowException()
        {
            Machine machine = new Machine(100);
            machine.offMachine;
            Assert.ThrowsException<InvalidOperationException>(() => machine.ReadyForCoffe);

        }

        [TestMethod]
        public void CreditInCent_WithValidPriceAndInsertedCoind_IsCorrect()
        {
            Machine machine = new Machine(100);
            machine.AddInsertedCent(150);
            int expected = 50;
            machine.MakeCoffe;
            int actual = machine.CreditInCent;
            Assert.AreEqual(expected, actual);
        }



    }
}