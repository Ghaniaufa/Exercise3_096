using System;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*Creates Nodes for the circular nexted list*/
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
        
        // Add Node 
        public void addNode()
        {
            int rollNo;
            string nm;

            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter the Name of student: ");
            nm = Console.ReadLine();

            Node Newnode = new Node(); // Create new object with the new node

            //Create a list Node
            Newnode.rollNumber = rollNo;
            Newnode.name = nm;

            // if the list empty
            if (listEmpty())
            {
                Newnode.next = Newnode;
                LAST = Newnode;
            }

            //addNode start from left list
            else if (rollNo < LAST.next.rollNumber)
            {
                Newnode.next = LAST.next;
                LAST.next = Newnode;
            }
            //add node start from right list
            else if (rollNo > LAST.rollNumber)
            {
                Newnode.next = LAST.next;
                LAST.next = Newnode;
                LAST = Newnode;
            }
            // add node at the middle lit
            else
            {
                Node curr, prev;
                curr = prev = LAST.next;

                int i = 0;
                while (i < rollNo - 1)
                {
                    prev = curr;
                    curr = curr.next;
                    i++;
                }
                Newnode.next = curr;
                prev.next = Newnode;
            }
        }


        // Del Node
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = LAST.next;

            //Checking for spec inside the node at the list or not
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;

            //Procces the delete node
            if (LAST.next.rollNumber == LAST.rollNumber)
            {
                LAST.next = null;
                LAST = null;
            }
            else if (rollNo == LAST.next.rollNumber)
            {
                LAST.next = current.next;
            }
            else
            {
                LAST = LAST.next;
            }
            return true;
        }









        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next);
            {
                if (rollNo == current.rollNumber)
                    return (true); /*returns true if the node is found*/
            }

            if (rollNo == LAST.rollNumber)/* If the node is present at the end*/
                return true;
            else
                return(false);/*returns false ifthe node is not found*/
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()/*Traverse all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.Write("\nRecord in ThreadExceptionEventArgs list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "   " + currentNode.name + "\n");
                    currentNode = currentNode.next; 
                }
                Console.Write(LAST.rollNumber + "   " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + "   " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the record in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter you choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {   // add node
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {   // Checking for the records
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                // looking for the list will be deleted
                                Console.Write("\nEnter the roll number of" + "the student whos record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //Output delNode
                                {
                                    if (obj.delNode(rollNo) == false)
                                        Console.WriteLine("\nRecord not found.");
                                    else
                                        Console.WriteLine("Record with roll number " + rollNo + "deleted");
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("===================");
                                    Console.WriteLine("\nRoll Number:" + curr.rollNumber);
                                    Console.WriteLine("Name : " + curr.name);
                                    Console.WriteLine("\n==================");
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
                                Console.WriteLine("Invalid Option");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }
}