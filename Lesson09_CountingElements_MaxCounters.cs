// Task:
// - The array A[...] with size of M is given
// - As much of N-integer counter is created (array of counters)
// - If the A[i] --> 1 <= X <= N, then Counter[X-1]++
// - If the A[i] --> N+1, then all counter assigned to the highest value exists
// - For example:
//   - Counter[]: {0, 2, 1, 0, 0} --> M=5
//   - A[0] = 3, condiiton 1 met, then Counter[2]++
//   - A[1] = 6, condition 2 met, then Counter[0...4] = highest value
// - Not described but the integer value inside A will never more than N+1 (e.g., N+2, and sort of)

using System;

class Solution {
    // this is original author's solution, check MaxCounters.java
    // to be honest, this is genius solution, at least for me
    public int[] solution(int N, int[] A){
        // counters array
        int[] myArr = new int[N];

        // current max, the highest value
        int curMax = 0;

        // save final max, when there is X = N+1
        int finalMax = 0;

        // save trigger of which array has not been updated after final max
        bool[] lastMaxUpdated = new bool[N];

        // since value in A[...] is starts from 1
        // we need to minus, as i-1, to perform as array index
        foreach (int operation in A)
        {
            // if condition 2 is satisfied
            // RESET condition
            if (operation == N + 1)
            {
                finalMax = curMax;              // set the final max
                lastMaxUpdated = new bool[N];   // reset the trigger
            }
            else
            {
                // if trigger is FALSE, set the counter to final max first
                if (!lastMaxUpdated[operation - 1]){
                    myArr[operation - 1] = finalMax;
                }

                // then increase the counter
                myArr[operation - 1]++;

                // turn the correspondent trigger to TRUE
                lastMaxUpdated[operation - 1] = true;

                // search which bigger, between current highest value and new assigned one
                curMax = System.Math.Max(curMax, myArr[operation - 1]);
            }
        }

        // for every counters that has not updated yet after the last RESET condition
        for (int i = 0; i < N; i++)
        {
            // just assign with the saved final max
            if (!lastMaxUpdated[i]) myArr[i] = finalMax;
        }

        return myArr;
    }

    // I ended up with nested loop O(n*n)
    // Try to use Array.Fill but codility doesn't support well
    // Try with IEnumerable but not worked
    public int[] mysolution(int N, int[] A) {
        // check non-empty array (where M is the size)
        int M = A.Length;
        if (M <= 0) return new int[1];

        // build the counters
        int[] counters = new int[N];
        int high = 0;

        for (int i = 0 ; i < M ; i++)
        {
            // increase(X)
            if (A[i] >= 1 && A[i] <= N)
            {
                ++counters[A[i] - 1];
                high = System.Math.Max(high, counters[A[i] - 1]);
            }

            // max counter
            if (A[i] == N + 1)
            {
                // with loop but it will O(n*n)
                for (int j = 0 ; j < N ; j++)
                {
                    counters[j] = high;
                }
            }

            // Debug(counters);
        }

        return counters;
    }

    void Debug(int[] A)
    {
        string s = "{";
        for (int i = 0 ; i < A.Length - 1 ; i++)
        {
            s += A[i] + ", ";
        }
        s += A[A.Length - 1] + "}";
        Console.WriteLine(s);
    }
}

// BACKUP with many solution
// class Solution {
//     public int[] solution(int N, int[] A) {
//         // check non-empty array (where M is the size)
//         int M = A.Length;
//         if (M <= 0) return new int[1];

//         int savepoint = 0;
//         int high = 0;
//         int[] counters;

//         checkpoint:
//         // Console.WriteLine(savepoint);
//         // Console.WriteLine(high);

//         // build the counters
//         counters = new int[N];
//         if (high > 0)
//         {
//             for (int i = 0 ; i < N ; i++)
//             {
//                 counters[i] = high;
//             }
//         }

//         for (int i = savepoint + 1 ; i < M ; i++)
//         {
//             // increase(X)
//             if (A[i] >= 1 && A[i] <= N)
//             {
//                 ++counters[A[i] - 1];
//                 high = System.Math.Max(high, counters[A[i] - 1]);
//             }

//             // max counter
//             if (A[i] == N + 1)
//             {
//                 // for-loop inside loop will create O(n*n)
//                 // for (int j = 0 ; j < N ; j++)
//                 // {
//                 //     counters[j] = high;
//                 // }
                
//                 // Array.Fill only in .NET 8 or Core 2.0
//                 // System.Array.Fill<int>(A, high);

//                 // this is not working
//                 // A = Enumerable.Repeat(high, N).ToArray();

//                 // label and goto, similar to loop --> O(n)
//                 // int j = 0;
//                 // todo:
//                 //     if (j < N)
//                 //     {
//                 //         counters[j] = high;
//                 //         j++;
//                 //         goto todo;
//                 //     }

//                 // checkpoint (see above)
//                 savepoint = i;
//                 goto checkpoint;
//             }
            
//             // Debug(counters, i);
//         }

//         return counters;
//     }

//     void Debug(int[] A, int phase)
//     {
//         string s = "[" + phase + "]: {";
//         for (int i = 0 ; i < A.Length - 1 ; i++)
//         {
//             s += A[i] + ", ";
//         }
//         s += A[A.Length - 1] + "}";
//         Console.WriteLine(s);
//     }
// }
