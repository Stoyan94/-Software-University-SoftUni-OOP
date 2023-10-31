using LogForU.Core.Exceptions;
using LogForU.Core.IO.Interfaces;
using System.IO;
using System.Text;

namespace LogForU.Core.IO
{
    public class LogFile : ILogFile
    {
        private string name;
        private string extension;
        private string path;

        private readonly StringBuilder content;

        public LogFile(string name, string extension, string path)
        {
            Name = name;
            Extension = extension;
            Path = path;
        }

        public string Name 
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileNameException();
                }
                name = value;
            } 
        }

        public string Extension
        {
            get => extension;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFileExtensionException();
                }
                extension = value;
            }
        }

        public string Path
        {
            get => path;
            private set
            {
                if (!Directory.Exists(value))
                {
                    throw new InvalidPathException();
                }
                path = value;
            }
        }

        public string FullPath => throw new System.NotImplementedException();

        public string Content => throw new System.NotImplementedException();

        public string Size => throw new System.NotImplementedException();

        public void WriteLine(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
