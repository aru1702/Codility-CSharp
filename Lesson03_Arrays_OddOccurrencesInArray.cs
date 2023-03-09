// Task:
// - Given array of integer A[...]
// - Detect any pair of integer inside the array (e.g., A[0]=1 and A[4]=1)
// - Since the return value is single integer, there will ALWAYS one unpair
// - Return the unpair value

using System;

class Solution
{
    // this is original author's solution
    // check OddOccurrencesInArray.java
    public int mysolution(int[] A)
    {
        // in original java solution, he used Set class which similar to HashSet --> HashTable
        System.Collections.Hashtable set = new System.Collections.Hashtable();

        // O(n)
        for (int i = 0; i < A.Length; i++)
        {
            // even Contains looks like search inside array, but it has O(1)
            if (set.Contains(A[i])) set.Remove(A[i]);
            else set.Add(A[i], A[i]);
        }

        // Set class can convert to Iterator to copy all value into it
        // Iterator class is a collection, just like array but dynamic

        // there is no such a method to copy Hashtable other than array
        // I change a little bit into checking to array
        foreach (System.Collections.DictionaryEntry item in set)
        {
            return (int) item.Value;
        }

        return 0;   // safe exit
    }

    // this is my solution
    // the time complexity is O(n**2)
    // I use dictionary pair to detect any inserted key-pair
    public int mysolution(int[] A)
    {        
        // define N as length
        int N = A.Length;

        // check if length is 0 or less
        if (N <= 0) return 0;

        System.Collections.Generic.Dictionary<int, int> dictionary =
            new System.Collections.Generic.Dictionary<int, int>();

        // check for array A --> O(n)
        for (int i = 0; i < N; i++)
        {
            // not available for C# under 9.0
            // if (!dictionary.TryAdd(A[i], A[i]))
            // {
            //     dictionary.Remove(A[i]);
            // }

            // maybe another O(n) ?
            try
            {
                dictionary.Add(A[i], A[i]);
            }
            catch (System.Exception)
            {
                dictionary.Remove(A[i]);
            }
        }

        if (dictionary.Count > 0)
        {
            int[] temp = new int[1];
            dictionary.Values.CopyTo(temp, 0);
            return temp[0];
        }

        return 0;
    }

    // some of my consideration
    // -------------------------
    // one of the way is sorting, and check per two character
    // but sorting will takes more time
    // - sorting time           --> O(nlogn)
    // - check for loop time    --> O(n)

    // stacking?
    // - push if none data is present   --> O(n)
    // - pop if data is present         --> O(1)

    // key-value pair array
    // - "key" is A[...] value, "value" is count, and put into key-pair
    // - if key is same, increase count, those who's count is odd is the answer

    // double array
    // - use Array.Exists               --> O(n)
    // - for loop for previous array    --> O(n)

    // dictionary
    // - stack-like with able to check if any duplication
    // - Add(key, value) to add with try-catch
    // - TryAdd(key, value) to add and return bool if failed
}
