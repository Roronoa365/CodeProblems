namespace CodeProblems.Services
{
    public class FirstPalindromeService : IFirstPalindromeService
    {
        //https://leetcode.com/problems/palindrome-number/description
        public string GetFirstPalindrome(string[] words)
        {
            foreach (string word in words)
            {
                bool isPalindrome = IsPalindrome(word);

                if (isPalindrome)
                {
                    return word;
                }
            }

            return "";
        }

        private bool IsPalindrome(string word)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            string reversedString = new string(chars);

            if (reversedString == word)
            {
                return true;
            }

            return false;
        }
    }
}
