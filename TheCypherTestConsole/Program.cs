using System;
using TheCypherLib;

class Program
{
    static void Main()
    {

        string playfairKey = "Żabaskaczewysoko";
        string playfairMessage = "Nad stawem w dżungli";
        string playfairEncoded = TheCypherLib.Playfair.Encode(playfairMessage, playfairKey);
        string playfairDecoded = TheCypherLib.Playfair.Decode(playfairEncoded, playfairKey);

        Console.WriteLine("Playfair Cipher:");
        Console.WriteLine("Original Message: " + playfairMessage);
        Console.WriteLine("Encoded Message : " + playfairEncoded);
        Console.WriteLine("Decoded Message : " + playfairDecoded);


    }
}