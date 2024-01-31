using System.Text;

namespace TheCypherLib
{
    public static class Caesar
    {
        private static string alphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        public static string Encode(string message, int key)
        {
            StringBuilder encodedMessage = new StringBuilder();

            // Upewniam się że długość klucza będzie w zakresie 1-34
            int boundedKey = key % alphabet.Length; 

            // Iteruję kolejno po każdym znaku w wiadomości  i zamienia go na znak z innej pozcyji
            for (int i = 0; i < message.Length; i++)
            {
                char currentChar = message[i];

                // Zmienia tylko litery, ignorując pozostałe znaki
                if (char.IsLetter(currentChar))
                {
                    int messageIndex = alphabet.IndexOf(char.ToUpper(currentChar));

                    // Dodajemy alphabet.Length do przesunięcia aby można było używać wartości ujemnych
                    // przy dekodowaniu.
                    int newIndex = (messageIndex + boundedKey + alphabet.Length) % alphabet.Length;
                    
                    // Dołączamy zmieniony znak do naszego stringa
                    encodedMessage.Append(currentChar);
                }
                else // Jeżeli znak nie jest literą dołączamy go niezmniejąc
                {
                    encodedMessage.Append(currentChar);
                }
            }

            return encodedMessage.ToString();
        }

        public static string Decode(string encodedMessage, int key)
        {
            return Encode(encodedMessage, -key); // Odwracamy metodę Encode używając ujemnej wartości
        }

    }
}
