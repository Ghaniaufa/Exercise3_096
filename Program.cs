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
    }
}