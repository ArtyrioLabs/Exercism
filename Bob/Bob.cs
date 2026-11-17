using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        string trimmed = statement.Trim();

        if (string.IsNullOrEmpty(trimmed))
        {
            return "Fine. Be that way!";
        }

        bool isQuestion = trimmed.EndsWith('?');
        bool hasLetters = trimmed.Any(char.IsLetter);
        bool isYelling = hasLetters && trimmed.All(c => !char.IsLetter(c) || char.IsUpper(c));

        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        if (isYelling)
        {
            return "Whoa, chill out!";
        }
        if (isQuestion)
        {
            return "Sure.";
        }

        return "Whatever.";
    }
}