using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var sb = new StringBuilder();
        int count = 1;

        for (int i = 0; i < input.Length; i++)
        {
            if (i + 1 < input.Length && input[i] == input[i + 1])
            {
                count++;
            }
            else
            {
                if (count > 1)
                {
                    sb.Append(count);
                }
                sb.Append(input[i]);
                count = 1;
            }
        }

        return sb.ToString();
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var sb = new StringBuilder();
        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsDigit(c))
            {
                count = count * 10 + (c - '0');
            }
            else
            {
                int repeat = (count == 0) ? 1 : count;
                sb.Append(c, repeat);
                count = 0;
            }
        }

        return sb.ToString();
    }
}