using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAA.BinaryTree;
using SAA.Function;
using SAA.Utilities;

namespace SAA.LogicalExpressionOperations.ALL
{
    public class FunctionTruthTable
    {
        private readonly TreeSolver treeSolver;

        public FunctionTruthTable()
        {
            treeSolver = new TreeSolver();
        }

        public bool[,] GenerateTruthTable(DefinedFunction function, MyList<DefinedFunction> definedFunctions)
        {
            MyList<string> operands = function.Operands;
            int numOperands = operands.Count;

            // бр.редове(комбинации)=2^бр.аргументи 
            int numRows = 1 << numOperands;

            bool[,] truthTable = new bool[numRows, numOperands + 1]; 

            for (int row = 0; row < numRows; row++)
            {
                //генерираме bool стойности за текущия ред
                string binaryString = GetBinaryValues(row, numOperands);

                for (int col = 0; col < numOperands; col++)
                {
                    truthTable[row, col] = binaryString[col] == '1';
                }
                string[] binaryArray = new string[binaryString.Length];
                for (int i = 0; i < binaryString.Length; i++)
                {
                    binaryArray[i] = binaryString[i].ToString();
                }

                bool result = treeSolver.SolveFunction(function, binaryArray, definedFunctions);

                truthTable[row, numOperands] = result;
            }

            return truthTable;
        }

        private string GetBinaryValues(int decimalValue, int numBits)
        {
            char[] binaryChars = new char[numBits];
            for (int i = numBits - 1; i >= 0; i--)
            {
                if ((decimalValue & 1) == 1)
                {
                    binaryChars[i] = '1';
                }
                else
                {
                    binaryChars[i] = '0';
                }
                decimalValue >>= 1;
            }

            return new string(binaryChars);
        }
    }

}