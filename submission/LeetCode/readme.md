# Maximum Number of Vowels in a Substring of Given Length

## 📝 Problem Description

Given a string `s` and an integer `k`, return *the maximum number of vowel letters in any substring of `s` with length `k`*.

Vowel letters in English are `'a'`, `'e'`, `'i'`, `'o'`, and `'u'`.

---

## 📊 Submission Details

* **Status:** Accepted[cite: 3]
* **Testcases Passed:** 107 / 107[cite: 3]
* **Runtime:** 9 ms (Beats **45.81%**)[cite: 3]
* **Memory:** 45.12 MB (Beats **54.19%**)[cite: 3]

---

## 💡 Intuition & Approach

The problem asks for the maximum number of vowels in any continuous substring of length `k`. A brute-force approach checking every substring of length `k` would take $O(n \times k)$ time, which is too slow.

Instead, we use the **Sliding Window** technique:
1. Maintain a running window of size `k` as we traverse the string from left to right.
2. **Add the incoming character** at index `i`: if it's a vowel, increment our running count (`count++`).
3. **Remove the outgoing character** at index `i - k`: if it was a vowel, decrement our running count (`count--`).
4. Update the maximum count observed so far (`max = Math.Max(max, count)`).

---

## 🛠️ C# Implementation

```csharp
public class Solution {
    public int MaxVowels(string s, int k) {
        List<char> bag = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        int count = 0;
        int max = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // Expand window: add current character if it is a vowel
            if (bag.Contains(s[i]))
                count++;

            // Shrink window: remove the leftmost character if window size exceeds k
            if (i - k >= 0)
            {
                if (bag.Contains(s[i - k]))
                    count--;
            }

            // Update maximum vowels found in any window of size k
            max = Math.Max(max, count);
        }

        return max;
    }
}