using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _8_Puzzle
{
    class Node
    {
        private Int16[,] PuzzleClass;
        private UInt64 NodeNumber;
        private string ActionClass;
        private Node Next;
        private Node Parent;
        public Node()
        {
            PuzzleClass = null;
            ActionClass = null;
            Next = null;
            Parent = null;
        }
        //********************* 
        public Node(Int16[,] element)
        {
            PuzzleClass = element;
            ActionClass = null;
            Next = null;
            Parent = null;
        }
        //********************
        public Node(Int16[,] element, string act, Node prnt)
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
        //*********************
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
        //*********************
        public Node NEXT
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
        //*********************
        public Node PARENT
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
        //*********************
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

    }//end of class Node

    //*****************************************************

    class Queue
    {
        private static Node rear;
        private static Node front;
        public static UInt64 count = 0;

        public Queue() { }

        public void Enqueue(Int16[,] pzl, string act, Node parent)
        {
            Node newNode = new Node(pzl, act, parent);
            if (rear == null)
            {
                front = newNode;
                newNode.NodeNUMBER = count;
                rear = front;

            }
            else
            {
                rear.NEXT = newNode;
                newNode.NodeNUMBER = count;
                rear = rear.NEXT;
            }
            count++;
        }
        public Node Dequeue()
        {
            if (front == null)
            {
                throw new Exception("Queue is Empty");
            }
            Node result = front;
            front = front.NEXT;
            return result;
        }
       
        public Node Peek()
        {
            if (front == null)
            {
                throw new Exception("Queue is Empty");
            }
            Node result = front;
            return result;
        }

        public void Clear()
        {
            front = rear = null;
            
        }

        public Node Front
        {
            get
            {
                return front;
            }
            set
            {
                front = value;
            }

        }
        public Node Rear
        {
            get
            {
                return rear;
            }
            set
            {
                rear = value;
            }

        }

    }//end of class Queue

    //*****************************************************

    class BfsPointer
    {
        Queue queue = new Queue();
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


            queue.Enqueue(puzzleIDS, null, null);
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

        public Node bfsPointerSearch()
        {
            Node pz;
            pz = queue.Peek();
            while (Goal(pz.PuzzleCLASS) == false)
            {
                addNode(pz);
                pz = queue.Dequeue();
                
            }

            return pz;

        }

        //*****************************************************

        public void addNode(Node puzzle)
        {
            string id = SearchArray((Int16[,])puzzle.PuzzleCLASS);
            Int16 temp;
            switch (id)
            {
                case "00":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[0, 0];
                        pz1[0, 0] = temp;
                        queue.Enqueue(pz1, "Down", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[0, 0];
                        pz1[0, 0] = temp;
                        queue.Enqueue(pz1, "Right", puzzle);

                        break;
                    }
                case "01":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[0, 1];
                        pz1[0, 1] = temp;
                        queue.Enqueue(pz1, "Down", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 0];
                        pz1[0, 0] = pz1[0, 1];
                        pz1[0, 1] = temp;
                        queue.Enqueue(pz1, "Left", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 2];
                        pz1[0, 2] = pz1[0, 1];
                        pz1[0, 1] = temp;
                        queue.Enqueue(pz1, "Right", puzzle);

                        break;
                    }
                case "02":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[0, 2];
                        pz1[0, 2] = temp;
                        queue.Enqueue(pz1, "Down", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[0, 2];
                        pz1[0, 2] = temp;
                        queue.Enqueue(pz1, "Left", puzzle);

                        break;
                    }
                case "10":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 0];
                        pz1[2, 0] = pz1[1, 0];
                        pz1[1, 0] = temp;
                        queue.Enqueue(pz1, "Down", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 0];
                        pz1[0, 0] = pz1[1, 0];
                        pz1[1, 0] = temp;
                        queue.Enqueue(pz1, "Up", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[1, 0];
                        pz1[1, 0] = temp;
                        queue.Enqueue(pz1, "Right", puzzle);

                        break;
                    }
                case "11":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        queue.Enqueue(pz1, "Down", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        queue.Enqueue(pz1, "Up", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        queue.Enqueue(pz1, "Left", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        queue.Enqueue(pz1, "Right", puzzle);



                        break;
                    }
                case "12":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 2];
                        pz1[2, 2] = pz1[1, 2];
                        pz1[1, 2] = temp;
                        queue.Enqueue(pz1, "Down", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 2];
                        pz1[0, 2] = pz1[1, 2];
                        pz1[1, 2] = temp;
                        queue.Enqueue(pz1, "Up", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[1, 2];
                        pz1[1, 2] = temp;
                        queue.Enqueue(pz1, "Left", puzzle);

                        break;
                    }
                case "20":
                    {

                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[2, 0];
                        pz1[2, 0] = temp;
                        queue.Enqueue(pz1, "Up", puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[2, 0];
                        pz1[2, 0] = temp;
                        queue.Enqueue(pz1, "Right", puzzle);

                        break;
                    }
                case "21":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[2, 1];
                        pz1[2, 1] = temp;
                        queue.Enqueue(pz1, "Up", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 0];
                        pz1[2, 0] = pz1[2, 1];
                        pz1[2, 1] = temp;
                        queue.Enqueue(pz1, "Left", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 2];
                        pz1[2, 2] = pz1[2, 1];
                        pz1[2, 1] = temp;
                        queue.Enqueue(pz1, "Right", puzzle);

                        break;
                    }
                case "22":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[2, 2];
                        pz1[2, 2] = temp;
                        queue.Enqueue(pz1, "Up", puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[2, 2];
                        pz1[2, 2] = temp;
                        queue.Enqueue(pz1, "Left", puzzle);

                        break;
                    }
            }
        }

        //*****************************************************

        private Int16[,] Clone(Int16[,] pz1, Node puzzle)
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

        public List<string> PathFinder(Node node)
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
        public int DepthFinder()
        {
            return j;
        }

        //*****************************************************

        bool SimilarFinder(Int16[,] pzl)
        {

            Node current = queue.Front;
            while (current != null)
            {
                if (SimilarArray(pzl, current.PuzzleCLASS))
                {
                    return false;
                }
                current = current.NEXT;
            }
            return true;
        }

        //*****************************************************

        bool SimilarArray(Int16[,] pz1, Int16[,] pz2)
        {
            int Count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pz1[i, j] == pz2[i, j])
                        Count++;
                }
            }

            if (Count == 9)
                return true;

            return false;
        }
    }
}