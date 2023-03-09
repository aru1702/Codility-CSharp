// Task:
// - A set of array integer A[...] consists of unique integer (no repetition)
// - From N as length of array A, there is exactly one element is missing
// - For example, [2, 3, 1, 5], the missing part is 4
// - Value inside the array is in range [1 ... (N+1)]

using System;

class Solution {
    // this is original author's solution
    // check PermMissingElem.java
    public int solution(int[] A) {
        int i = 0;
        while (i < A.Length) {
            if (A[i] == i+1 || A[i] > A.Length) i++;
            else swap(A, i, A[i] - 1);
        }
        for (i = 0; i < A.Length; i++) {
            if (A[i] != i+1) return i+1;
        }
        return A.Length+1;
    }
    
    void swap(int[] arr, int pos1, int pos2) {
        int temp = arr[pos1];
        arr[pos1] = arr[pos2];
        arr[pos2] = temp;
    }

    public int mysolution(int[] A) {       
        // check if array is non empty
        if (A.Length <= 0) return 1;

        // sort the array then find if any difference is 2 or more
        // return the A[i] + 1
        System.Array.Sort(A);                   // O(nlogn)
        for (int i = 0 ; i < A.Length ; i++)  // O(n)
        {
            // if (A[i+1] - A[i] > 1) return A[i] + 1;
            // above is lack of getting the first or last data
            // previous is using --> for (int i = 0 ; i < A.Length-1 ; i++)

            // if i = 0 and A[i] is not 1 (maybe 2)
            if (A[i] != i+1) return i+1;    // where 0+1 as first data
            // above is also able to fill the missing middle
        }

        // outside of it, it return the last data
        return A.Length + 1;
    }
}
