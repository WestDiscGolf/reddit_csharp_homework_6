
var app = new MyApplication(new ConsoleWriter());
app.Run();


public interface IOutputWriter
{
    void Write(string? value = default);

    void WriteLine(string? value = default);
}

public class ConsoleWriter : IOutputWriter
{
    public void Write(string? value = default) => Console.Write(value);
    public void WriteLine(string? value = default) => Console.WriteLine(value);
}

public class MyApplication
{
    private readonly IOutputWriter _outputWriter;

    public MyApplication(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter;
    }

    public void Run()
    {
        bool isValid = false;
        string nameList;
        string yesNo;

        _outputWriter.WriteLine("Welcome to my homework app 6!");
        do
        {
            _outputWriter.Write("Please enter a name: ");
            nameList = Console.ReadLine();
            isValid = !string.IsNullOrWhiteSpace(nameList);
            if (!isValid)
            {
                Console.WriteLine("You must enter a name.");
            }

        } while (!isValid);

        _outputWriter.WriteLine("AWESOME!");

        do
        {
            _outputWriter.Write("Would you like to add another name? Y/N ");
            yesNo = Console.ReadLine()?.ToUpper();
            isValid = !string.IsNullOrWhiteSpace(yesNo);

            if (!isValid)
            {
                _outputWriter.WriteLine("Please select a valid answer.");
            }
            else if (yesNo == "Y")
            {
                _outputWriter.Write("Please enter the next name: ");
                nameList += (",") + Console.ReadLine();
            }
            else if (yesNo == "N")
            {
                _outputWriter.WriteLine("Lets move on to generating the names you've input!");
            }
            else if (yesNo != "N" || yesNo != "Y")
            {
                _outputWriter.WriteLine("Please use Y for YES and N for NO only! \n");
            }

        } while (yesNo == "Y" || yesNo != "N");

        List<string> allNames = nameList.Split(',').ToList();

        foreach (string firstName in allNames)
        {
            _outputWriter.WriteLine();
            _outputWriter.WriteLine($"Hello, {firstName}!");
        }
    }
}