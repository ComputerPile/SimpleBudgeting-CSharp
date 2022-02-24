using System;
using System.Threading;

public class Library
{
    // Prompt question
    // This function prompts the user to enter a string value
    // then AskInfo will check to make sure the string value
    // can be converted to a float value
    public float AskInfo(string prompt)
    {
        bool isNumber = true; // Check if input is a number
        float paymentAmount = 0;


        Console.Write("\nEnter {0} amount: ", prompt);

        do
        {
            string input = Console.ReadLine();

            try
            {
                paymentAmount = float.Parse(input);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number!");
                Console.ResetColor();

                // Sleep for 2 seconds for dramatic effect
                Thread.Sleep(2000);

                Console.Write("Amount: ");

                isNumber = false;
            }
        } while (!isNumber);

        return paymentAmount;
    }

    // Prompt question, but with new bills
    // must input question as string
    public float AddBill(float total, string bill)
    {
        bool isNumber = true; // check if input is a number as before
        float paymentAmount = 0;

        Console.Write("\nEnter {0} amount: ", bill);

        do
        {
            string input = Console.ReadLine();

            try
            {
                paymentAmount = float.Parse(input);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number!");
                Console.ResetColor();

                // Sleep for 2 seconds for dramatic effect
                Thread.Sleep(2000);

                Console.Write("Amount: ");

                isNumber = false;
            }
        } while (!isNumber);

        //float remainderAmount = total - paymentAmount;

        return total - paymentAmount;
    }

    // This throws a message to the user when they
    // input an invalid message.
    // Also it sleeps for 2 seconds and returns false boolean.
    public bool ThrowError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();

        // Sleep for 2 seconds for dramatic effect
        Thread.Sleep(2000);

        // Return true for error thrown
        return true;  
    }
}