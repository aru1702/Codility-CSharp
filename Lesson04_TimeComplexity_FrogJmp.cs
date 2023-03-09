// Task:
// - Frog wants to jump from X to Y with range D
// - X is the start line
// - Y is the end line
// - D is the range, how far the frog can jump
// - Return the number of jump needed, even if the frog cross the Y line

using System;

class Solution {
    // this is original author's solution
    // check FrogJmp
    public int solution(int X, int Y, int D) {
        int dist = Y - X;
        int n = dist / D;
        
        if (dist % D != 0) n++;
        
        return n;
    }

    public int mysolution(int X, int Y, int D) {
        // X must less than Y
        if (X >= Y) return 0;

        // (end - start) then div by the jump
        // but it can't round up the integer
        // round up integer solution:
        // https://stackoverflow.com/questions/17944/how-to-round-up-the-result-of-integer-division
        return (Y - X - 1) / D + 1;

        // test values:
        // (0, 8, 3)
        // (0, 9, 3)
        // (0, 10, 3)
        // (0, 0, 0)
        // (0, 10, 10)
        // (10, 10, 1)
    }
}