

public class Node {

    // Fields
    private int _data;
    private Node? _next;

    // Constructors
    public Node(int d) {
        _data = d;
        _next = null;
    }

    // Getters and Setters
    public int Data {
        get { return _data; }
        set { _data = value; }
    }

    public Node? Next {
        get { return _next; }
        set { _next = value; }
    }

    // Finalizers

}