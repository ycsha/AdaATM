namespace AdaATM
{
    public class cardHolder
    {
        String cardNumber;
        int pin;
        String firstName;
        String lastName;
        double balance;

        public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }
        public String getNumber()
        {
            return cardNumber;
        }

        public int getPin()
        {
            return pin;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getlastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNum(String newCardNumber)
        {
            cardNumber = newCardNumber;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setFirstName(String newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(String newLastName)
        {
            lastName = newLastName;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(String[] args)
        {
            void printOptions()
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Please choose from one of the following options....");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.Write("Input: ");

            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("\nThank you. Your new balance is: " + currentUser.getBalance());
            }
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to withdraw: ");
                double withdrawal = Double.Parse(Console.ReadLine());
                //check if the user has enough money
                if (currentUser.getBalance() < withdrawal)
                {
                    Console.WriteLine("\nInsufficient balance :(");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("\nThank you! You're good to go :) ");
                }
            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine("\nCurrent balance: " + currentUser.getBalance());
            }

            List<cardHolder> cardHolder = new List<cardHolder>();
            cardHolder.Add(new AdaATM.cardHolder("45623896578432", 123456, "Yssa", "Pasia", 3050.67));
            cardHolder.Add(new AdaATM.cardHolder("45623896589432", 654321, "Elaine", "Ordinario", 600.14));
            cardHolder.Add(new AdaATM.cardHolder("45623896556431", 222333, "Jalsen", "Huertas", 820.42));
            cardHolder.Add(new AdaATM.cardHolder("45623896579453", 111444, "Kathlen", "Bilangel", 1010.38));
            cardHolder.Add(new AdaATM.cardHolder("45623896567321", 678910, "Mharwin", "Moncada", 4023.56));
            cardHolder.Add(new AdaATM.cardHolder("45623896534678", 444444, "Gelo", "Bugayong", 302.74));
            cardHolder.Add(new AdaATM.cardHolder("45623896567894", 784943, "Eliseo", "Cruz", 504.83));
            cardHolder.Add(new AdaATM.cardHolder("45623896556321", 837247, "Andrew", "Cullado", 2702.74));

            // Prompt user
            Console.WriteLine("Welcome to AdaATM");
            Console.WriteLine("\nPlease insert your debit card: ");
            String debitCardNumber = " ";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNumber = Console.ReadLine();
                    // Check against our dp
                    currentUser = cardHolder.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again."); }

                }
                catch { Console.WriteLine("Card not recognized. Please try again."); }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again."); }

                }
                catch { Console.WriteLine("Incorrect pin. Please try again."); }
            }

            Console.WriteLine("\nWelcome " + currentUser.getFirstName() + " :)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("\nThank you! Have a nice day :)");
        }
    }
}