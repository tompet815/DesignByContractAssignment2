using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new SimpleBank2.Bank("testBank");

            Account a1 = new Account() { Number = "12345", Balance = 100, Credits = new List<Movement>(), Debits = new List<Movement>() };
            Account a2 = new Account() { Number = "54321", Credits = new List<Movement>(), Debits = new List<Movement>() };
            List<Account> as1 = new List<Account>();
            as1.Add(a1);
            List<Account> as2 = new List<Account>();
            as2.Add(a2);

            Customer c1 = new SimpleBank2.Customer() { Id = "111111111", Name = "Test Name", Accounts = as1 };
            Customer c2 = new SimpleBank2.Customer() { Id = "999999999", Name = "Sato Taro", Accounts = as2 };

            bank.Move(40, a1, a2);
            Console.WriteLine(a1.Balance);
            Console.WriteLine(a2.Balance);

            
            //bank.Move(100, a1, a2);// Breaking contract
            //Console.WriteLine(a1.Balance);
            //Console.WriteLine(a2.Balance);
            Console.ReadLine();
        }
    }
}
