using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + "error.txt", error);

        }
    }
}
