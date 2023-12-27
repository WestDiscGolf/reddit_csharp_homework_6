

var app = new MyApplication();
app.Run();




public class MyApplication
{
    public void Run()
    {
        bool isValid = false;
        string nameList;
        string yesNo;

        Console.WriteLine("Welcome to my homework app 6!");
        do
        {
            Console.Write("Please enter a name: ");
            nameList = Console.ReadLine();
            isValid = !string.IsNullOrWhiteSpace(nameList);
            if (!isValid)
            {
                Console.WriteLine("You must enter a name.");
            }

        } while (!isValid);

        Console.WriteLine("AWESOME!");

        do
        {
            Console.Write("Would you like to add another name? Y/N ");
            yesNo = Console.ReadLine()?.ToUpper();
            isValid = !string.IsNullOrWhiteSpace(yesNo);

            if (!isValid)
            {
                Console.WriteLine("Please select a valid answer.");
            }
            else if (yesNo == "Y")
            {
                Console.Write("Please enter the next name: ");
                nameList += (",") + Console.ReadLine();
            }
            else if (yesNo == "N")
            {
                Console.WriteLine("Lets move on to generating the names you've input!");
            }
            else if (yesNo != "N" || yesNo != "Y")
            {
                Console.WriteLine("Please use Y for YES and N for NO only! \n");
            }

        } while (yesNo == "Y" || yesNo != "N");

        List<string> allNames = nameList.Split(',').ToList();

        foreach (string firstName in allNames)
        {
            Console.WriteLine();
            Console.WriteLine($"Hello, {firstName}!");
        }
    }
}