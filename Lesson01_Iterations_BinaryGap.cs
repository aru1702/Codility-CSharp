// Task:
// - Input of N integer
// - Convert to binary
// - Check if there is gap between 1-1 (e.g., 10001)
// - Check the biggest gap (e.g., 1001000001)
// - Return the range of biggest gap (e.g., 1001000001 --> 2 at 1001 and 5 at 100001, thus answer is 5)
// - If no gap (there is no between 1-1), return 0 (e.g., 0110, 0, 1111, 1000, 0100)

using System;

class Solution
{
    public int solution(int N)
    {
        // Convert class is from System
        string binary = Convert.ToString(N, 2);

        bool gapStart = false;
        int gapCount = 0;
        int max = 0;

        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                // Math class is from System
                max = Math.Max(max, gapCount);
                gapStart = true;
                gapCount = 0;
            }
            else
            {
                if (gapStart) gapCount++;
            }

        }

        return max;
    }

    // this is my own solution
    public int mysolution(int N)
    {
        // check if N is positive, or until 4 (100)
        // since 5 is yes (101)
        if (N <= 4) return 0;

        // use trigger and count modulo
        int count = 0, highest = 0;
        bool trigger_l = false, trigger_r = false;

        // loop of modulo
        while (N >= 1)
        {
            // if modulo is 0, increase count
            if (N % 2 == 0)
            {
                count++;
            }

            // if modulo is 1, check
            else
            {
                // if left trigger has not activated
                if (!trigger_l)
                {
                    trigger_l = true;
                }

                // if left trigger already activated
                else
                {
                    // if the highest count lower that the current count
                    if (highest < count) highest = count;

                    // active the right trigger
                    trigger_r = true;
                }

                // reset count
                count = 0;
            }

            N /= 2;
        }

        // if both trigger is activated (means gap 1-1 is found)
        if (trigger_l && trigger_r) return highest;
        return 0;
    }
}