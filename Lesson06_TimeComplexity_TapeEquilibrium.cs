// Task:
// - Given the array of integer A[...], and N is the length of A
// - Range of integer is -1000 to 1000, there is negative value
// - For the sum of two different group, e.g., A[10] with random value inside
//   - Group 1: A[0] + A[1]
//   - Group 2: A[2] + A[3] + ... + A[9]
//   - The absolute difference --> absD = |G1 - G2|
// - For any combination, and in order (e.g., cannot A[0] + A[3], and so on),
// - Find the lowest value of absD

using System;

class Solution {
    // this is original author's solution
    // check TapeEquilibrium.java
    public int solution(int[] A)
    {
        int len = A.Length;
        int[] sumSoFar = new int[len];

        // sum of index 0
        sumSoFar[0] = A[0];
        for (int i = 1; i < len; i++)
        {
            // sum of index i = sum[i-1] + A[i]
            sumSoFar[i] = A[i] + sumSoFar[i - 1];
        }
        // above is to get every accumulate sum of each value in array
        // sum[0] = A[0]
        // sum[1] = sum[0] + A[1]
        // sum[5] = sum[4] + A[5]

        int min = int.MaxValue;
        int total = sumSoFar[len - 1];
        for (int i = 0; i < len - 1; i++)
        {
            // check which larger between (sum [i]) and (sum[L-1] - sum[i])
            int larger = System.Math.Max(sumSoFar[i], total - sumSoFar[i]);

            // check which smaller as same as above
            int smaller = System.Math.Min(sumSoFar[i], total - sumSoFar[i]);

            // check which smaller between current difference and saved difference
            min = System.Math.Min(min, larger - smaller);
        }
        return min;
    }

    public int mysolution(int[] A) {
        int L = A.Length;

        // get rid empty array
        if (L <= 0) return 0;
        if (L == 1) return A[0];

        // get all sum
        int sum = Sum(A, 0, L);

        // set lowest value as result
        int value = 2001;   // this can be change into int.MaxValue

        // check array
        int hold = 0;
        for (int i = 0 ; i < L - 1 ; i++)
        {
            hold += A[i];
            sum -= A[i];
            int diff = System.Math.Abs(sum - hold);
            if (diff < value) value = diff;

            // see the result
            // Console.WriteLine("diff of " + i + ": " + diff);
        }

        return value;
    }

    int Sum(int[] array, int index_l, int index_r)
    {
        int result = 0;
        for (int i = index_l ; i < index_r ; i++)
        {
            result += array[i];
        }
        return result;
    }
}
