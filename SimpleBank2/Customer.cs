using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        private List<Account> account = new List<Account>();
        public List<Account> Accounts
        {
            get
            {
                return account;
            }
            set
            {
                Contract.Requires(value != null);
                account = value;

            }
        }
    }
}
