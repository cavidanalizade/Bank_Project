using Bank_Project.Enums;
using Bank_Project.Exceptions;
using Bank_Project.Models;

class Program
{
    static void Main(string[] args)
    {



        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("----------------------MENYU----------------------");
            Console.WriteLine("----------------------WELCOME----------------------");
            Console.WriteLine("1. Create a new account");
            Console.WriteLine("2. Deposit money");
            Console.WriteLine("3. Withdraw money");
            Console.WriteLine("4.Show all accounts");
            Console.WriteLine("5.Transfer money between accounts");
            Console.WriteLine("6.Currency exchange");
            Console.WriteLine("7.Transactions list");
            Console.WriteLine("8.Exit");



            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Console.WriteLine("Enter account type with number (1.Checking 2.Savings 3.Business) :");
                    string typeChoice = Console.ReadLine();


                    switch (typeChoice)
                    {

                        case "1":
                            AcoountTypeEnum acoountType = AcoountTypeEnum.Checking;
                            Console.WriteLine("Enter currency type with number (1.USD 2. AZN 3.EUR)");
                            string currencyChoice = Console.ReadLine();

                            switch (currencyChoice)
                            {
                                case "1":
                                    CurrencyTypeEnum currencyType = CurrencyTypeEnum.USD;
                                    bank.CreateAccount(acoountType, currencyType);
                                    break;

                                case "2":
                                    CurrencyTypeEnum currencyType2 = CurrencyTypeEnum.AZN;
                                    bank.CreateAccount(acoountType, currencyType2);
                                    break;

                                case "3":
                                    CurrencyTypeEnum currencyType3 = CurrencyTypeEnum.EUR;
                                    bank.CreateAccount(acoountType, currencyType3);
                                    break;



                                default:
                                    Console.WriteLine("Wrong Input!!!");
                                    break;
                            }


                            break;


                        case "2":
                            AcoountTypeEnum acoountType2 = AcoountTypeEnum.Savings;
                            Console.WriteLine("Enter currency type with number (1.USD 2. AZN 3.EUR)");
                            string currencyChoice2 = Console.ReadLine();

                            switch (currencyChoice2)
                            {
                                case "1":
                                    CurrencyTypeEnum currencyType = CurrencyTypeEnum.USD;
                                    bank.CreateAccount(acoountType2, currencyType);
                                    break;

                                case "2":
                                    CurrencyTypeEnum currencyType2 = CurrencyTypeEnum.AZN;
                                    bank.CreateAccount(acoountType2, currencyType2);
                                    break;

                                case "3":
                                    CurrencyTypeEnum currencyType3 = CurrencyTypeEnum.EUR;
                                    bank.CreateAccount(acoountType2, currencyType3);
                                    break;



                                default:
                                    Console.WriteLine("Wrong Input!!!");
                                    break;
                            }

                            break;


                        case "3":
                            AcoountTypeEnum acoountType3 = AcoountTypeEnum.Savings;
                            Console.WriteLine("Enter currency type with number (1.USD 2. AZN 3.EUR)");
                            string currencyChoice3 = Console.ReadLine();

                            switch (currencyChoice3)
                            {
                                case "1":
                                    CurrencyTypeEnum currencyType = CurrencyTypeEnum.USD;
                                    bank.CreateAccount(acoountType3, currencyType);
                                    break;

                                case "2":
                                    CurrencyTypeEnum currencyType2 = CurrencyTypeEnum.AZN;
                                    bank.CreateAccount(acoountType3, currencyType2);
                                    break;

                                case "3":
                                    CurrencyTypeEnum currencyType3 = CurrencyTypeEnum.EUR;
                                    bank.CreateAccount(acoountType3, currencyType3);
                                    break;



                                 default:
                                    Console.WriteLine("Wrong Input!!!");
                                    break;
                            }

                            break;




                        default:
                            Console.WriteLine("Wrong input!!!");
                            break;
                    }


                    break;
                case "2":

                    Console.WriteLine("Enter account id:");
                    int accid;

                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out accid))

                    {
                        try
                        {
                             bank.DepositMoney(accid);
                        }
                        catch (AccountNotFoundException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        catch(InvalidAmountException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                   
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!!!");
   
                    }

                    break;


                    case "3":
                    Console.WriteLine("Enter account id:");
                    int accid2;
                    string userInput2 = Console.ReadLine();

                    if (int.TryParse(userInput2, out accid2))
                    {
                        try
                        {
                            bank.WithdrawMoney(accid2);
                        }
                        catch (InsufficientFundsException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidAmountException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }


                    }
                    else
                    {
                        Console.WriteLine("Wrong input!!!");

                    }

                    break;
                case "4":
                    bank.ListAccounts();
                    break;
                case "5":
                    int fromid, toid;
                    Console.WriteLine("Enter sender acoount id:");

                    string frominput = Console.ReadLine();
                    Console.WriteLine("Enter sender acoount id:");

                    string toinput = Console.ReadLine();

                    if (int.TryParse(frominput, out fromid) && int.TryParse(toinput , out toid) )


                    {
                        try
                        {
                            bank.TransferMoney(fromid , toid);
                        }
                        catch (AccountNotFoundException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong input!!!");

                    }

                    break;

                    case "6":

                    break;
                case "7":
                    bank.ListTransactions();



                    break;

                case "8":
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }


        }


        
    
    } 

        



    }

