using Contest95;
using Xunit;

namespace XUnitTestProject1
{
    public class Question1Tests
    {
        public class TestCases : Question1.IConsole
        {
            public string Output { get; private set; }
            public string[] Values = {"5", "3", "1111000", "1", "1", "3", "000000", "4", "1110000", "2", "101",  };
            public int Index = 0;

            public string ReadLine()
            {
                return Values[Index++];
            }

            public void WriteLine(string value)
            {
                Output += value;
            }
        }




        [Fact]
        public void Test1()
        {
            var testCase = new TestCases();

            Question1.Logic(testCase);


            Assert.True(testCase.Output == "1000111000");
        }
    }
}
