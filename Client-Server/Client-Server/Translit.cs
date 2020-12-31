using System.Collections.Generic;
using System.Text;

namespace Client_Server
{
    public static class Translit
    {
        public static List<UserData> Library = new List<UserData>();

        private static readonly Dictionary<char, string> symbols = new Dictionary<char, string>()
        {
            { 'а', "a" }, { 'б', "b" }, { 'в', "v" },
            { 'г', "g" }, { 'д', "d" }, { 'е', "e" },
            { 'ё', "e`" }, { 'ж', "g`" }, { 'з', "z" },
            { 'и', "i`" }, { 'й', "i" }, { 'к', "k" },
            { 'л', "l" }, { 'м', "m" }, { 'н', "n" },
            { 'о', "o" }, { 'п', "p" }, { 'р', "r" },
            { 'с', "s" }, { 'т', "t" }, { 'у', "y" },
            { 'ф', "f" }, { 'х', "h" }, { 'ц', "c" },
            { 'ч', "ch" }, { 'ш', "sh" }, { 'щ', "sh`" },
            { 'ъ', "`" }, { 'ы', "`" }, { 'ь', "`" },
            { 'э', "ie" }, { 'ю', "iy" }, { 'я', "ia" }
        };

        public static void TranslitString(string @string, string id)
        {
            StringBuilder newString = new StringBuilder();
            foreach(char symbol in @string)
            {
                try { newString.Append(symbols[symbol]); }
                catch { newString.Append(symbol); }
            }
            Library.Add(new UserData(id, newString.ToString()));
            if (Library.Count % 10 == 0)
                DataSaver.SaveListInJson(Library);
        }
    }
}
