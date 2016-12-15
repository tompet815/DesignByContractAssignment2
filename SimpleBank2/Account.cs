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
        public string Number { get; set; }
        public double Balance { get; set; }
        public List<Movement> Movements { get; set; }
        [ContractInvariantMethod]
        private void InvariantMethod()
        {
            Contract.Invariant(Balance >= 0);
        }
    }

    
}
