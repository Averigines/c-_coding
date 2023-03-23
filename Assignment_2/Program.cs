class TowerOfHanoi
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of disks: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("\nRecursive solution:");
        MoveRecursive(n, 'A', 'C', 'B');

        Console.WriteLine("\nIterative solution:");
        MoveIterative(n);

        Console.WriteLine("End of code");
    }

    static void MoveRecursive(int n, char from, char to, char aux)
    {
        if (n == 1)
        {
            Console.WriteLine($"Move disk 1 from {from} to {to}");
            return;
        }

        MoveRecursive(n - 1, from, aux, to);
        Console.WriteLine($"Move disk {n} from {from} to {to}");
        MoveRecursive(n - 1, aux, to, from);
    }

    static void MoveIterative(int n)
{
    int moves = (int)Math.Pow(2, n) - 1;
    Stack<int> A = new Stack<int>(Enumerable.Range(1, n).Reverse());
    Stack<int> B = new Stack<int>();
    Stack<int> C = new Stack<int>();

    if (n % 2 == 0)
    {
        Stack<int> temp = C;
        C = B;
        B = temp;
    }

    for (int i = 1; i <= moves; i++)
    {
        if (i % 3 == 1)
        {
                MoveDisk(A, C, 'A', 'C');
        }
        else if (i % 3 == 2)
        {
                MoveDisk(A, B, 'A', 'B');
        }
        else if (i % 3 == 0)
        {
                MoveDisk(B, C, 'B', 'C');
        }
    }
}

static void MoveDisk(Stack<int> from, Stack<int> to, char fromName, char toName)
{
    if (from.Count == 0 || (to.Count > 0 && to.Peek() < from.Peek()))
    {
        from.Push(to.Pop());
        Console.WriteLine($"Move disk {from.Peek()} from {toName} to {fromName}");
    }
    else {
        to.Push(from.Pop());
        Console.WriteLine($"Move disk {to.Peek()} from {fromName} to {toName}");
    }
}
}