using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Wallet
    {
        
        private decimal balance = 0;
        public void AddMoney(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Successfully deposited {amount:C}. Current Balance: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid amount. positive amount is only allowed");
            }
        }

       
        public decimal GetBalance()
        {
            return balance;
        }

        static void Main()
        {
            Wallet myWallet = new Wallet();

            myWallet.AddMoney(100);  
            Console.WriteLine($"balance is: {myWallet.GetBalance():C}");

            myWallet.AddMoney(-50); 
        }
    }

    
    

