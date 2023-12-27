namespace HomeworkSix;

public class ConsoleWriter : IOutputWriter
{
    public void Write(string? value = default) => Console.Write(value);
    public void WriteLine(string? value = default) => Console.WriteLine(value);
}