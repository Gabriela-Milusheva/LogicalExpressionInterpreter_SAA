using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAA.Function;
using SAA.Utilities;

namespace SAA.Services
{
    public static class FileOperations
    {
        public static void SaveToFile(MyList<DefinedFunction>? functionsList, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (DefinedFunction function in functionsList)
                    {
                        sw.WriteLine($"{function.Name}({string.Join(",", function.Operands)}): {function.Body}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }
        public static MyList<DefinedFunction> ReadFromFile(string path)
        {
            MyList<DefinedFunction> functionsList = null;

            try
            {
                string[] fileLines = File.ReadAllLines(path);

                functionsList = new MyList<DefinedFunction>(fileLines.Length);

                foreach (string line in fileLines)
                {
                    var currFunction = new DefinedFunction(line);
                    functionsList.Add(currFunction);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return functionsList;
        }
    }
}
