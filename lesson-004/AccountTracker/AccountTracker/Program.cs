using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AccountTracker
{
    // Andrew Brudnak
    // Lesson 04
    // CIS262AD - C# Level II - Class # 31838 
    class Program
    {
        static string dataPath;
        static void Main(string[] args)
        {

            // Accounts.txt will be located in bin/Debug file path wherever the program excecutes from
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            dataPath = Path.Combine(path, "Accounts.txt");
            using (StreamReader reader = new StreamReader(dataPath))
            {
                string currentLine = null;
                int lineIndex = 0;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (DataLineIsValid(currentLine))
                    {
                        OutputDataLine(currentLine);
                    }
                    else
                    {
                        Console.WriteLine("Invalid data on line {0}", lineIndex + 1);
                    }
                    lineIndex++;
                }
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("Would you want to add a record? Type \"y\" to continue or enter to exit the program.");
            var response = Console.ReadKey();
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            if (response.KeyChar == 'y')
            {
                var accountDetail = PromptForAccountDetails();
                SaveNewAccount(accountDetail);
                Console.WriteLine("Your data has been saved!");
            }
            Console.ReadLine();
        }

        static void OutputDataLine(string input)
        {
            var rawData = input.Split(',');
            var format = "Acount name: {0}. Invoice Date: {1}. Due Date:{2}. Amount Due: {3}";
            Console.WriteLine(format, rawData[0], rawData[1], rawData[2], rawData[3]);
        }

        static bool DataLineIsValid(string input)
        {
            var rawData = input.Split(',');
            DateTime parsedDate;
            var result = DateTime.TryParse(rawData[1], out parsedDate);
            if (result == false)
            {
                return false;
            }
            result = DateTime.TryParse(rawData[2], out parsedDate);
            if (result == false)
            {
                return false;
            }
            double parsedDouble = 0;
            result = double.TryParse(rawData[3], out parsedDouble);
            if (result == false)
            {
                return false;
            }
            return true;
        }

        static Account PromptForAccountDetails()
        {
            var output = new Account();
            Console.WriteLine("What is the account name?");
            output.AccountName = Console.ReadLine();
            Console.WriteLine(string.Empty);
            DateTime parsedDate = DateTime.MinValue;
            double parsedAmount = 0;
            bool parseResult = false;
            string userInput;
            while (!parseResult)
            {
                Console.WriteLine("What is the invoice date?");
                userInput = Console.ReadLine();
                Console.WriteLine(string.Empty);
                parseResult = DateTime.TryParse(userInput, out parsedDate);
            }

            output.InvoiceDate = parsedDate;
            parseResult = false;
            while (!parseResult)
            {
                Console.WriteLine("What is the due date?");
                userInput = Console.ReadLine();
                Console.WriteLine(string.Empty);
                parseResult = DateTime.TryParse(userInput, out parsedDate);
            }
            output.DueDate = parsedDate;
            parseResult = false;
            while (!parseResult)
            {
                Console.WriteLine("What is the invoice amount?");
                userInput = Console.ReadLine();
                parseResult = double.TryParse(userInput, out parsedAmount);
            }
            output.AmountDue = parsedAmount;
            return output;
        }
        static void SaveNewAccount(Account account)
        {
            var formatString = "{0},{1},{2},{3}";
            var formatedData = string.Format(formatString, account.AccountName, account.InvoiceDate, account.DueDate, account.AmountDue);
            using (var writer = new StreamWriter(dataPath, true))
            {
        
                writer.WriteLine(formatedData);
            }
        }
    }
}