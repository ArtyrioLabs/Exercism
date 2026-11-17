using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var normalized = new string(plaintext
            .Where(char.IsLetterOrDigit)
            .Select(char.ToLower)
            .ToArray());

        if (string.IsNullOrEmpty(normalized))
            return string.Empty;

        int len = normalized.Length;

        int c = (int)Math.Ceiling(Math.Sqrt(len));
        int r = (int)Math.Floor(Math.Sqrt(len));

        if (r * c < len)
        {
            if (r < c) r++;
            else c++;
        }

        while (r * c < len)
        {
            if (c <= r) c++;
            else r++;
        }

        var resultSegments = new List<string>();

        for (int col = 0; col < c; col++)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < r; row++)
            {
                int index = row * c + col;
                if (index < len)
                {
                    sb.Append(normalized[index]);
                }
                else
                {
                    sb.Append(' '); 
                }
            }
            resultSegments.Add(sb.ToString());
        }

        return string.Join(" ", resultSegments);
    }
}