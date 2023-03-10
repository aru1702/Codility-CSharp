// Task:
// - Mr. Frog wants to jump from one side to another side
// - But it needs some leaves to jump
// - X is the number required leaves, according to their position
//   - X = 10, means we need all leaves from 1, 2, ..., 10
// - Given the array of integer A[...] is indicating the time and the leaves position
//   - A[0] = 1 means a leaf is appearing (fell from tree) at pos=1, in t=0
//   - A[4] = 5 means a leaf is appearing at pos=5, t=4
// - Since we need 1...10, we have to make sure all value in A has 1...10
// - Then find when the earliest t (which is the array index), and return t
// - If A[...] = {1, 3, 2, 5, 5} and X = 5, but leaves num. 4 never appear, then it failed
// - Failed, or Mr. Frog never able to cross, will return -1

using system;

class Solution
{
    // this is original author's solution
    // check FrogRiverOne.java
    public int solution(int X, int[] A) {
        int N = A.Length;

        // instead of hashtable, he use binary conditional (bool[])
        bool[] locations = new bool[X + 1];
        
        int count = 0;
        for (int i = 0; i < N; i++)
        {
            if (!locations[A[i]]) count++;  // if off, then count up
            locations[A[i]] = true;         // set on (when already on, do nothing)
            if (count == X) return i;       // return i when satisfy
        }

        return -1;
    }

    public int mysolution(int X, int[] A) {
        // check if array is empty
        int L = A.Length;
        if (L <= 0) return -1;

        // use Hashtable since Contains function has O(1) time
        System.Collections.Hashtable h = new System.Collections.Hashtable();

        int count = 0;
        for (int i = 0 ; i < L ; i++)
        {
            if (!h.Contains(A[i]))
            {
                h.Add(A[i], A[i]);      // if no contain, add
                count++;                // and increase count
            }

            if (count >= X) return i;   // when count satisfy, return
        }

        return -1; // safe exit
    }
}