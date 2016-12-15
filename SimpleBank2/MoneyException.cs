using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    class MoneyException : InvalidOperationException
    {
        public MoneyException(string message) : base(message)
        {
        }


    }
}
