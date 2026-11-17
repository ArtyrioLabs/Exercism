using System.Collections.Generic;
using System.Linq;

public static class KillerSudokuHelper
{
    public static IEnumerable<int[]> Combinations(int sum, int size, int[] exclude)
    {
        var result = new List<int[]>();
        FindCombinations(1, size, sum, new List<int>(), exclude.ToHashSet(), result);
        return result;
    }

    private static void FindCombinations(int start, int targetSize, int targetSum, List<int> current, HashSet<int> excludeSet, List<int[]> result)
    {
        if (current.Count == targetSize)
        {
            if (targetSum == 0)
            {
                result.Add(current.ToArray());
            }
            return;
        }

        for (int i = start; i <= 9; i++)
        {
            if (excludeSet.Contains(i) || i > targetSum)
            {
                continue;
            }

            current.Add(i);
            FindCombinations(i + 1, targetSize, targetSum - i, current, excludeSet, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}