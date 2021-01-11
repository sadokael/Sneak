namespace Sneak
{
    public class LList
    {
        public Node head;
        
  
        public LList()
        {
            head = new Node();                            
            
        }
       

    }
    public class Node 
    {
        public Node next;
        public Circle body;
        
        public Node()
        {
            next = null;
            body = new Circle();
        }        
    }
}
