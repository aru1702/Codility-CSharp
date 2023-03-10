// Task:
// - Permutation is when the series of number is available from 1 to N
// - For example, 5! = 5 * 4 * 3 * 2 * 1, thus the number should exists are 1...5
// - The important thing is each number can only appear once, no duplication, and must exist
// - A given array A[...] with N number of integer (length)
// - Find if the array is permutation, return 1, otherwise return 0

using System;

class Solution {
    // this is original author's solution, check PermCheck.java
    public int solution(int[] A) {
        int N = A.Length;

        // the author used the similar approach as previous one
        // but I think there is a lack of this one, where:
        //   A[...] = {4, 3}
        //   A.Length = 2
        //   bool seen[] has size 2 + 1
        //   check seen[4] --> out of range
        // otherwise it is good as long the HIGHEST number == (N + 1)
        bool[] seen = new bool[N + 1];
        int count = 0;
        foreach (int val in A)
        {
            // for duplication check, it checks if A[i] <= A[...] size
            // but again, it is safe for above condition
            if (val <= N)
            {
                if (!seen[val]) count++;
                seen[val] = true;
            }
            else
            {
                return 0;
            }
        }

        return (count == N) ? 1 : 0;
    }

    public int mysolution(int[] A) {
        // Side notes:
        // - The task is stating that A is array
        // - The task is stating that N is the length of array
        // - By this, we should follow the rule to write a clean code

        // check if empty array
        int N = A.Length;
        if (N <= 0) return 0;

        // use Hashtable since Contains function has O(1) time
        System.Collections.Hashtable h = new System.Collections.Hashtable();

        int count = 0; int high = 0;
        for (int i = 0 ; i < N ; i++)
        {
            if (!h.Contains(A[i]))
            {
                h.Add(A[i], A[i]);      // if no contain, add
                count++;                // and increase count
            }
            else
            {
                // found duplication then it's wrong
                return 0;
            }
            high = System.Math.Max(high, A[i]);
        }
        
        if (count >= high) return 1;   // when count satisfy, return
        return 0; // safe exit
    }
}