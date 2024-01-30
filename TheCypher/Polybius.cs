using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCypher
{
    using System;
    using System.Linq;
    using System.Text;

    public static class Polybius
    {
        private static string alphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
        private static int rows = 7;
        private static int cols = 5;

        public static string Encode(string message, string key)
        {
            char[,] square = GeneratePolybiusSquare(key);

            message = message.Replace(" ", "");

            StringBuilder encodedMessage = new StringBuilder();

            foreach (char character in message)
            {
                if (char.IsLetter(character))
                {
                    int[] coordinates = FindCoordinates(square, char.ToUpper(character));
                    encodedMessage.Append($"{coordinates[0]}{coordinates[1]} ");
                }
            }

            return encodedMessage.ToString().Trim();
        }

        public static string Decode(string message, string key)
        {
            char[,] square = GeneratePolybiusSquare(key);

            message = message.Replace(" ", "");

            StringBuilder decodedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i += 2)
            {
                string pair = message.Substring(i, 2);

                if (pair.Length == 2)
                {
                    int row = int.Parse(pair[0].ToString());
                    int col = int.Parse(pair[1].ToString());

                    if (row <= square.GetLength(0) && col <= square.GetLength(1))
                    {
                        char decryptedChar = square[row, col];
                        decodedMessage.Append(decryptedChar);
                    }
                    else
                    {
                        decodedMessage.Append("?");
                    }
                }
                else
                {
                    throw new Exception("failed to decode");
                }
            }

            return decodedMessage.ToString();
        }

        private static char[,] GeneratePolybiusSquare(string key)
        {
            string uniqueKey = RemoveDuplicateCharacters(key.Replace(" ", "").ToUpper());
            string remainingAlphabet = new string(alphabet.Except(uniqueKey).ToArray());

            char[,] shuffledAlphabet = new char[rows, cols];

            int index = 0;

            foreach (char letter in uniqueKey)
            {
                shuffledAlphabet[index / cols, index % cols] = letter;
                index++;
            }

            foreach (char letter in remainingAlphabet)
            {
                shuffledAlphabet[index / cols, index % cols] = letter;
                index++;
            }

            return shuffledAlphabet;
        }



        private static string RemoveDuplicateCharacters(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char character in input)
            {
                if (result.ToString().IndexOf(character) == -1)
                {
                    result.Append(character);
                }
            }
            return result.ToString();
        }

        private static int[] FindCoordinates(char[,] square, char target)
        {
            int[] coordinates = new int[2];

            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    if (square[i, j] == target)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;
                    }
                }
            }

            throw new Exception($"Character '{target}' not found in Polybius square.");
        }

    }
}
