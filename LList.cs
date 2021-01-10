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
           
            public int count;

            public LList()
            {
                head = new Node();
                
                curr = head;
            }
        public void AddNode() 
        {
            Node newNode = new Node();
            /*
            newNode.next = head.next;
            head.next = newNode;
            */
            curr.next = newNode;
            curr = newNode;
            count++;
        }

        public void ClearList()
        {
            while (count > 1)
            {
                head.next = head.next.next;
                count--;
            }
        }

        
        public Node getNext() => head.next;


    }
    public class Node 
    {

        public Node next;
        public int X { get; set; }
        public int Y { get; set; }

        public Node()
        {
            next = null;
            X = 0;
            Y = 0;
        }
        
    }
}
