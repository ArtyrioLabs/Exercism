using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;
    private readonly string _normalizedBaseWord;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
        _normalizedBaseWord = SortString(baseWord.ToLower());
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var result = new List<string>();

        foreach (var candidate in potentialMatches)
        {
            if (candidate.Equals(_baseWord, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (SortString(candidate.ToLower()) == _normalizedBaseWord)
            {
                result.Add(candidate);
            }
        }

        return result.ToArray();
    }

    private static string SortString(string input)
    {
        var chars = input.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }
}