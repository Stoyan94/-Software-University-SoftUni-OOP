namespace BankAccount
{
    public class BankAccount
    {
        public BankAccount(decimal ammount)
        {
            this.Ammount = ammount;
        }

        public decimal Ammount { get; set; }
    }
}