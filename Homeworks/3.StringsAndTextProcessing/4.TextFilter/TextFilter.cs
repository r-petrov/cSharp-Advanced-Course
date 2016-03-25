using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TextFilter
{
    static string ReplaceBannedWords(string bannedWord, string replacingWord, string text)
    {
        string filteredText = text.Replace(bannedWord, replacingWord);
        return filteredText;
    }

    static string CreateAstariksWords(string bannedWord)
    {
        string asteriks = String.Empty;
        for (int i = 0; i < bannedWord.Length; i++)
        {
            asteriks += "*";
        }
        return asteriks;
    }

    static void Main(string[] args)
    {
        string bannedString = Console.ReadLine();
        string text = Console.ReadLine();
        string filteredText = String.Empty;

        char[] separators = new char[]{',', ' '};
        string[] bannedWords = bannedString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < bannedWords.Length; i++)
        {
            string asterisk = CreateAstariksWords(bannedWords[i]);
            text = ReplaceBannedWords(bannedWords[i], asterisk, text);
        }

        Console.ReadLine();
        Console.WriteLine(text);
    }
}
