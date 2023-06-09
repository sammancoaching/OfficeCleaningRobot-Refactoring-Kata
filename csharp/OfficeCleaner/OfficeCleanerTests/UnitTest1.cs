

namespace MarsRoverTests;


public class MarsRoverTests
{
    
    [Test]
    public void OfficeCleaner1Test()
    {
        Console.SetIn(new StringReader("0"));
        var emptyArgs = new string[]{};
        using (StringWriter sw = new StringWriter())
        {
            OfficeCleaner1.Program.Main(emptyArgs);
            string expected = "=> Cleaned: 0";
            Assert.AreEqual(sw.ToString(), expected);
        }
    }
    
    [Test]
    public void OfficeCleaner2Test()
    {
        Console.SetIn(new StringReader("0"));
        var emptyArgs = new string[]{};
        using (StringWriter sw = new StringWriter())
        {
            OfficeCleaner2.Program.Main(emptyArgs);
            string expected = "=> Cleaned: 0";
            Assert.AreEqual(sw.ToString(), expected);
        }
    }
}