using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
   public class Movement
    {public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Account Source { get; set; }
        public Account Target { get; set; }
        public Movement(double amount, Account source, Account target) {
            Contract.Requires(amount > 0);
            Contract.Requires(source != null);
            Contract.Requires(target != null);
            Date = DateTime.UtcNow;
            Amount = amount;
            Source = source;
            Target = target;

        }
    }
}
