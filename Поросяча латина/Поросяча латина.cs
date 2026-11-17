using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class PigLatin
{
    public static string Translate(string word)
    {
        if (word.Contains(' '))
        {
            return string.Join(" ", word.Split(' ').Select(Translate));
        }

        if (Regex.IsMatch(word, @"^([aeiou]|xr|yt)"))
        {
            return word + "ay";
        }

        Match quMatch = Regex.Match(word, @"^([^aeiou]*?qu)(.*)$");
        if (quMatch.Success)
        {
            return quMatch.Groups[2].Value + quMatch.Groups[1].Value + "ay";
        }

        Match yMatch = Regex.Match(word, @"^([^aeiou]+)(y.*)$");
        if (yMatch.Success && !yMatch.Groups[1].Value.Contains('y'))
        {
            return yMatch.Groups[2].Value + yMatch.Groups[1].Value + "ay";
        }

        Match consonantMatch = Regex.Match(word, @"^([^aeiou]+)(.*)$");
        if (consonantMatch.Success)
        {
            return consonantMatch.Groups[2].Value + consonantMatch.Groups[1].Value + "ay";
        }

        return word + "ay";
    }
}