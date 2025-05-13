using System;

public class Solution

{
    

    public static void Main()
    {
        var sol = new Solution();

        Console.WriteLine(sol.TotalLengthAfterTransformations("abcyy", 2)); // Output: 7
        Console.WriteLine(sol.TotalLengthAfterTransformations("azbk", 1));  // Output: 5
    }


    public int TotalLengthAfterTransformations(string s, int t)
    {
        const int MOD = 1_000_000_007;
        int[] dp = new int[26];

        // Base case: at t=0, every character contributes 1 character (itself)
        for (int i = 0; i < 26; i++)
            dp[i] = 1;

        // Perform t transformations
        for (int step = 0; step < t; step++)
        {
            int[] newDp = new int[26];
            for (int i = 0; i < 26; i++)
            {
                if (i == 25) // 'z'
                {
                    newDp[i] = (dp[0] + dp[1]) % MOD; // 'z' -> "ab"
                }
                else
                {
                    newDp[i] = dp[i + 1]; // 'a' -> 'b', etc.
                }
            }
            dp = newDp;
        }

        // Calculate the total length
        long result = 0;
        foreach (char ch in s)
        {
            result = (result + dp[ch - 'a']) % MOD;
        }

        return (int)result;
    }
}
