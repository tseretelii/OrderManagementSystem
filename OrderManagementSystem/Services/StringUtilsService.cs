namespace OrderManagementSystem.Services
{
    public class StringUtilsService
    {
        public bool CheckIfPalindrome(string word)
        {
            word = word.ToLower();
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1- i])
                    return false;
            }
            return true;
        }

        public string ConcatStrings(string str1, string str2)
        {
            return str1 + str2;
        }
    }
}
