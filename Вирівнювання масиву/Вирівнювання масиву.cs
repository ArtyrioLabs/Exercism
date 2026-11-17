using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item == null)
            {
                continue;
            }

            if (item is IEnumerable nestedList && item is not string)
            {
                foreach (var subItem in Flatten(nestedList))
                {
                    yield return subItem;
                }
            }
            else
            {
                yield return item;
            }
        }
    }
}