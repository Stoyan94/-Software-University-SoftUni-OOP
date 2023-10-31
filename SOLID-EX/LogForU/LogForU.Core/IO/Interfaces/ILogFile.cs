namespace LogForU.Core.IO.Interfaces
{
    public interface ILogFile
    {
        string Name { get; }
        string Extension { get; }
        string Path { get; }
        string FullPath { get; }
        string Content { get; }
        string Size { get; }    

        void WriteLine(string text);
    }
}
