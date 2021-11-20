using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;
using Chainblock.Enumerators;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions = new Dictionary<int, ITransaction>();

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.ContainsKey(tx.Id))
            {
                throw new ArgumentException();
            }

            transactions[tx.Id] = tx;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx) => this.Contains(tx.Id);

        public bool Contains(int id) => this.transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return transactions.Values.Where(x => x.Amount >= lo && x.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return transactions
                .Select(x => x.Value)
                .OrderByDescending(x => x.Amount)
                .ThenByDescending(x => x.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var result = transactions
                .Values.Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var receivers = new List<string>();

            foreach (var transaction in result)
            {
                receivers.Add(transaction.To);
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var result = transactions
                .Values.Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var senders = new List<string>();

            foreach (var transaction in result)
            {
                senders.Add(transaction.From);
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = transactions
                .Values.Where(x => x.To == receiver && x.Amount <= lo && x.Amount < hi)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = transactions
                .Select(x => x.Value)
                .Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var result = transactions
                .Values.Where(x => x.From == sender && x.Amount > amount)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = transactions
                .Select(x => x.Value)
                .Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var result = transactions
                .Values.Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return transactions
                .Values.Where(x => x.Status == status && x.Amount <= amount)
                .OrderByDescending(x => x.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!Contains(id))
            {
                throw new InvalidOperationException();
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}