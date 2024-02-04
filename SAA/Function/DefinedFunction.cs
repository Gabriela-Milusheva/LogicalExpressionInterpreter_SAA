using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SAA.BinaryTree;
using SAA.LogicalExpression.DEFINE;
using SAA.Utilities;

namespace SAA.Function
{
    public class DefinedFunction
    {
         private readonly string Function;

        public string[] FunctionParts { get; private set; }
        public string[] Part1 { get; private set; }
        public string Name { get; private set; }
        public MyList<string> Operands { get; private set; }
        public string Body { get; private set; }
        public MyList<Token> Tokens { get; private set; }

        public string[] LastBoolArguments { get; private set; }

        public string Definition
        {
            get { return $"{Name}({string.Join(", ", Operands)}) : {Body}"; }
        }

        public DefinedFunction(string function)
        {
            Function = function;
            Initialize();
        }

        private void Initialize()
        {
            FunctionParts = GetFunctionParts(Function);
            Part1 = MyMethods.SeparateNameFromArguments(FunctionParts[0]);
            Name = Part1[0];
            GetFunctionOperands(Part1[1]);
            Body = MyMethods.RemoveChar(FunctionParts[1], ' ');
            Tokens = SplitIntoTokens.GetTokens(Body);


        }
        private string[] GetFunctionParts(string function)
        {
            return FunctionParts = MyMethods.SplitIntoParts(function, 2, ':');
        }
        private void GetFunctionOperands(string part1)
        {
            string[] operandsArray = MyMethods.Split(part1, ',');
            Operands = new MyList<string>(operandsArray.Length);

            foreach (string operand in operandsArray)
            {
                Operands.Add(MyMethods.TrimStartAndEnd(operand, ' '));
            }
        }

        public void AddFunctionLastBoolArguments(string[] values)
        {
            LastBoolArguments = values;
        }

        public override string ToString()
        {
            return $"{Definition}";
        }


    }
}
