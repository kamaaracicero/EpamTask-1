using System.Collections.Generic;
using System.Text;

namespace Client_Server
{
    public static class Translit
    {
        /// <summary>
        /// User messages library
        /// </summary>
        public static List<UserData> Library = new List<UserData>();

        /// <summary>
        /// Translit symbols 
        /// </summary>
        private static readonly Dictionary<char, string> symbols = new Dictionary<char, string>()
        {
            { 'а', "a" }, { 'б', "b" }, { 'в', "v" },
            { 'г', "g" }, { 'д', "d" }, { 'е', "e" },
            { 'ё', "e`" }, { 'ж', "g`" }, { 'з', "z" },
            { 'и', "i" }, { 'й', "i`" }, { 'к', "k" },
            { 'л', "l" }, { 'м', "m" }, { 'н', "n" },
            { 'о', "o" }, { 'п', "p" }, { 'р', "r" },
            { 'с', "s" }, { 'т', "t" }, { 'у', "y" },
            { 'ф', "f" }, { 'х', "h" }, { 'ц', "c" },
            { 'ч', "ch" }, { 'ш', "sh" }, { 'щ', "sh`" },
            { 'ъ', "`" }, { 'ы', "`" }, { 'ь', "`" },
            { 'э', "ie" }, { 'ю', "iy" }, { 'я', "ia" },
            { 'А', "A" }, { 'Б', "B" }, { 'В', "V" },
            { 'Г', "G" }, { 'Д', "D" }, { 'Е', "E" },
            { 'Ё', "E`" }, { 'Ж', "G`" }, { 'З', "Z" },
            { 'И', "I" }, { 'Й', "I`" }, { 'К', "K" },
            { 'Л', "L" }, { 'М', "M" }, { 'Н', "N" },
            { 'О', "O" }, { 'П', "P" }, { 'Р', "R" },
            { 'С', "S" }, { 'Т', "T" }, { 'У', "Y" },
            { 'Ф', "F" }, { 'Х', "H" }, { 'Ц', "C" },
            { 'Ч', "Ch" }, { 'Ш', "Sh" }, { 'Щ', "Sh`" },
            { 'Ъ', "`" }, { 'Ы', "`" }, { 'Ь', "`" },
            { 'Э', "Ie" }, { 'Ю', "Iy" }, { 'Я', "Ia" }
        };

        /// <summary>
        /// String process delegate
        /// </summary>
        /// <param name="string1">First string</param>
        /// <param name="string2">Second string</param>
        private delegate void StringProcess(string string1, string string2); 

        /// <summary>
        /// Translit message
        /// </summary>
        /// <param name="string">Message</param>
        /// <param name="id">User id</param>
        public static void TranslitString(string @string, string id)
        {
            StringProcess process = delegate
            {
                StringBuilder newString = new StringBuilder();
                foreach (char symbol in @string)
                {
                    try { newString.Append(symbols[symbol]); }
                    catch { newString.Append(symbol); }
                }
                Library.Add(new UserData(id, newString.ToString()));
                if (Library.Count % 10 == 0)
                    DataSaver.SaveListInJson(Library);
            };

            process(@string, id);
        }
    }
}
