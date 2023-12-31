﻿using LogForU.Core.Exceptions;
using LogForU.Core.IO.Interfaces;
using System;
using System.IO;
using System.Text;

namespace LogForU.Core.IO
{
    public class LogFile : ILogFile
    {
        private const string DefaultExtension = "txt";
        private static readonly string DefaultName = $"Log {DateTime.Now:yyyy-MM-dd-hh-mm-ss}";
        private static readonly string DefaulPath = $"{Directory.GetCurrentDirectory()}";

        private string name;
        private string extension;
        private string path;

        private readonly StringBuilder content;

        public LogFile()
        {
            Name = DefaultName;
            Extension = DefaultExtension;
            Path = DefaulPath;

            content = new StringBuilder();
        }

        public LogFile(string name, string extension, string path) 
            : this()
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

        public string FullPath => System.IO.Path.GetFullPath($"{Path}/{Name}.{Extension}");

        public string Content => content.ToString().TrimEnd();

        public int Size => Content.Length;

        public void WriteLine(string text)
            => content.AppendLine(text);
    }
}
