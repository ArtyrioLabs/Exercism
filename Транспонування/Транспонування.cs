using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        string[] rows = input.Split('\n');
        int rowCount = rows.Length;
        int maxColCount = rows.Max(r => r.Length);

        var resultRows = new List<string>();

        for (int c = 0; c < maxColCount; c++)
        {
            var sb = new StringBuilder();
            int currentLength = 0;

            for (int r = 0; r < rowCount; r++)
            {
                if (c < rows[r].Length)
                {
                    if (currentLength > 0)
                    {
                        sb.Append(new string(' ', currentLength));
                        currentLength = 0;
                    }
                    sb.Append(rows[r][c]);
                }
                else
                {
                    currentLength++;
                }
            }

            resultRows.Add(sb.ToString());
        }

        return string.Join("\n", resultRows);
    }
}