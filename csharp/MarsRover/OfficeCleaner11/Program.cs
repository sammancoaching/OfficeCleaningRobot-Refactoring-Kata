namespace OfficeCleaner11;

public static class Program
{
    public static void Main()
    {
        IStandardInputLineReader inputLineReader = new StandardInputLineReader();
        IStandardOutputLineWriter outputLineWriter = new StandardOutputLineWriter();

        Controller controller = new Controller(inputLineReader, outputLineWriter);

        controller.Rove();
    }
}