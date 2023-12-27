using AutoFixture.Xunit2;
using Moq;

namespace HomeworkSix.Tests;

public class MyApplicationTests
{
    [Theory]
    [InlineAutoMoqData]
    public void Welcome_Is_Displayed(
        [Frozen] Mock<IOutputWriter> outputWriter,
        [Frozen] Mock<IInputReader> inputReader,
        string input,
        MyApplication sut
        )
    {
        // Arrange
        inputReader.SetupSequence(x => x.ReadLine())
            .Returns(input)
            .Returns("n");

        // Act
        sut.Run();

        // Assert
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == "Welcome to my homework app 6!")), Times.Once);
    }

    [Theory]
    [InlineAutoMoqData((string?)null)]
    [InlineAutoMoqData("")]
    public void Invalid_Name_Entered(
        string? invalidValue,
        [Frozen] Mock<IOutputWriter> outputWriter,
        [Frozen] Mock<IInputReader> inputReader,
        string input,
        MyApplication sut
    )
    {
        // Arrange
        inputReader.SetupSequence(x => x.ReadLine())
            .Returns(invalidValue)
            .Returns(input)
            .Returns("n");

        // Act
        sut.Run();

        // Assert
        outputWriter.Verify(x => x.Write(It.Is<string>(s => s == "Please enter a name: ")), Times.Exactly(2));
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == "You must enter a name.")), Times.Once);
    }

    [Theory]
    [InlineAutoMoqData]
    public void Successful_Initial_Entry_Displays_Awesome(
        [Frozen] Mock<IOutputWriter> outputWriter,
        [Frozen] Mock<IInputReader> inputReader,
        string input,
        MyApplication sut
    )
    {
        // Arrange
        inputReader.SetupSequence(x => x.ReadLine())
            .Returns(input)
            .Returns("n");

        // Act
        sut.Run();

        // Assert
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == "AWESOME!")), Times.Once);
    }

    [Theory]
    [InlineAutoMoqData]
    public void Add_Another_Valid_Name_HappyPath(
        [Frozen] Mock<IOutputWriter> outputWriter,
        [Frozen] Mock<IInputReader> inputReader,
        string firstName,
        string secondName,
        MyApplication sut)
    {
        // Arrange
        inputReader.SetupSequence(x => x.ReadLine())
            .Returns(firstName)
            .Returns("y")
            .Returns(secondName)
            .Returns("n");

        // Act
        sut.Run();

        // Assert
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == "Welcome to my homework app 6!")), Times.Once);
        outputWriter.Verify(x => x.Write(It.Is<string>(s => s == "Please enter a name: ")), Times.Once);
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == "AWESOME!")), Times.Once);
        outputWriter.Verify(x => x.Write(It.Is<string>(s => s == "Would you like to add another name? Y/N ")), Times.Exactly(2));
        outputWriter.Verify(x => x.Write(It.Is<string>(s => s == "Please enter the next name: ")), Times.Once);
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => string.IsNullOrWhiteSpace(s))), Times.Exactly(2));
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == $"Hello, {firstName}!")), Times.Once);
        outputWriter.Verify(x => x.WriteLine(It.Is<string>(s => s == $"Hello, {secondName}!")), Times.Once);
    }
}