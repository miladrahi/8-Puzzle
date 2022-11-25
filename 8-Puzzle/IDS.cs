using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle
{
    class NodeIds
    {
        private Int16[,] PuzzleClass;
        private UInt64 NodeNumber;
        private UInt32 NodeDepth;
        private string ActionClass;
        private NodeIds Next;
        private NodeIds Back;
        private NodeIds Parent;
        public NodeIds()
        {
            PuzzleClass = null;
            ActionClass = null;
            Next = null;
            Parent = null;
        }
        //********************* 
        public NodeIds(Int16[,] element)
        {
            PuzzleClass = element;
            ActionClass = null;
            Next = null;
            Parent = null;
        }
        //********************
        public NodeIds(Int16[,] element, string act, NodeIds prnt)
        {
            PuzzleClass = element;
            ActionClass = act;
            Next = null;
            Parent = prnt;
        }
        //********************
        public Int16[,] PuzzleCLASS
        {
            get
            {
                return PuzzleClass;
            }
            set
            {
                PuzzleClass = value;
            }

        }
        //*******************
        public string ActionCLASS
        {
            get
            {
                return ActionClass;
            }
            set
            {
                ActionClass = value;
            }

        }
        //*******************
        public NodeIds NEXT
        {
            get
            {
                return Next;
            }
            set
            {
                Next = value;
            }

        }
        //*******************
        public NodeIds BACK
        {
            get
            {
                return Back;
            }
            set
            {
                Back = value;
            }

        }
        //*******************
        public NodeIds PARENT
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value;
            }

        }
        //*******************
        public UInt64 NodeNUMBER
        {
            get
            {
                return NodeNumber;
            }
            set
            {
                NodeNumber = value;
            }

        }
        //*******************
        public UInt32 NodeDEPTH
        {
            get
            {
                return NodeDepth;
            }
            set
            {
                NodeDepth = value;
            }

        }

    }//end of class NodeIds

    //*************************************

    class Stack
    {
        private static NodeIds Top;
        public static UInt64 count = 0;

        public Stack() { }

        //*******************
        public void Push(Int16[,] pzl, string act, NodeIds parent)
        {
            NodeIds newNode = new NodeIds(pzl, act, parent);
            if (Top == null)
            {
                newNode.NodeDEPTH = 0;
                Top = newNode;
                newNode.NodeNUMBER = count;

            }
            else
            {
                Top.NEXT = newNode;
                newNode.BACK = Top;
                newNode.NodeDEPTH = newNode.PARENT.NodeDEPTH + 1;
                newNode.NodeNUMBER = count;
                Top = Top.NEXT;
            }
            count++;
        }
        //*******************
        public NodeIds Pop()
        {
            if (Top == null)
            {
                throw new Exception("Stack is Empty");
            }
            NodeIds result = Top;

            if (Top.BACK == null)
                Top = null;
            else
                Top = Top.BACK;

            return result;
        }
        //*******************
        public NodeIds Peek()
        {
            if (Top == null)
            {
                throw new Exception("Stack is Empty");
            }
            NodeIds result = Top;
            return result;
        }

        //*******************
        public void Clear()
        {        
            Top = null;
        }
        //*******************
        public NodeIds TOP
        {
            get
            {
                return Top;
            }
            set
            {
                Top = value;
            }
        }

    }//end of class Stack

    //*****************************************************

    class IDS
    {
        Stack stack = new Stack();
        public Int16[,] puzzleIDS = new Int16[3, 3];
        public List<string> PathList = new List<string>();
        public List<UInt64> NodeNumber = new List<UInt64>();
        public int i = 0, j = 0;

        //*****************************************************

        public void PuzzleArrayFunc(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7, Button btn8, Button btn9)
        {

            if (btn1.Text == "")
            {
                puzzleIDS[0, 0] = 0;
            }
            else
            {
                puzzleIDS[0, 0] = Convert.ToInt16(btn1.Text);
            }

            if (btn2.Text == "")
            {
                puzzleIDS[0, 1] = 0;
            }
            else
            {
                puzzleIDS[0, 1] = Convert.ToInt16(btn2.Text);
            }

            if (btn3.Text == "")
            {
                puzzleIDS[0, 2] = 0;
            }
            else
            {
                puzzleIDS[0, 2] = Convert.ToInt16(btn3.Text);
            }

            if (btn4.Text == "")
            {
                puzzleIDS[1, 0] = 0;
            }
            else
            {
                puzzleIDS[1, 0] = Convert.ToInt16(btn4.Text);
            }

            if (btn5.Text == "")
            {
                puzzleIDS[1, 1] = 0;
            }
            else
            {
                puzzleIDS[1, 1] = Convert.ToInt16(btn5.Text);
            }

            if (btn6.Text == "")
            {
                puzzleIDS[1, 2] = 0;
            }
            else
            {
                puzzleIDS[1, 2] = Convert.ToInt16(btn6.Text);
            }

            if (btn7.Text == "")
            {
                puzzleIDS[2, 0] = 0;
            }
            else
            {
                puzzleIDS[2, 0] = Convert.ToInt16(btn7.Text);
            }

            if (btn8.Text == "")
            {
                puzzleIDS[2, 1] = 0;
            }
            else
            {
                puzzleIDS[2, 1] = Convert.ToInt16(btn8.Text);
            }

            if (btn9.Text == "")
            {
                puzzleIDS[2, 2] = 0;
            }
            else
            {
                puzzleIDS[2, 2] = Convert.ToInt16(btn9.Text);
            }


            stack.Push(puzzleIDS, null, null);
        }

        //*****************************************************
        public bool Goal(Int16[,] puzzleArray)
        {
            i++;
            if (puzzleArray[0, 0] == 1 &&
                     puzzleArray[0, 1] == 2 &&
                     puzzleArray[0, 2] == 3 &&
                     puzzleArray[1, 0] == 4 &&
                     puzzleArray[1, 1] == 5 &&
                     puzzleArray[1, 2] == 6 &&
                     puzzleArray[2, 0] == 7 &&
                     puzzleArray[2, 1] == 8 &&
                     puzzleArray[2, 2] == 0)
            {
                return true;
            }

            return false;

        }

        //*****************************************************
        public NodeIds IdsSearchFunction()
        {

            UInt32 DepthLimit = 0;
            NodeIds pz;
            pz = stack.Peek();
            while (Goal(pz.PuzzleCLASS) == false)
            {

                if (pz.NodeDEPTH < DepthLimit)
                {
                    addNode(pz);
                    pz = stack.Pop();
                }
                else if (pz.NodeDEPTH >= DepthLimit)
                {
                    pz = stack.Pop();

                    if (pz.BACK == null)
                    {
                        Stack.count = 0;
                        DepthLimit++;
                        stack.Clear();
                        stack.Push(puzzleIDS, null, null);
                        pz = stack.Peek();
                        i = 0;
                    }

                }
            }

            return pz;
        }

        //*****************************************************

        public void addNode(NodeIds puzzle)
        {
            string id = SearchArray((Int16[,])puzzle.PuzzleCLASS);
            Int16 temp;
            switch (id)
            {
                case "00":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Down", puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[0, 0];
                        pz1[0, 0] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Right", puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[0, 0];
                        pz1[0, 0] = temp;

                        break;
                    }
                case "01":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Down", puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[0, 1];
                        pz1[0, 1] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Left", puzzle);
                        temp = pz1[0, 0];
                        pz1[0, 0] = pz1[0, 1];
                        pz1[0, 1] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Right", puzzle);
                        temp = pz1[0, 2];
                        pz1[0, 2] = pz1[0, 1];
                        pz1[0, 1] = temp;

                        break;
                    }
                case "02":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Down", puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[0, 2];
                        pz1[0, 2] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Left", puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[0, 2];
                        pz1[0, 2] = temp;

                        break;
                    }
                case "10":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Down", puzzle);
                        temp = pz1[2, 0];
                        pz1[2, 0] = pz1[1, 0];
                        pz1[1, 0] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Up", puzzle);
                        temp = pz1[0, 0];
                        pz1[0, 0] = pz1[1, 0];
                        pz1[1, 0] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Right", puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[1, 0];
                        pz1[1, 0] = temp;

                        break;
                    }
                case "11":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Down", puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[1, 1];
                        pz1[1, 1] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Up", puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[1, 1];
                        pz1[1, 1] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Left", puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[1, 1];
                        pz1[1, 1] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Right", puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[1, 1];
                        pz1[1, 1] = temp;



                        break;
                    }
                case "12":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Down", puzzle);
                        temp = pz1[2, 2];
                        pz1[2, 2] = pz1[1, 2];
                        pz1[1, 2] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Up", puzzle);
                        temp = pz1[0, 2];
                        pz1[0, 2] = pz1[1, 2];
                        pz1[1, 2] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Left", puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[1, 2];
                        pz1[1, 2] = temp;

                        break;
                    }
                case "20":
                    {

                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Up", puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[2, 0];
                        pz1[2, 0] = temp;

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Right", puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[2, 0];
                        pz1[2, 0] = temp;

                        break;
                    }
                case "21":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Up", puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[2, 1];
                        pz1[2, 1] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Left", puzzle);
                        temp = pz1[2, 0];
                        pz1[2, 0] = pz1[2, 1];
                        pz1[2, 1] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Right", puzzle);
                        temp = pz1[2, 2];
                        pz1[2, 2] = pz1[2, 1];
                        pz1[2, 1] = temp;

                        break;
                    }
                case "22":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Up", puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[2, 2];
                        pz1[2, 2] = temp;


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        stack.Push(pz1, "Left", puzzle);

                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[2, 2];
                        pz1[2, 2] = temp;

                        break;
                    }
            }
        }

        //*****************************************************

        private Int16[,] Clone(Int16[,] pz1, NodeIds puzzle)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pz1[i, j] = puzzle.PuzzleCLASS[i, j];
                }
            }
            return pz1;
        }

        //*****************************************************

        public string SearchArray(Int16[,] puzzleSearch)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzleSearch[i, j] == 0)
                        return i.ToString() + j.ToString();
                }
            }
            return "";
        }

        //*****************************************************

        public List<string> PathFinder(NodeIds node)
        {
            while (node.PARENT != null)
            {
                PathList.Add(node.ActionCLASS);
                NodeNumber.Add(node.NodeNUMBER);
                node = node.PARENT;
                j++;
            }

            return PathList;
        }

        //*****************************************************

        public int DepthFinder()
        {
            return j;
        }


    }
}