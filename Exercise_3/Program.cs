using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public void addNode()/*Method for adding a Node to the list */
        {
            int rollNo;
            string nm;
            Console.WriteLine("\nEnter the roll Number of the student : ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the roll Name of the student : ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.rollNumber = rollNo;
            newNode.name = nm;

            //if the node to be inserted is the first node
            if (LAST == null || rollNo <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNo == LAST.rollNumber))
                {
                    Console.WriteLine("\n Duplicate number not allowed");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            /*Find the location of the new Node in the list*/
            Node previousious, currentent;
            previousious = LAST;
            currentent = LAST;
            while ((currentent != null) && (rollNo >= currentent.rollNumber))
            {
                if (rollNo == currentent.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previousious = currentent;
                currentent = currentent.next;
            }
            /*New node will be placed between previousious and currentent*/
            newNode.next = currentent;
            previousious.next = newNode;
        }
        /*Method to remove a specific Node in the list*/
        public bool delNode(int rollNo)
        {
            Node previousious, currentent;
            previousious = currentent = null;
            /* /*check whether the node in question is on the list or not*/
            if (Search(rollNo, ref previousious, ref currentent) == false)
                return false;
            previousious.next = currentent.next;
            if (currentent == LAST)
                LAST = LAST.next;
            return true;
        }
        
            }
        }
    }
}

