using System;
using TheCypher;

class Program
{
    static void Main()
    {

            string key = "klucz";
            string message = "TESTOWAnie!!! polibiusza";

            Console.WriteLine("Original Message: " + message);

            string encodedMessage = Polybius.Encode(message, key);
            Console.WriteLine("Encoded Message: " + encodedMessage);

            string decodedMessage = Polybius.Decode(encodedMessage, key);
            Console.WriteLine("Decoded Message: " + decodedMessage);


    }
}