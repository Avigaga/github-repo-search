public static string LongestSubstringWithoutRepeatingChars(string s)
{
    if (string.IsNullOrEmpty(s))
        return "";

    var seen = new Dictionary<char, int>();
    int start = 0;
    int maxLength = 0;
    int maxStart = 0;

    for (int end = 0; end < s.Length; end++)
    {
        char c = s[end];
        if (seen.ContainsKey(c) && seen[c] >= start)
        {
            start = seen[c] + 1;
        }
        seen[c] = end;

        if (end - start + 1 > maxLength)
        {
            maxLength = end - start + 1;
            maxStart = start;
        }
    }

    return s.Substring(maxStart, maxLength);
}
