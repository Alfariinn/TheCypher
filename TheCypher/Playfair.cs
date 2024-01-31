using System;
using System.Text;

namespace TheCypherLib
{
    public static class Playfair
    {
        //Na koniec alfabetu dodano . aby dało utworzyć się z niego kwadrat 6x6
        private static string alphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ.";

        public static string Encode(string message, string key)
        {
            //Generujemy kwadrat Playfaira według klucza
            char[,] square = GeneratePlayfairSquare(key);

            //Usuwamy spacje i zamieniamy na duże
            message = message.Replace(" ", "").ToUpper();
            StringBuilder encodedMessage = new StringBuilder();

            //Szyfrujemy całą wiadomość według zasad Playfaira
            for (int i = 0; i < message.Length; i += 2)
                char firstChar = message[i];
                //Dopisujemy X jako drugi znak jeśli ilość znaków w wiadomości jest nieparzysta
                char secondChar = (i + 1 < message.Length) ? message[i + 1] : 'X';

                int[] firstCoordinates = FindCoordinates(square, firstChar);
                int[] secondCoordinates = FindCoordinates(square, secondChar);

                // Litery w tym samym wierszu
                if (firstCoordinates[0] == secondCoordinates[0])
                {
                    encodedMessage.Append($"{square[firstCoordinates[0], (firstCoordinates[1] + 1) % 6]}{square[secondCoordinates[0], (secondCoordinates[1] + 1) % 6]} ");
                }
                // Litery w tej samej kolumnie
                else if (firstCoordinates[1] == secondCoordinates[1])
                {
                    encodedMessage.Append($"{square[(firstCoordinates[0] + 1) % 6, firstCoordinates[1]]}{square[(secondCoordinates[0] + 1) % 6, secondCoordinates[1]]} ");
                }
                // Litery w różnych wierszach i kolumnach
                else
                {
                    encodedMessage.Append($"{square[firstCoordinates[0], secondCoordinates[1]]}{square[secondCoordinates[0], firstCoordinates[1]]} ");
                }
            }
            //Ucinamy ostatnią spację z poprzedniego kroku
            return encodedMessage.ToString().Trim();
        }

        public static string Decode(string message, string key)
        {
            //Generujemy kwadrat playfaira według klucza
            char[,] square = GeneratePlayfairSquare(key);

            //Usuwamy spacje i zamieniamy na duże
            message = message.Replace(" ", "").ToUpper();
            StringBuilder decodedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i += 2)
            {
                char firstChar = message[i];
                //Dopisujemy X jako drugi znak jeśli ilość znaków w wiadomości jest nieparzysta
                char secondChar = (i + 1 < message.Length) ? message[i + 1] : 'X';

                int[] firstCoordinates = FindCoordinates(square, firstChar);
                int[] secondCoordinates = FindCoordinates(square, secondChar);

                // Litery w tym samym wierszu
                if (firstCoordinates[0] == secondCoordinates[0])
                {
                    decodedMessage.Append($"{square[firstCoordinates[0], (firstCoordinates[1] + 5) % 6]}{square[secondCoordinates[0], (secondCoordinates[1] + 5) % 6]} ");
                }
                // Litery w tej samej kolumnie
                else if (firstCoordinates[1] == secondCoordinates[1])
                {
                    decodedMessage.Append($"{square[(firstCoordinates[0] + 5) % 6, firstCoordinates[1]]}{square[(secondCoordinates[0] + 5) % 6, secondCoordinates[1]]} ");
                }
                // Litery w różnych wierszach i kolumnach
                else
                {
                    decodedMessage.Append($"{square[firstCoordinates[0], secondCoordinates[1]]}{square[secondCoordinates[0], firstCoordinates[1]]} ");
                }
            }
            //Ucinamy ostatnią spację z poprzedniego kroku
            return decodedMessage.ToString().Replace(" ", "");
        }

        //Tworzy kwadrat playfaira
        private static char[,] GeneratePlayfairSquare(string key)
        {
            //Usuwamy duplikaty z klucza i zamieniamy na uppercase
            string uniqueKey = RemoveDuplicateCharacters(key.Replace(" ", "")).ToUpper();
            //Wszystkie znaki z alfabetu bez klucza
            string remainingAlphabet = new string(alphabet.Except(uniqueKey).ToArray());

            char[,] square = new char[6, 6];
            int keyIndex = 0;
            int alphabetIndex = 0;

            //Dopisujemy do kwadratu najpierw klucz, potem resztę alfabetu
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (keyIndex < uniqueKey.Length)
                    {
                        square[i, j] = uniqueKey[keyIndex];
                        keyIndex++;
                    }
                    else
                    {
                        square[i, j] = remainingAlphabet[alphabetIndex];
                        alphabetIndex++;
                    }
                }
            }

            return square;
        }

        //Usuwa powtórzenia znaku z stringa
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

        //Zwraca array zawierający koordynaty znaku w tablicy
        private static int[] FindCoordinates(char[,] square, char target)
        {
            int[] coordinates = new int[2];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (square[i, j] == target)
                    {
                        coordinates[0] = i;
                        coordinates[1] = j;
                        return coordinates;
                    }
                }
            }
            //Do debugowania
            throw new Exception($"Character '{target}' not found in Playfair square.");
        }
    }
}
