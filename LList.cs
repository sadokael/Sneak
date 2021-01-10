using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneak
{
    public class LList
    {  
            private Node head;
            private Node curr;
           
        //count para ClearList()
            public int count;
            public LList()
            {
                head = new Node();
                head.before = curr;
                curr = head;
                curr.next = head;
            }
        public void AddNode() 
        {
            Node newNode = new Node();
            newNode.next = curr;
            curr.before = newNode;
            curr = newNode;           
            count++;
        }

        public void ClearList()
        {
            while (count > 1)
            {
                do
                {
                    head.before = head.before.before;
                } while (head.before != null);
                count--;
            }
        }

        public Node getNext() => curr.next;
        public Node getBefore() => curr.before;
        public Node getHead() => head;
        public Node getCurr() => curr;
        public int getX() => curr.X;
        public int setX(int n) => curr.X = n;
        public void incX() => curr.X++;
        public void decX() => curr.X--;
        public int getY() => curr.Y;
        public int setY(int n) => curr.Y = n;
        public void incY() => curr.Y++;
        public void decY() => curr.Y--;
    }
    public class Node 
    {
        public Node next;
        public Node before;
        public int X { get; set; }
        public int Y { get; set; }
        public Node()
        {
            next = null;
            before = null;
            X = 0;
            Y = 0;   
        }        
    }
}
