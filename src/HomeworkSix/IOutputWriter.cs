public interface IOutputWriter
{
    void Write(string? value = default);

    void WriteLine(string? value = default);
}