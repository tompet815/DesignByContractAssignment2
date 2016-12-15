using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
