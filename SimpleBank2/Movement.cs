using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    public class Movement
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Movement(double amount)
        {
            Contract.Requires(amount > 0);
            Date = DateTime.UtcNow;
            Amount = amount;

        }
    }
}
