using Contest95;
using Xunit;

namespace XUnitTestProject1
{
    public class Question2Tests
    {
        public class TestCases : Question2.IConsole
        {
            public string Output { get; private set; }
            public string[] Values = {"3", "110", "1", "101110", "2", "01", "1", "4", "1110000", "2", "101",  };
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

            Question2.Logic(testCase);


            Assert.True(testCase.Output == "-111101110");
        }
    }
}
