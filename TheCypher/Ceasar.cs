using System.Text;

namespace TheCypher
{
    public static class Caesar
    {
        private static string alphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        public static string Encode(string message, int key = 0)
        {
            StringBuilder encodedMessage = new StringBuilder();

            int boundedKey = key % alphabet.Length;

            for (int i = 0; i < message.Length; i++)
            {
                char currentChar = message[i];

                if (char.IsLetter(currentChar))
                {
                    int messageIndex = alphabet.IndexOf(char.ToUpper(currentChar));

                    int newIndex = (messageIndex + boundedKey + alphabet.Length) % alphabet.Length;

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

        public static string Decode(string encodedMessage, int key = 0)
        {
            return Encode(encodedMessage, -key);
        }

    }
}
