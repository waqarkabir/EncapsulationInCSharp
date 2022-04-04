namespace Models
{
    public class BankAccount
    {
        private static int index = 1000;
        public BankAccount(AccountType accountType)
        {
            Code = index;
            Created = DateTime.Now;
            AccountStatus = AccountStatus.Active;
            AccountType = accountType;


            index = index + 1;
        }

        // data variables
        // code
        public int Code { get; }

        // title
        private string title;

        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

        // craeted
        public DateTime Created { get; }

        // status
        public AccountStatus AccountStatus { get; private set; }

        // account type
        public AccountType AccountType { get; }

        // balance
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        // methods
        // with draw
        public bool WithDraw(decimal amount)
        {
            if(amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }

        // pay in
        public bool PayIn(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            Balance += amount;
            return true;
        }
    }

    public enum AccountStatus
    {
        Active = 1,
        Passive
    }

    public enum AccountType
    {
        Saving,
        Current
    }
}