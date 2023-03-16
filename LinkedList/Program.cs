namespace LinkedList
{
    class Program
    {
        // Where the application begins
        static void Main(string[] args) 
        {
            // Single linked list
            SingleLinkedList singleList = new SingleLinkedList();
            singleList.InsertLast(4);
            singleList.InsertLast(6);
            singleList.InsertFront(2);
            singleList.printList();
            singleList.DeleteNodebyKey(2);
            singleList.printList();
            singleList.InsertAfter(singleList.FindbyKey(4),5);
            singleList.printList();
        }
    }

    public class Node
    {
        // Fields
        private int _data;
        private Node? _next;

        // Constructors
        public Node(int d)
        {
            _data = d;
            _next = null;
        }

        // Getters and Setters
        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node? Next
        {
            get { return _next; }
            set { _next = value; }
        }

        // Finalizers
        ~Node() { }
    }

    public class SingleLinkedList
    {
        // Fields
        private Node? _head;

        // Constructors
        public SingleLinkedList()
        {
            _head = null;
        }

        // Getters and Setters
        public Node? Head
        {
            get { return _head; }
            set { _head = value; }
        }

        // Finalizer
        ~SingleLinkedList() { }

        // Methods
        public void InsertFront(int new_data)
        {
            Node new_node = new Node(new_data);
            new_node.Next = _head;
            _head = new_node;
        }

        public void InsertLast(int new_data)
        {
            Node new_node = new Node(new_data);
            if (_head == null)
            {
                _head = new_node;
            }
            else
            {
                Node? lastNode = GetLastNode();

                if (lastNode != null)
                {
                    lastNode.Next = new_node;
                }
            }
        }

        public Node? GetLastNode()
        {
            Node? temp = _head;
            while ((temp != null) && (temp.Next != null))
            {
                temp = temp.Next;
            }
            return temp;
        }

        public void InsertAfter(Node? prevNode, int newData)
        {
            if (prevNode == null)
            {
                Console.WriteLine("The given previous node Cannot be null!");
            }
            else
            {
                Node newNode = new Node(newData);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
            }
        }

        public Node? FindbyKey(int data)
        {
            Node? temp = _head;

            while (temp != null)
            {
                if (temp.Data == data)
                    return temp;
                temp = temp.Next;
            }
            return null;
        }

        public void DeleteNodebyKey(int key)
        {
            Node? temp = _head;
            Node? prev = null;

            // The key is equal to head
            if (temp != null && temp.Data == key)
            {
                _head = temp.Next;
                return;
            }
            while (temp != null && temp.Data != key)
            {
                prev = temp;
                temp = temp.Next;
            }
            // Do not find the key in the list
            if (temp == null)
            {
                return;
            }

            if (prev != null)
                prev.Next = temp.Next;
        }

        public void printList()
        {
            Node? temp = _head;
            Console.Write("The singleLinkedList: ");
            while ((temp != null))
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine("");
        }
    }
}