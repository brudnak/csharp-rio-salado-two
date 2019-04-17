using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCodeLibrary;
using static System.Console;
// Lesson 03
// Andrew Brudnak
// CIS262AD - C# Level II - Class # 31838 
namespace QRCodeConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string houseNumber;
            string streetName;
            string streetType;
            string city;
            string state;
            string zipCode;
            string welcomeInstruction = "************************** LENNAR CONSTRUCTION COMPANY QR CODE GENERATOR **************************\n" +
                "\n" +
                "This simple QR Code Generator will help us track shipments that originate from our suppliers.\n" +
                "To ensure materials have been sent to the correct address, employees will be able to scan these QR\n" +
                "codes with their smart phone and see if the shipment has arrived at the correct location";
            WriteLine(welcomeInstruction);
            WriteLine(string.Empty);
            WriteLine("Please enter the house number...");
            houseNumber = ReadLine();
            WriteLine(string.Empty);
            WriteLine("Please enter the street name...");
            streetName = ReadLine();
            WriteLine(string.Empty);
            WriteLine("Please enter the street type...");
            streetType = ReadLine();
            WriteLine(string.Empty);
            WriteLine("Please enter the city...");
            city = ReadLine();
            WriteLine(string.Empty);
            WriteLine("Please enter the state...");
            state = ReadLine();
            WriteLine(string.Empty);
            WriteLine("Please enter the ZIP code...");
            zipCode = ReadLine();
            WriteLine(string.Empty);
            string supplierShipment = houseNumber + " " + streetName +" " + streetType + "\n" + city + ", " + state + " " + zipCode;
            
            AddressQRCode.addressToQRCode(supplierShipment.ToUpper(), streetName.ToUpper(), houseNumber.ToUpper());
            WriteLine(string.Empty);
            WriteLine("Your QR has been generated! And will appear as the following when scanned: ");
            WriteLine("**********************************");
            WriteLine(supplierShipment.ToUpper());
            WriteLine("**********************************");
            WriteLine("Your QR Code file will be located at: \n" +
                "\"\\SupplierShipmentTracking\\QRCodeConsoleUI\\bin\\Debug\"\n" +
                "with the part of the file path not shown at the beggining being\n" +
                "dependent where you're executing the program from\n" +
                "Your file name will be \"house number_street name_QRCode.bmp\"");
            ReadLine();
        }
    }
}