using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class SumOfK 
{
    public static int? chooseBestSum(int t, int k, List<int> ls) {
        // your code
      if(ls.Count < k)
        return null;
      
      int maxDistance = 0;
      int distance = 0;
      
      foreach (IEnumerable<int> combination in Combinations(ls, k))
      {
        foreach(var i in combination)
        {
          distance += i;
        }
        
        if(distance > maxDistance && distance <= t)
          maxDistance = distance;
        
        distance = 0;
      }

      if(maxDistance == 0)
        return null;
      else
        return maxDistance;
    }
  
    private static bool NextCombination(IList<int> num, int n, int k)
      {
         bool finished;
 
         var changed = finished = false;
 
         if (k <= 0) return false;
 
         for (var i = k - 1; !finished && !changed; i--)
         {
            if (num[i] < n - 1 - (k - 1) + i)
            {
               num[i]++;
 
               if (i < k - 1)
                  for (var j = i + 1; j < k; j++)
                     num[j] = num[j - 1] + 1;
               changed = true;
            }
            finished = i == 0;
         }
 
         return changed;
      }
 
      private static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
      {
         var elem = elements.ToArray();
         var size = elem.Length;
 
         if (k > size) yield break;
 
         var numbers = new int[k];
 
         for (var i = 0; i < k; i++)
            numbers[i] = i;
 
         do
         {
            yield return numbers.Select(n => elem[n]);
         } while (NextCombination(numbers, size, k));
      }
}
