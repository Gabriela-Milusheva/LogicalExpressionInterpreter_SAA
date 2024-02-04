using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA.Constants
{
    public class FileLocation
    {

        private static readonly string ProjectDirectory =
            Directory.GetParent(Environment.CurrentDirectory)?.Parent?.FullName;

        public static readonly string FilesFolderPath = Path.Combine(ProjectDirectory, "FunctionFiles");

        public static readonly string FileLocationTxt = Path.Combine(FilesFolderPath, "functions.txt");
    }
}
