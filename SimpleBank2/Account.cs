using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    public class Account
    {
        private double balance = 0;
        public string Number { get; set; }
        public double Balance
        {
            get
            {
                Contract.Ensures(Credits != null);
                Contract.Ensures(Debits != null);
                Contract.Ensures(Balance >= 0);
                return balance + Debits.Sum(d => d.Amount) - Credits.Sum(c => c.Amount);
            }
            set {
                Contract.Requires(value > 0);
                Contract.Ensures(Balance >= 0);
                balance = value;
            }
        }

        public List<Movement> Debits { get; set; }
        public List<Movement> Credits { get; set; }
        public Account()
        {
            Debits = new List<Movement>();
            Credits = new List<Movement>();
        }
        [ContractInvariantMethod]
        private void InvariantMethod()
        {
            Contract.Invariant(Balance >= 0);

        }
    }


}
