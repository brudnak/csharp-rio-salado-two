using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;
// Lesson 3
// Andrew Brudnak
namespace QRCodeLibrary
{
    public class AddressQRCode
    {
        public static void addressToQRCode (string address, string street, string houseNumber)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData qrCodeData = generator.CreateQrCode(address, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            /* Adding the house number and street name to the QR codes
             * created is an easy fix to a problem. If the file name remains 
             * something static that isn't unique to each QR code when another one
             * is generated it will be overwritten. 
             */
            qrCodeImage.Save($"{houseNumber}_{street}_QRCode.bmp");
        }
    }
}
