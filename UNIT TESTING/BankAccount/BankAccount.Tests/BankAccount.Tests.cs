namespace BankAccount.Tests
{
    public class BankAccountTests
    {
        [TestCase(1000,1000)]
        [TestCase(5000,5000)]
        [TestCase(10000,10000)]
        [TestCase(0,0)]
        public void BankAccountShouldInitilizeWithAmout(decimal amout, decimal expcetedAmout)
        {
            BankAccount bankAccount = new BankAccount(amout);

            Assert.AreEqual(expcetedAmout, bankAccount.Ammount);
            Assert.That(expcetedAmout == bankAccount.Ammount);
            Assert.IsTrue(expcetedAmout == bankAccount.Ammount);
            Assert.That(expcetedAmout, Is.EqualTo(bankAccount.Ammount));
        }
    }
}