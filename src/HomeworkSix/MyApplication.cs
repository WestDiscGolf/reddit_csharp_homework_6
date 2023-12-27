public class MyApplication
{
    private readonly IOutputWriter _outputWriter;
    private readonly IInputReader _inputReader;

    public MyApplication(
        IOutputWriter outputWriter, 
        IInputReader inputReader)
    {
        _outputWriter = outputWriter;
        _inputReader = inputReader;
    }

    public void Run()
    {
        bool isValid = false;
        string? nameList;
        string yesNo;

        _outputWriter.WriteLine("Welcome to my homework app 6!");
        do
        {
            _outputWriter.Write("Please enter a name: ");
            nameList = _inputReader.ReadLine();
            isValid = !string.IsNullOrWhiteSpace(nameList);
            if (!isValid)
            {
                _outputWriter.WriteLine("You must enter a name.");
            }

        } while (!isValid);

        _outputWriter.WriteLine("AWESOME!");

        do
        {
            _outputWriter.Write("Would you like to add another name? Y/N ");
            yesNo = _inputReader.ReadLine()?.ToUpper();
            isValid = !string.IsNullOrWhiteSpace(yesNo);

            if (!isValid)
            {
                _outputWriter.WriteLine("Please select a valid answer.");
            }
            else if (yesNo == "Y")
            {
                _outputWriter.Write("Please enter the next name: ");
                nameList += (",") + _inputReader.ReadLine();
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