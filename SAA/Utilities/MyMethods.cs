using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using SAA.Function;

namespace SAA.Utilities
{
    public class MyMethods
    {
        public static string[] Split(string input, char separator)
        {
            int parts = 1;
            foreach (char c in input)
            {
                if (c == separator)
                {
                    parts++;
                }
            }

            string[] splitedStringArray = new string[parts];
            string currentPart = "";
            int partIndex = 0;

            foreach (char c in input)
            {
                if (c != separator)
                {
                    currentPart += c;
                }
                else
                {
                    splitedStringArray[partIndex] = currentPart;
                    partIndex++;
                    currentPart = "";
                }
            }
            splitedStringArray[partIndex] = currentPart;

            return splitedStringArray;
        }

        static string[] SplitString(string input)
        {
            string[] result = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = input[i].ToString();
            }

            return result;
        }
        public static string[] Split(string input, char firstSeparator, char secondSeparator)
        {
            int parts = 1;
            foreach (char c in input)
            {
                if (c == firstSeparator || c == secondSeparator)
                {
                    parts++;
                }
            }

            string[] splitedStringArray = new string[parts];
            string currentPart = "";
            int partIndex = 0;

            foreach (char c in input)
            {
                if (c != firstSeparator && c != secondSeparator)
                {
                    currentPart += c;
                }
                else
                {
                    splitedStringArray[partIndex] = currentPart;
                    partIndex++;
                    currentPart = "";
                }
            }
            splitedStringArray[partIndex] = currentPart;

            return splitedStringArray;
        }
        public static string[] SeparateNameFromArguments(string input)
        {
            string[] splitedStringArray = new string[2];
            string currentPart = "";

            foreach (char c in input)
            {
                if (c == '(')
                {
                    splitedStringArray[0] = currentPart;
                    currentPart = "";
                    continue;
                }
                else if (c == ')')
                {
                    splitedStringArray[1] = currentPart;
                    break;
                }
                else
                {
                    currentPart += c;
                }

            }

            return splitedStringArray;
        }
        public static string[] SplitIntoParts(string input, int parts, char separator)
        {
            string[] splitedStringArray = new string[parts];
            string currentPart = "";
            int partIndex = 0;

            foreach (char c in input)
            {
                if (c == separator && partIndex != parts - 1)
                {
                    splitedStringArray[partIndex] = currentPart;
                    partIndex++;
                    currentPart = "";
                }
                else
                {
                    currentPart += c;
                    splitedStringArray[partIndex] = currentPart;
                }
            }
            return splitedStringArray;
        }
        public static string ConvertLetterCase(string input, string letterCase)
        {
            string converted = "";

            foreach (char c in input)
            {
                if (letterCase == "upper" && c >= 'a' && c <= 'z')
                {
                    converted += (char)(c - ('a' - 'A'));
                }
                else if (letterCase == "lower" && c >= 'A' && c <= 'Z')
                {
                    converted += (char)(c + ('a' - 'A'));
                }
                else
                {
                    converted += c;
                }
            }

            return converted;
        }
        public static string TrimStartAndEnd(string input, char trimChar)
        {
            int start = 0;
            int end = input.Length - 1;

            while (start <= end && input[start] == trimChar)
            {
                start++;
            }

            while (end >= start && input[end] == trimChar)
            {
                end--;
            }

            string trimedOutput = "";
            for (int i = start; i <= end; i++)
            {
                trimedOutput += input[i];
            }

            return trimedOutput;
        }
        public static string RemoveChar(string input, char charToRemove)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != charToRemove)
                {
                    output += input[i];
                    continue;
                }
                else
                {
                    continue;
                }
                output += input[i];
            }

            return output;
        }
        public static bool StartsWith(string input, string prefix)
        {
            if (prefix.Length > input.Length)
            {
                return false;
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (input[i] != prefix[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool EndsWith(string input, string suffix)
        {
            if (suffix.Length > input.Length)
            {
                return false;
            }

            int startIndex = input.Length - suffix.Length;
            for (int i = 0; i < suffix.Length; i++)
            {
                if (input[startIndex + i] != suffix[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static string Substring(string input, int startIndex, int length)
        {
            // Проверка за граници на индекса
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            // Проверка за граници на дължината
            if (startIndex + length > input.Length)
            {
                length = input.Length - startIndex;
            }

            // Извличане на подниза
            char[] substringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                substringChars[i] = input[startIndex + i];
            }

            // Преобразуване на масива от символи към низ
            string extractedSubstring = new string(substringChars);

            return extractedSubstring;
        }
        public static string Trim(string input)
        {
            if (input == null)
            {
                return null;
            }

            int start = 0;
            int end = input.Length - 1;

            // Find the index of the first non-space character from the start
            while (start <= end && input[start] == ' ')
            {
                start++;
            }

            // Find the index of the first non-space character from the end
            while (end >= start && input[end] == ' ')
            {
                end--;
            }

            // Return the trimmed substring using your custom Substring implementation
            return Substring(input, start, end - start + 1);
        }


        public static int IndexOfAny(string input, char[] anyOf, int startIndex)
        {
            for (int i = startIndex; i < input.Length; i++)
            {
                char currentChar = input[i];
                bool found = false;

                // Check if the current character matches any of the characters in anyOf
                foreach (char searchChar in anyOf)
                {
                    if (currentChar == searchChar)
                    {
                        found = true;
                        break;
                    }
                }

                // If a match is found, return the current index
                if (found)
                {
                    return i;
                }
            }

            // Return -1 if none of the characters in anyOf are found
            return -1;
        }

        public static DefinedFunction SearchForFunction(string functionName, MyList<DefinedFunction> definedFunctions)
        {
            foreach (var function in definedFunctions)
            {
                if (function.Name.Equals(functionName, StringComparison.OrdinalIgnoreCase))
                {
                    return function;
                }
            }

            return null;
        }


        public static string Replace(string input, string oldValue, string newValue)
        {
            string result = "";
            int inputLength = input.Length;
            int oldValueLength = oldValue.Length;
            int currentIndex = 0;

            while (currentIndex < inputLength)
            {
                if (StartsWith(MyMethods.Substring(input, currentIndex, oldValueLength), oldValue)
                    && (currentIndex + oldValueLength == inputLength || !IsLetterOrDigit(input[currentIndex + oldValueLength])))
                {
                    // Match found, append newValue
                    result += newValue;
                    currentIndex += oldValueLength;
                }
                else
                {
                    result += input[currentIndex];
                    currentIndex++;
                }
            }

            return result;
        }
        private static bool IsLetterOrDigit(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }


        public static string[] ExtractRowValuesWithoutLastColumn(string[,] matrix, int rowIndex)
        {
            int columns = matrix.GetLength(1);
            string[] rowItems = new string[columns - 1];

            for (int i = 0; i < columns - 1; i++)
            {
                rowItems[i] = matrix[rowIndex, i];
            }

            return rowItems;
        }

        public static string JoinWithSpacesBetween(List<string> strings)
        {
            string result = "";
            for (int i = 0; i < strings.Count; i++)
            {
                if (i + 1 == strings.Count)
                {
                    result += strings[i];
                    break;
                }
                result += strings[i] + " ";
            }

            return result;
        }

        public static string InvertOperand(string operand)
        {
            if (Contains(operand, '!'))
            {
                return operand[1].ToString();
            }

            return "!" + operand;
        }

        public static bool Contains(string input, char c)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    return true;
                }
            }

            return false;
        }
        public static string Join(string[] strings)
        {
            string result = "";
            for (int i = 0; i < strings.Length; i++)
            {
                result += strings[i];
            }

            return result;
        }

        public static Stack<string[]> ReverseStack(Stack<string[]> values)
        {
            Stack<string[]> reversed = new(values.Count);

            while (values.Count != 0)
            {
                reversed.Push(values.Pop());
            }

            return reversed;
        }

        public static string GenerateOperands(int count)
        {
            string operandsList = "";

            for (int i = 0; i < count; i++)
            {
                operandsList += (char)('a' + i);

                if (i < count - 1)
                {
                    operandsList += ", ";
                }
            }

            return operandsList;
        }
    }
}
