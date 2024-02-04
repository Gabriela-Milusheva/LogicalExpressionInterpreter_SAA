using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAA.BinaryTree;

namespace SAA
{
    public partial class TreeForm : Form
    {
        public TreeForm()
        {
            InitializeComponent();
        }

        public void UpdatePictureBox(Bitmap bitmap)
        {
            treePictureBox.Image = bitmap;
        }


        public void DrawTree(Graphics graphics, Node node, int x, int y, int currentEdgeLength, int treeDepth)
        {
            int nodeSize = 40;
            Brush nodeBrush = Brushes.LightSteelBlue;
            Pen edgePen = new Pen(Color.SteelBlue, 2); 
            Font boldFont = new Font("Bookman Old Style", 10, FontStyle.Bold); 

            int nodeX = x;
            int nodeY = y;

            nodeY -= nodeSize / 2;

            graphics.FillEllipse(nodeBrush, nodeX - nodeSize / 2, nodeY - nodeSize / 2, nodeSize, nodeSize);
            graphics.DrawEllipse(edgePen, nodeX - nodeSize / 2, nodeY - nodeSize / 2, nodeSize, nodeSize);

            float centerX = nodeX;
            float centerY = nodeY;

            SizeF textSize = graphics.MeasureString(node.GetNodeValue(), boldFont);

            float textX = centerX - textSize.Width / 2;
            float textY = centerY - textSize.Height / 2;

            graphics.DrawString(node.GetNodeValue(), boldFont, Brushes.SteelBlue, textX, textY);

            if (node.GetLeftChild() != null)
            {
                int leftChildX = x - currentEdgeLength / 4 - treeDepth * nodeSize / 4;
                int leftChildY = y + 150;

                leftChildY -= nodeSize / 2;

                edgePen = new Pen(Color.SteelBlue, 2);
                graphics.DrawLine(edgePen, nodeX, nodeY + nodeSize / 2, leftChildX, leftChildY - nodeSize);

                DrawTree(graphics, node.GetLeftChild(), leftChildX, leftChildY, currentEdgeLength / 2, treeDepth - 1);
            }

            if (node.GetRightChild() != null)
            {
                int rightChildX = x + currentEdgeLength / 4 + treeDepth * nodeSize / 4;
                int rightChildY = y + 150;

                rightChildY -= nodeSize / 2;

                edgePen = new Pen(Color.SteelBlue, 2);
                graphics.DrawLine(edgePen, nodeX, nodeY + nodeSize / 2, rightChildX, rightChildY - nodeSize);

                DrawTree(graphics, node.GetRightChild(), rightChildX, rightChildY, currentEdgeLength / 2, treeDepth - 1);
            }
        }


    }
}
