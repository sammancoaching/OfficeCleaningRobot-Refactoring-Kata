
using System.Collections;
using Xunit;

namespace OfficeCleanerTests;

public class TestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { "Input_empty.txt",  "=> Cleaned: 1"},
        new object[] { "Input_one.txt",  "=> Cleaned: 1"},
        new object[] { "Input_given_sample.txt",  "=> Cleaned: 4"},
        new object[] { "Input_only_west.txt",  "=> Cleaned: 9"},
        new object[] { "Input_wiping.txt",  "=> Cleaned: 9"},
        new object[] { "Input_large.txt",  "=> Cleaned: 1047"},
    };
    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class OfficeCleanerTests
{
    private static void DoRobotCleanerTest(string filename, string expected, Action<string[]> sut)
    {
        try
        {
            Console.SetIn(new StreamReader(filename));
            var emptyArgs = new string[] { };

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sut(emptyArgs);
                Assert.Equal(expected, sw.ToString().Trim());
            }
        }
        finally
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }
        
    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner1Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner1.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner2Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner2.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner3Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner3.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner4Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner4.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner5Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner5.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner6Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner6.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner7Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner7.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner8Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner8.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner9Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner9.Program.Main);

    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner10Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner10.Program.Main);
    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner11Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner11.Program.Main);

    }
    
    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void OfficeCleaner12Test(string filename, string expected)
    {
        DoRobotCleanerTest(filename, expected, (Action<string[]>)OfficeCleaner12.Program.Main);

    }
}