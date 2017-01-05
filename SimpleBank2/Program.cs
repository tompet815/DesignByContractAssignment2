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

            Account a1 = new Account() { Number = "12345", Balance = 100 };
            Account a2 = new Account() { Number = "54321" };
            List<Account> as1 = new List<Account>();
            as1.Add(a1);
            List<Account> as2 = new List<Account>();
            as2.Add(a2);

            Customer c1 = new SimpleBank2.Customer() { Id = "111111111", Name = "Test Name", Accounts = as1 };
            Customer c2 = new SimpleBank2.Customer() { Id = "999999999", Name = "Sato Taro", Accounts = as2 };
            bank.Customers.Add(c1);
            bank.Customers.Add(c2);

            bank.Move(40, a1, a2);
            bank.Move(20, a2, a1);
            bank.Move(30, a1, a2);

            Console.WriteLine("=====Movements of Customer 1============");
            var movements=bank.MakeStatement(c1, "12345");
            foreach (var m in movements) {
                Console.WriteLine(m.Amount);

            }

            Console.WriteLine("=====Movements of Customer 2============");
            var movements2 = bank.MakeStatement(c2, "54321");
            foreach (var m in movements2)
            {
                Console.WriteLine(m.Amount);

            }

            //bank.Move(100, a1, a2);// Breaking contract
            //Console.WriteLine(a1.Balance);
            //Console.WriteLine(a2.Balance);
            Console.ReadLine();
        }
    }
}
