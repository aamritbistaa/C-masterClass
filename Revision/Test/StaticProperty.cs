using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Bank
    {
        public static double _balance;

        public Bank():this(200)
        {
            Console.WriteLine("initialized");
            CheckBalance();

        }
        public Bank(double balance = 0)
        {
            _balance = balance;
            CheckBalance();
        }

        public void Withdraw(double amount)
        {
            if (_balance - amount > 0)
            {
                _balance = _balance - amount;
                CheckBalance();
            }
            else
            {
                Console.WriteLine("You dont have sufficient money");
            }
        }
        public void Deposit(double amount)
        {
            _balance = _balance+amount;
            CheckBalance();

        }
        public void CheckBalance()
        {
            Console.WriteLine(_balance);
        }
    }
    public class StaticProperty
    {


        public void MainFunction()
        {
            Bank bank = new Bank();
            bank.Deposit(10000);
            bank.Withdraw(1000);

        }
    }
}
