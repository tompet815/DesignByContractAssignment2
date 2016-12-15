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
            Contract.Ensures(Customers.Sum(c => c.Accounts.Sum(a => a.Credits.Sum(ac => ac.Amount))) - Customers.Sum(c => c.Accounts.Sum(a => a.Debits.Sum(ac => ac.Amount))) == 0);
      
            if (target == null || source == null)
            {
                throw new MoneyException("account is null");
            }

            var newMovement = new Movement(amount);
            source.Credits.Add(newMovement);
            target.Debits.Add(newMovement);


        }
        public List<Movement> MakeStatement(Customer customer, string account)
        {
            
            var credits = Customers.Find(x => x.Id.Equals(customer.Id)).Accounts
                .Find(x => x.Number.Equals(account)).Credits;
            var debits = Customers.Find(x => x.Id.Equals(customer.Id)).Accounts
            .Find(x => x.Number.Equals(account)).Debits;
            credits.AddRange(debits);
            return credits;
        }
       
    }
}
