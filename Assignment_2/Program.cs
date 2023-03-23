using System;
using System.Collections;

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
    char from = 'A';
    char aux = 'B';
    char to = 'C';

    if (n % 2 == 0)
    {
        Stack<int> temp = C;
        C = B;
        B = temp;
        char temp2 = to;
        to = aux;
        aux = temp2;
    }

    WriteASCII(A, B, C, n);
    for (int i = 1; i <= moves; i++)
    {
        if (i % 3 == 1)
        {
                MoveDisk(A, C, from, to);
                //WriteASCII(A, B, C, n);
        }
        else if (i % 3 == 2)
        {
                MoveDisk(A, B, from, aux);
                //WriteASCII(A, B, C, n);
        }
        else if (i % 3 == 0)
        {
                MoveDisk(B, C, aux, to);
                //WriteASCII(A, B, C, n);
        }
        WriteASCII(A, B, C, n);
    }
}

static void MoveDisk(Stack<int> from, Stack<int> to, char fromName, char toName)
{
    if (from.Count == 0 || (to.Count > 0 && to.Peek() < from.Peek()))
    {
        from.Push(to.Pop());
        //Console.WriteLine($"Move disk {from.Peek()} from {toName} to {fromName}");
    }
    else {
        to.Push(from.Pop());
        //Console.WriteLine($"Move disk {to.Peek()} from {fromName} to {toName}");
    }
}

static void WriteASCII(Stack<int> A, Stack<int> B, Stack<int> C, int disks) {
    List<int> ListA = A.ToList();
    List<int> ListB;
    List<int> ListC;
    if (disks % 2 == 0) {
        ListC = B.ToList();
        ListB = C.ToList();
    }
    else {
        ListB = B.ToList();
        ListC = C.ToList();
    }
    string ascii = "**";

    for (int i = 0; i < disks; i++) {
        string asciiLine = "|  ";
        if (ListA.Count() >= disks - i) {
             int valueA = ListA[0];
             ListA.RemoveAt(0);
             for (int j = 0; j < valueA; j++) {
                asciiLine += ascii;
             }
             //asciiLine += $"{valueA}";
             //Console.WriteLine($"|  {valueA}  |    |    |");
        }
        asciiLine += "  |  ";

        if (ListB.Count() >= disks - i) {
             int valueB = ListB[0];
             ListB.RemoveAt(0);
             for (int j = 0; j < valueB; j++) {
                asciiLine += ascii;
             }
             //asciiLine += $"{valueB}";
             //Console.WriteLine($"|  {valueA}  |    |    |");
        }
        
        asciiLine += "  |  ";

        if (ListC.Count() >= disks - i) {
             int valueC = ListC[0];
             //string stringB = new String("*", 5);
             ListC.RemoveAt(0);
             for (int j = 0; j < valueC; j++) {
                asciiLine += ascii;
             }
             //asciiLine += $"{valueC}";
             //Console.WriteLine($"|  {valueA}  |    |    |");
        }
        
        asciiLine += "  |";
        //Console.SetCursorPosition(Console.WindowWidth/3, Console.WindowHeight);
        Console.WriteLine(asciiLine);
        
    }
    Console.WriteLine("------------------------------------------------------------------------------");
}
}