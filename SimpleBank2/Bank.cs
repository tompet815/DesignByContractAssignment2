using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    class Bank
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

        public Bank(string name)
        {
            Name = name;
            Customers = new List<Customer>();
        }

        public void Move(double amount, Account source, Account target)
        {
            Contract.Requires(source != null);
            Contract.Requires(target != null);
            Contract.Requires(amount > 0);
            Contract.EnsuresOnThrow<MoneyException>(Contract.OldValue<double>(target.Balance) == target.Balance &&
            Contract.OldValue<double>(source.Balance) == source.Balance);
            Contract.Ensures((Contract.OldValue<double>(source.Balance) - source.Balance) + (Contract.OldValue<double>(target.Balance) - target.Balance) == 0);

            if (target == null || source == null)
            {
                throw new MoneyException("account is null");
            }

            source.Balance -= amount;
            target.Balance += amount;

            var newMovement = new Movement(amount, source, target);
            source.Movements.Add(newMovement);
            target.Movements.Add(newMovement);

        }
        public List<Movement> MakeStatement(Customer customer, string account)
        {
            var movements = Customers.Find(x => x.Id.Equals(customer.Id)).Accounts
                .Find(x => x.Number.Equals(account)).Movements;
            return movements.OrderBy(x => x.Date).ToList();

        }
       
    }
}
