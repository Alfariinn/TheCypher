using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCypher
{
    public static class Vigenere
    {
        private static string alphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        private static string ExtendKey(string key, int length)
        {
            StringBuilder extendedKey = new StringBuilder();

            int keyLength = key.Length;

            for (int i = 0; i < length; i++)
            {
                extendedKey.Append(key[i % keyLength]);
            }

            return extendedKey.ToString();
        }

        public static string Encode(string message, string key)
        {
            StringBuilder encodedMessage = new StringBuilder();

            string extendedKey = ExtendKey(key, message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                char currentChar = message[i];

                if (char.IsLetter(currentChar))
                {
                    int messageIndex = alphabet.IndexOf(char.ToUpper(currentChar));
                    int keyIndex = alphabet.IndexOf(char.ToUpper(extendedKey[i]));

                    int newIndex = (messageIndex + keyIndex) % alphabet.Length;

                    char newChar = char.IsUpper(currentChar) ? alphabet[newIndex] : char.ToLower(alphabet[newIndex]);
                    encodedMessage.Append(newChar);
                }
                else
                {
                    encodedMessage.Append(currentChar);
                }
            }

            return encodedMessage.ToString();
        }

        public static string Decode(string message, string key)
        {
            StringBuilder decodedMessage = new StringBuilder();

            string extendedKey = ExtendKey(key, message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                char currentChar = message[i];

                if (char.IsLetter(currentChar))
                {
                    int messageIndex = alphabet.IndexOf(char.ToUpper(currentChar));
                    int keyIndex = alphabet.IndexOf(char.ToUpper(extendedKey[i]));

                    int newIndex = (messageIndex - keyIndex + alphabet.Length) % alphabet.Length;

                    char newChar = char.IsUpper(currentChar) ? alphabet[newIndex] : char.ToLower(alphabet[newIndex]);
                    decodedMessage.Append(newChar);
                }
                else
                {
                    decodedMessage.Append(currentChar);
                }
            }

            return decodedMessage.ToString();
        }

    }
}
