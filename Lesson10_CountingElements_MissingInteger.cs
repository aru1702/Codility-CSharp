// Task:
// - The given array A[...] with N-element integer, find the smallest missing number
// - Number inside A can be negative, zero, or positive [-i..0..i]
// - The missing number should be positive non-zero number
// - For example --> [-1, -3, 4, 5, 6] --> Answer: 1, it cannot -2 (negative), or 0 (zero)

using System;

class Solution {
    // this is original author's solution, check MissingInteger.java
    public int solution(int[] A){
        // create a HashSet
        // it is Generic type so dynamically can be add and modify
        // more like, List<T>
        System.Collections.Generic.HashSet<int> seen = 
            new System.Collections.Generic.HashSet<int>();

        // remove any below zero (-i...0)
        foreach (int num in A)
        {
            if (num > 0) seen.Add(num);
        }

        int notFound = 1;       // which one is not found inside A
        int count = 0;          // to count until reach the end of A

        // O(n)
        while (count != seen.Count)
        {
            // could be O(1) or O(n)
            if (seen.Contains(notFound))
            {
                notFound++;
                count++;
            }
            else return notFound;
        }
        return notFound;
    }

    // some answer is incorrect, but time complexity is good
    public int mysolution(int[] A) {
        // check empty array
        int N = A.Length;
        if (N <= 0) return 1;

        System.Array.Sort(A);   // O(nlogn)

        // remove minus and zero
        int i = 0;
        while (A[i] <= 0)
        {
            ++i;
            if (i == N) return 1;
        }

        // if reminder is only 1 element
        if (i + 1 == N && A[i] > 1) return 1;

        // if reminder is more than one elements
        for (int j = i ; j < N-1 ; j++)
        {
            if (System.Math.Abs(A[j] - A[j+1]) > 1)
            {
                return A[j] + 1;
            }
        }

        return A[N-1] + 1;
        
        // return 1; // safe exit, default return value
    }
}
