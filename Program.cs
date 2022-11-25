﻿using System;

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
        
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next);
            {
                if (rollNo == current.rollNumber)
                    return (true); /*returns true if the node is found*/
            }
            if (rollNo = LAST.rollNumber)/* If the node is present at the end*/
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
                    Console.Write(currntNode.rollNumber + "   " + currentNode.name + "\n");
                    currentNode = currentNode.next; 
                }
                Console.Write(LAST.rollNumber + "   " + LAST.name + "\n");
            }
        }


    }
}