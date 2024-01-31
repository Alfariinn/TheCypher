using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCypherLib
{
    public static class Homophonic
    {
        private static Dictionary<char, List<string>> alphabet = new Dictionary<char, List<string>>
        {
            {'A', new List<string> {"r{", "M(", "g*"}},
            {'Ą', new List<string> {"=u", "t*", "x="}},
            {'B', new List<string> {"/0", "o-", "H3"}},
            {'C', new List<string> {"-w", "q=", "&o"}},
            {'Ć', new List<string> {"L%", "9}", "D1"}},
            {'D', new List<string> {"6+", "p%", "`c"}},
            {'E', new List<string> {">h", "A|", "7g"}},
            {'Ę', new List<string> {"4d", "Z*", "1["}},
            {'F', new List<string> {"@6", "s}", "L!"}},
            {'G', new List<string> {"c9", "J~", "k^"}},
            {'H', new List<string> {"`m", "1a", "I%"}},
            {'I', new List<string> {"0j", ")s", "*Z"}},
            {'J', new List<string> {"c$", "u3", ".8"}},
            {'K', new List<string> {"N_", "3c", "$4"}},
            {'L', new List<string> {"w@", "z}", "B+"}},
            {'Ł', new List<string> {"B8", "{y", "N)"}},
            {'M', new List<string> {")x", "F%", "y&"}},
            {'N', new List<string> {"%3", "Q9", "8h"}},
            {'Ń', new List<string> {"d0", "*q", "6F"}},
            {'O', new List<string> {"!1", "!p", "3="}},
            {'Ó', new List<string> {"5-", "5=", "4+"}},
            {'P', new List<string> {"[w", "k#", "z8"}},
            {'R', new List<string> {"b2", "H|", "y*"}},
            {'S', new List<string> {">6", "8[", "V$"}},
            {'Ś', new List<string> {"6}", "%n", "h0"}},
            {'T', new List<string> {"e!", "z2", "{Q"}},
            {'U', new List<string> {"2b", "8}", "[t"}},
            {'V', new List<string> {"(y", "M)", "&7"}},
            {'W', new List<string> {"/j", "L1", ">J"}},
            {'X', new List<string> {"2)", "1y", "p!"}},
            {'Y', new List<string> {"u8", "A5", "N("}},
            {'Z', new List<string> {"(r", "j@", "l4"}},
            {'Ź', new List<string> {"-t", "z7", "jd"}},
            {'Ż', new List<string> {"5{", "~n", "+u"}}
        };


        public static string Encode(string message)
        {
            StringBuilder encodedText = new StringBuilder();

            //Zmieniamy wielkość liter żeby pasowały do klucza
            message = message.ToUpper();

            for (int i = 0; i < message.Length; i++)
            {
                char letter = message[i];
                //Iterując po każdym znaku zamieniamy go na losowy string z dictionary
                if (alphabet.ContainsKey(letter))
                {
                    List<string> encodings = alphabet[letter];
                    encodedText.Append($"{encodings[new Random().Next(encodings.Count)]} ");
                }
            }
            //Zwracamy odszyfrowaną wiadomość i ucinamy ostatnią spację z poprzedniego kroku
            return encodedText.ToString().Trim();
        }

        public static string Decode(string message)
        {
            StringBuilder decodedText = new StringBuilder();

            //Dzielimy wiadomość na array stringów po spacjach w tekście
            string[] encodedParts = message.Split(' ');

            foreach (string part in encodedParts)
            {
                foreach (var kvp in alphabet)
                {
                    char originalLetter = kvp.Key;
                    List<string> encodings = kvp.Value;

                    //Jeżeli lista stringów zawiera nasz string
                    //to dopisujemy odpowiadający mu klucz do odszyfrowanej wiadomości
                    if (encodings.Contains(part))
                    {
                        decodedText.Append(originalLetter);
                        break;
                    }
                }
            }

            return decodedText.ToString();
        }
    }
}
