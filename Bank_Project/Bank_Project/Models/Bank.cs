using Bank_Project.Enums;
using Bank_Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project.Models
{
    internal class Bank
    {
        Bank[] bankaccounts = new Bank [0];



        #region CreateAccount
        public void CreateAccount(AcoountTypeEnum accountType , CurrencyTypeEnum currencyType)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.AccountType = accountType.ToString();
            bankAccount.CurrencyType = currencyType.ToString();
            bankAccount.Balance = 0;
            bankAccount.AccountId = bankaccounts.Length + 1;
            Array.Resize(ref bankaccounts, bankaccounts.Length+1);
            bankaccounts[bankaccounts.Length - 1] = bankAccount;
            Console.WriteLine($"Account created succesfully . \n account id (dont't fotget it !): {bankAccount.AccountId} Balance : {bankAccount.Balance} Account type: {bankAccount.AccountType} Currency type : {bankAccount.CurrencyType} ");

        }
        #endregion

        #region DepositMoney
        public void DepositMoney(int accountid )

        {
            if (bankaccounts != null )
            {
                foreach (BankAccount bankAccount in bankaccounts)
                {
                    if(bankAccount.AccountId == accountid)
                    {
                        Console.WriteLine("Enter amount:");
                        decimal amount=Convert.ToDecimal(Console.ReadLine());
                        if(amount > 0)
                        {

                            bankAccount.Balance += amount;
                            Transaction transaction = new Transaction();
                            transaction.Amount = amount;
                            transaction.TransactionDate = DateTime.Now;
                            transaction.TransactionType = "Deposit";
                            transaction.TransactionId = bankAccount.transactions.Length+1;
                            Array.Resize(ref bankAccount.transactions, bankAccount.transactions.Length + 1);
                            bankAccount.transactions[bankAccount.transactions.Length - 1]= transaction;
                            Console.WriteLine($"Your balance updated . \n New Balance: {bankAccount.Balance}");
                        }
                        else
                        {
                            throw new InvalidAmountException("Invalid amount.");
                        }
                    }


                    

                }
            }
            else
            {
                throw new AccountNotFoundException("Account not found.");

            }

        }
        #endregion

        #region WithdrawMoney
        public void WithdrawMoney(int accountid)
        {
            int count = 0;
            if (bankaccounts != null)
            {
                foreach (BankAccount bankAccount in bankaccounts)
                {
                    count++;
                    if (bankAccount.AccountId == accountid)
                    {
                        Console.WriteLine("Enter amount:");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        if (amount > 0)
                        {
                            if (amount <= bankAccount.Balance)
                            {
                                 bankAccount.Balance -= amount;
                                Transaction transaction = new Transaction();
                                transaction.Amount = amount;
                                transaction.TransactionDate = DateTime.Now;
                                transaction.TransactionType = "Withdraw";
                                transaction.TransactionId = bankAccount.transactions.Length + 1;
                                Array.Resize(ref bankAccount.transactions, bankAccount.transactions.Length + 1);
                                bankAccount.transactions[bankAccount.transactions.Length - 1] = transaction;
                                Console.WriteLine($"Your balance updated . \n New Balance: {bankAccount.Balance}");
                            }
                            else
                            {
                                throw new InsufficientFundsException("Insufficient funds");


                            }

                           
                        }
                        else
                        {
                            throw new InvalidAmountException("Invalid amount.");
                            

                        }
                    }




                }
            }
            else
            {
                throw new AccountNotFoundException("Account not found.");
            }

        }

        #endregion

        #region ListAccounts
        public void ListAccounts()
        {
            if (bankaccounts!=null)
            {
                Console.WriteLine($"there are {bankaccounts.Length} accounts in our bank \n ");
                foreach (BankAccount bankAccount in bankaccounts)
                {
                     Console.WriteLine("--------------------------------------------------------");
                     Console.WriteLine($" Account id: {bankAccount.AccountId}   Account type : {bankAccount.AccountType}  Currency type : {bankAccount.CurrencyType}  Balance: {bankAccount.Balance} ");
                }
            
            }
            if(bankaccounts.Length==0) 
            {
                Console.WriteLine("List is empty :(");
            }
        }

        #endregion

        #region ListTransactions
        public void ListTransactions()
        {
            if(bankaccounts!=null )
            {
                foreach (BankAccount bankAccount in bankaccounts)
                {
                    if (bankAccount.transactions != null)
                    {
                        Console.WriteLine($"account id {bankAccount.AccountId}");
                        foreach (Transaction transaction in bankAccount.transactions)
                        {

                            Console.WriteLine($"Transaction type : {transaction.TransactionType} , Transaction amount: {transaction.Amount} transaction date {transaction.TransactionDate}");
                        }
                    }

                }
            }
            if (bankaccounts.Length==0) 
            {
                Console.WriteLine("Transaction list is empty :(");
            }


        }
        #endregion


        public void TransferMoney(int fromId, int toId )
        {
            if( bankaccounts!=null )
            {
                bool check = false;
                foreach(BankAccount bankAccount in bankaccounts)
                {
                    if(bankAccount.AccountId== fromId)
                    {
                        check = true;
                    }
                }
                foreach (BankAccount bankAccount in bankaccounts)
                {
                    if(bankAccount.AccountId == toId)
                    {
                        check=true;
                    }
                }
                if( check ) 
                {
                    foreach (BankAccount bankAccount in bankaccounts)
                    {
                        if(bankAccount.AccountId==fromId)
                        {
                            bankAccount.WithdrawMoney(fromId);
                        }
                        if (bankAccount.AccountId == toId)
                        {
                            bankAccount.DepositMoney(toId);
                        }
                    }
                }

            }
        }


    }
}
