using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    public class Bank
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
            Contract.Requires(source.Credits != null);
            Contract.Requires(target.Debits != null);

            Contract.Requires(amount > 0);
            Contract.EnsuresOnThrow<MoneyException>(Contract.OldValue<double>(target.Balance) == target.Balance &&
            Contract.OldValue<double>(source.Balance) == source.Balance);
            Contract.Ensures(Customers.Sum(c => c.Accounts.Sum(a => a.Credits.Sum(ac => ac.Amount))) + Customers.Sum(c => c.Accounts.Sum(a => a.Debits.Sum(ac => ac.Amount))) == 0);
            try
            {
                if (source.Balance < amount) {
                    throw new MoneyException("Source account has not enough balance!");
                }
                var creditMovement = new Movement(amount*-1);
                var debitMovement = new Movement(amount);

                source.Credits.Add(creditMovement);
                target.Debits.Add(debitMovement);
            }
            catch (MoneyException me) {
                Console.WriteLine(me.Message);
            }

        }
        public List<Movement> MakeStatement(Customer customer, string account)
        {
            Contract.Ensures(Contract.Result<List<Movement>>() != null);
            
            var credits= new List<Movement>();
            var debits= new List<Movement>();
         
            try
            {
                credits = Customers.Find(x => x.Id.Equals(customer.Id)).Accounts
                    .Find(x => x.Number.Equals(account)).Credits;
                debits = Customers.Find(x => x.Id.Equals(customer.Id)).Accounts
         .Find(x => x.Number.Equals(account)).Debits;

           }
            catch (NullReferenceException ne) {
                
            }
             credits.AddRange(debits);
            return credits;
        }
        [ContractInvariantMethod]
        private void InvariantMethod()
        {
            Contract.Invariant(Customers != null);

        }
    }
}
