namespace Leetcode
{
    public class Lc3
    {
        public void SelfTest()
        {
            var res1 = LengthOfLongestSubstring("abcabcbb"); // 3
            var res2 = LengthOfLongestSubstring("bbbbb"); // 1
            var res3 = LengthOfLongestSubstring("pwwkew"); // 3
            var res4 = LengthOfLongestSubstring("dvdf"); // 3
        }

        public int LengthOfLongestSubstring(string s)
        {
            var map = new Dictionary<char, int>();
            int max = 0;
            int cur = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var sym = s[i];
                if (map.ContainsKey(sym))
                {
                    i = map[sym];
                    map = new();
                    cur = 0;
                }
                else
                {
                    map[sym] = i;
                    cur++;
                    max = cur > max ? cur : max;
                }
            }
            return max;
        }
    }
}
