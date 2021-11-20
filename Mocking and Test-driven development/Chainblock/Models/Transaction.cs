using Chainblock.Contracts;
using Chainblock.Enumerators;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }
        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }
    }
}