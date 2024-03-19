using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class cardHolder
    {

        string firstName;
        string lastName;
        string cardNumber; 
        int pin;
        double balance;


        public cardHolder(string cardNumberr, string firstNamee, string lastNamee, int pinn, double balancee)
        {
            this.cardNumber = cardNumberr;
            this.firstName = firstNamee;
            this.lastName = lastNamee;
            this.pin = pinn;
            this.balance = balancee;
        } 

        public String getNum()
        {
            return cardNumber;
        }

        public int getPin()
        {
            return pin; 
        }

        public String getName()
        {
            return firstName + lastName;
        }
        
        public double getBal()
        {
            return balance; 
        }

        public void setNum(String newCardNum)
        {
            cardNumber = newCardNum; 
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setName(String newfirstName, String newlastName)
        {
            firstName = newfirstName;
            lastName = newlastName;
        }

        public void setBal(double newBal)
        {
            balance = newBal; 
        }


        public static void Main(String[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1.Deposite");
                Console.WriteLine("2.Withdraw");
                Console.WriteLine("3.CheckBalance");
                Console.WriteLine("4. Exit");
            }
            void deposite(cardHolder currentUsers)
            {

                Console.WriteLine("How much $$ would you like to deposit?");
                try
                {
                    double depositAmount = Double.Parse(Console.ReadLine());
                    currentUsers.setBal(depositAmount + currentUsers.balance);
                    Console.WriteLine("Thank you for your deposite. Your current balance is : " + currentUsers.getBal());
                }
                catch { Console.WriteLine("Invalid Input"); }


            }

            void withdraw(cardHolder currentUsers)
            {
                Console.Write("How much $$ would you like to withdraw:");
                double withdrawAmount = Double.Parse(Console.ReadLine());
                // check the user if they have enough money to withdraw

                if (withdrawAmount > currentUsers.getBal())
                {
                    Console.WriteLine("Sorry! You dont have enough fund to withdraw");
                }

                else
                {

                    currentUsers.setBal(currentUsers.getBal() - withdrawAmount);
                    Console.WriteLine("Thank you for your withdraw. Your current balance is: " + currentUsers.getBal());
                }

            }

            void balance(cardHolder currentusers)
            {
                Console.WriteLine("Your currenr balance is : " + currentusers.getBal());
            }

            List<cardHolder> cardholderss = new List<cardHolder>();
            cardholderss.Add(new cardHolder("122232324", "Smith", "Samon", 123, 700.30));
            cardholderss.Add(new cardHolder("00008888888", "Cassie", "Abdy", 654, 330));

            //Prompt User

            Console.WriteLine("Welcome to AMT");
            Console.WriteLine("Please inser your bank card: ");
            String bankCard = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    bankCard = Console.ReadLine();
                    currentUser = cardholderss.FirstOrDefault(a => a.cardNumber == bankCard);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Not a valid card number, Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }

            Console.WriteLine("Please put your PIN: ");
            int yourPin = 0;

            while (true)
            {
                try
                {
                    yourPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == yourPin)
                    {
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Incorrect pin, Please try again");
                    }


                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }

            Console.WriteLine("Welcome " + currentUser.getName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { Console.WriteLine("Error"); }
                if (option == 1)
                {
                    deposite(currentUser);

                }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thank you! Have you nice day");
            Console.ReadLine();

        }



        }
    }

