using OrderManagementSystem;
using OrderManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeChecker
{
    public class StringUtilsServiceTests
    {
        [Theory]
        [InlineData("racecar", true)]
        [InlineData("hello", false)]
        public void WhenPalindromeIsGiven(string word, bool expectedResult)
        {
            StringUtilsService service = new StringUtilsService();
            bool actualResult = service.CheckIfPalindrome(word);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("abc", "def", "abcdef")]
        [InlineData("hello", "world", "helloworld")]
        public void CheckIfStringConcat(string str1, string str2, string expectedResult)
        {
            StringUtilsService service = new StringUtilsService();
            string actualResult = service.ConcatStrings(str1, str2);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
