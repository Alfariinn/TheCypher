using System;
using TheCypherLib;

class Program
{
    static void Main()
    {

        string playfairKey = "Żabaskaczewysoko";
        int playfairMessage = 5;
        string playfairEncoded = Caesar.Encode(playfairKey, playfairMessage);
        string playfairDecoded = Caesar.Decode(playfairKey, playfairMessage);

        Console.WriteLine("Original Message: " + playfairMessage);
        Console.WriteLine("Encoded Message : " + playfairEncoded);
        Console.WriteLine("Decoded Message : " + playfairDecoded);


    }
}