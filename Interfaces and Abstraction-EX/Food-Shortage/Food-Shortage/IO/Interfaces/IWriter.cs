﻿using System;

namespace Food_Shortage.IO.Interfaces
{
    public interface IWriter
    {
        public void WriteLine(string line);
        public void ParsLine(int line);
    }
}
