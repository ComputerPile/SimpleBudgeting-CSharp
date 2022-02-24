using System;

namespace SimpleBudgeting
{
    class Program
    {
        static void Main(string[] args)
        {
            // My Library Class
            Library myLib = new Library();
            
            // Verision
            Console.WriteLine("Simple Budgeting Console Edition v1.0.0\n");
            //Console.WriteLine("Hint: Type \"exit\" to end this program.");

            // Variable for total amount
            float total = 0;

            // Array of bills feel free to edit with your own bills
            string[] bills =
            {
                "your monthly salary",
                "car payment",
                "car insurance",
                "electric bill",
                "water bill",
                "internet"
            };

            // More bills can be added by user later

            foreach (string bill in bills)
            {
                if (bill == "your monthly salary")
                {
                    total = myLib.AskInfo(bill);

                    Console.WriteLine("Total amount starting: $ {0}", total.ToString("0.00"));
                }
                else
                {
                    float paymentAmount = myLib.AskInfo(bill);

                    total -= paymentAmount;

                    Console.WriteLine("\nTotal remaining: $ {0}", total);
                }
            }

            // Just to add some space
            Console.WriteLine("------------------------------");

            bool addError = false;
            //bool addBills;

            do
            {
                Console.Write("Would you like to deduct more bills or payments? (Y/n): ");
                string addBillsInput = Console.ReadLine().ToUpper();

                if (addBillsInput == "Y")
                {
                    addError = false;
                }
                else if (addBillsInput == "N")
                {
                    Environment.Exit(0); // exit program
                }
                else
                {
                    addError = myLib.ThrowError("Please enter Y or N.");
                }
            } while (addError);

            Console.WriteLine("So... you've made it this far...");

            // For adding more bills and deducting from your total amount
            bool addMoreBills = true;

            do
            {
                float payment = 0; // Value to deduct from total

                // Get Name of bill
                Console.Write("\nEnter a bill name: ");
                string billName = Console.ReadLine();

                // Add bool for checking for error and loop
                bool error = false;

                Console.Write("Enter {0} amount: ", billName);

                do
                {
                    try
                    {
                        payment = float.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        error = myLib.ThrowError("\nPlease enter a number!");

                        Console.Write("Amount: ");
                    }
                } while (error);

                // Subtract from total
                total -= payment;

                Console.WriteLine("\nTotal remaining: $ {0}", total);

                // Ask user if they want to add more
                bool addMoreError = false;

                do
                {
                    Console.Write("\nWould you like to add more? (Y/n)");
                    string addMoreInput = Console.ReadLine().ToUpper();

                    switch(addMoreInput)
                    {
                        case "Y":
                            addMoreBills = true;
                            addMoreError = false;
                            break;
                        case "N":
                            addMoreBills = false;
                            addMoreError = false;
                            break;
                        default:
                            addMoreError = myLib.ThrowError("\nPlease enter Y or N.");
                            break;
                    }
                } while (addMoreError);

            } while (addMoreBills);
        }
    }
}
/* David says Documentation is key! */