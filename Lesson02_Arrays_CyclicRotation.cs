// Task:
// - Given array of integer A [...]
// - Given integer K as shift right of array A

using System;

class Solution
{
    // this is original author's solution
    // check CyclicRotation.java
    public int[] solution(int[] A, int K) {
        int len = A.Length;             // get length of A[...]
        int[] res =  new int[len];      // write new array (B[...]) with same length
        
        if (len == 0) return res;
        
        K = K % len;                    // remove cycle
        
        int index = 0;
        for (int i = len-K; i < len; i++) {     // check the data of A[K]
            res[index++] = A[i];                // input from B[0] = A[K], B[1] = A[K+1], ...
        }
        for (int i = 0; i < len-K; i++) {       // then check the data from A[0]
            res[index++] = A[i];                // input from B[K] = A[0], B[K+1] = A[1], ...
        }
        return res;

        // the reason he used index++ that use index = 0, then add 1 after that
        // when for loop processed in t=0 --> index = 0
        // after for loop processed in t=0 --> index = 1
    }

    // this is my solution
    public int[] mysolution(int[] A, int K)
    {
        // define N as length of array A
        int N = A.Length;

        // K cannot be zero or negative
        if (K <= 0) return A;

        // if N is 0 or minus
        if (N <= 0) return A;

        // divide K by the N to get reminder for K > N
        K %= N;

        // check if K between: 1 --> N/2        --> ShiftRight as much of K (more K, more shift)
        // of between: (N/2 + 1) --> (N - 1)    --> ShiftLeft as much of N - K (more K, less shift)
        if (K <= N / 2)
        {
            for (int i = 0; i < K; i++)
            {
                ShiftRight(A, N);
            }
        }
        else
        {
            for (int i = 0; i < (N - K); i++)
            {
                ShiftLeft(A, N);
            }
        }

        return A;
    }

    int[] ShiftRight(int[] A, int length)
    {
        int last = A[length - 1];
        System.Array.Copy(A, 0, A, 1, length - 1);
        A[0] = last;
        return A;
    }

    int[] ShiftLeft(int[] A, int length)
    {
        int first = A[0];
        System.Array.Copy(A, 1, A, 0, length - 1);
        A[length - 1] = first;
        return A;
    }
}