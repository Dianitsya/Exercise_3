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
            Node previous, current;
            previous = LAST;
            current = LAST;
            while ((current != null) && (rollNo >= current.rollNumber))
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*New node will be placed between previous and current*/
            newNode.next = current;
            previous.next = newNode;
        }
        /*Method to remove a specific Node in the list*/
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            /* /*check whether the node in question is on the list or not*/
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)
                LAST = LAST.next;
            return true;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current) /*Search for the specified node*/
        {
            previous = LAST;
            current = LAST;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);/*returns false if the node is not found*/
            else
                return (true);
        }
        /*Method to visit and read the contents of the list*/
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nList Empty. \n");
            else
            {
                Console.WriteLine("\nThe data in the list is : \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
                Console.WriteLine();
            }
        }
        public bool ListEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void firstNode()
        {
            if (ListEmpty())
                Console.WriteLine("\n List is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + "     " + LAST.next.name);
        }
        class Program
        {
            static void Main(string[] args)
            {
                CircularList obj = new CircularList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("\n 1. Add a record to the list");
                        Console.WriteLine("\n 2. Delete a record from the list");
                        Console.WriteLine("\n 3. View all the record in the list");
                        Console.WriteLine("\n 4. Search for a record in the list ");
                        Console.WriteLine("\n 5. Display the first record in the list");
                        Console.WriteLine("\n 6. Exit");
                        Console.Write("\n Enter your choice (1-6): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.ListEmpty())
                                    {
                                        Console.WriteLine("\nList Kosong");
                                        break;
                                    }
                                    Console.Write("\n Enter the roll number of the student: ");
                                    int rollNo = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(rollNo) == false)
                                        Console.WriteLine("Record not found");
                                    else
                                        Console.Write("Record with roll number " + rollNo + " deleted\n");
                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.ListEmpty() == true)
                                    {
                                        Console.WriteLine("\nList id Empty");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nEnter the rol number of the student whoses rocord you want to search:");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nRecord not found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number" + current.rollNumber);
                                        Console.WriteLine("\nName:" + current.name);
                                    }
                                }
                                break;
                            case '5':
                                {
                                    obj.firstNode();
                                }
                                break;
                            case '6':
                                return;
                            default:
                                {
                                    Console.WriteLine("\n Invalid option");
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Check for the values entered");
                    }
                }
            }
        }
    }
}

