using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SAA.Function;
using SAA.LogicalExpression.DEFINE;
using SAA.Utilities;

namespace SAA.BinaryTree
{
    public class TreeSolver
    {
        public bool SolveFunction( DefinedFunction function, string[] argumentValues, MyList<DefinedFunction> definedFunctions)
        {


            Node root = TreeBuilder.BuildTree(ConvertNotation.ToPostfix(function.Tokens), definedFunctions);

            UpdateArgumentValues(root, function.Operands, argumentValues);

            bool result = Solve(root);

            function.AddFunctionLastBoolArguments(argumentValues); 

            return result;
        }



        public static void UpdateArgumentValues(Node node, MyList<string> operands, string[] argumentValues)
        { if (node != null && node.leftChild == null && node.rightChild == null && operands.Contains(node.nodeValue))
            {
                int index = operands.IndexOf(node.nodeValue);
                if (index < argumentValues.Length)
                {
                    node.nodeValue = argumentValues[index];
                }
            }
            else if (node.rightChild==null)
            {
                UpdateArgumentValues(node?.leftChild, operands, argumentValues);
            }
            else
            {
                UpdateArgumentValues(node?.leftChild, operands, argumentValues);
                UpdateArgumentValues(node?.rightChild, operands, argumentValues);
                
               
            }
           
        }

        public static bool Solve(Node node)
        {
            if (node.rightChild == null && node.leftChild!=null)
            {
                return node.leftChild.nodeValue != "1"; 
            }

            if (node.leftChild == null && node.rightChild == null)
            {
                return node.nodeValue == "1";
            }

            bool leftResult = Solve(node.leftChild);
            bool rightResult = Solve(node.rightChild);
            

            switch (node.nodeValue)
            {
                case "&":
                    return leftResult && rightResult;
                case "|":
                    return leftResult || rightResult;
                case "!":
                    return !leftResult;
                default:
                    return false;
            }
        }
    }
}
