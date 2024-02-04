using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SAA.Utilities;

namespace SAA.BinaryTree
{

    public class Node
    {
        public string nodeValue;
        public Node leftChild;
        public Node rightChild;

        public string LastEvaluationResult;

        public Node(string nodeValue)
            : this(nodeValue, null, null)
        {
        }

        public Node(string nodeValue, Node leftChild)
           : this(nodeValue, leftChild, null)
        {
        }

        public Node(string nodeValue, Node leftChild, Node rightChild)
        {
            this.nodeValue = nodeValue;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
        public void SetLastEvaluationResult(string value)
        {
            LastEvaluationResult = value;
        }
        public Node GetLeftChild()
        {
            return leftChild;
        }

        public Node GetRightChild()
        {
            return rightChild;
        }

        public string GetNodeValue()
        {
            return nodeValue;
        }

     

        public override string ToString()
        {
            return ToStringRecursive(this, "");
        }

        private string ToStringRecursive(Node node, string indent)
        {
            if (node == null)
                return "";

            string result = $"{indent}{node.GetNodeValue()}\n";

            if (node.GetLeftChild() != null || node.GetRightChild() != null)
            {
                result += " @ ";
                result += ToStringRecursive(node.GetRightChild(), indent + "    ");
                result += ToStringRecursive(node.GetLeftChild(), indent + "    ");               

            }
            return result;
        }




    }
}
