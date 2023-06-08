 namespace MarsRover11
{
    public class StandardInputLineReader : IStandardInputLineReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}