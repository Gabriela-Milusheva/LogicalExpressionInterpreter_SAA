using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SAA.BinaryTree;
using SAA.Function;
using SAA.LogicalExpression.DEFINE;
using SAA.Utilities;
using static SAA.LogicalExpression.DEFINE.Token;

namespace SAA.BinaryTree
{
    public class TreeBuilder
    {
        public static Node BuildTree(MyList<Token> _tokens, MyList<DefinedFunction> _definedFunctions)
        {
            MyStack<Node> treeNodes = new MyStack<Node>(_tokens.Count);


            foreach (var token in _tokens)
            {
                switch (token.Type)
                {
                    case Token.TokenType.NESTED_FUNCTION:
                        {
                            string nestedFunctionName = MyMethods.Split(token.Value, '(')[0];

                            var nestedFunction = MyMethods.SearchForFunction(nestedFunctionName, _definedFunctions);

                            if (nestedFunction == null)
                            {
                                return null;
                            }

                            var functionNode = BuildTree(ConvertNotation.ToPostfix(nestedFunction.Tokens), _definedFunctions);
                            treeNodes.Push(functionNode);
                            break;
                        }
                    case Token.TokenType.LITERAL:
                        treeNodes.Push(new Node(token.Value));
                        break;
                    case Token.TokenType.NOT:
                        {
                            Node leftChild = treeNodes.Pop();
                            treeNodes.Push(new Node(token.Value, leftChild));
                            break;
                        }
                    default:
                        {
                            Node leftChild = treeNodes.Pop();
                            Node rightChild = treeNodes.Pop();
                            treeNodes.Push(new Node(token.Value, leftChild, rightChild));
                            break;
                        }
                }
            }

            Node root = treeNodes.Pop();
            return root;
        }


        public MyList<string> GetLeaves(Node? root, int count)
        {
            MyList<string> leaves = new MyList<string>(count);
            TraverseLeavesDFS(root, leaves);
            return leaves;
        }
        private void TraverseLeavesDFS(Node? node, MyList<string> leaves)
        {
            if (node != null)
            {
                if (node.leftChild == null && node.rightChild == null)
                {
                    leaves.Add(node.nodeValue);
                }
                TraverseLeavesDFS(node.leftChild, leaves);
                TraverseLeavesDFS(node.rightChild, leaves);
                
            }
        }


        public int CalculateTreeDepth(Node? node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftDepth = CalculateTreeDepth(node.leftChild);
                int rightDepth = CalculateTreeDepth(node.rightChild);

                return Math.Max(leftDepth, rightDepth) + 1;
            }
        }
      



    }
}