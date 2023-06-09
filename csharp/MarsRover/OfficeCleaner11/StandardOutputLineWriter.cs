namespace OfficeCleaner11
{
    public class StandardOutputLineWriter : IStandardOutputLineWriter
    {
        public void WriteLine(string output)
        {
            System.Console.WriteLine(output);
        }
    }
}
