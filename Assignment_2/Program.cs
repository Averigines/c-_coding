class TowerOfHanoi {

    static void Main(string[] args) {

        if (args[1] == "-Recursive") {
            int disks = int.Parse(args[2]);
            Console.WriteLine("\nRecursive solution:");
            HanoiRecursive(disks, 'A', 'B', 'C');
        }

        if (args[1] == "-Iterative") {
            int disks = int.Parse(args[2]);
            Console.WriteLine("\nIterative solution:");
            HanoiIterative(disks);
        }
    }

    static void HanoiRecursive(int disk, char A, char B, char C) {
        if (disk == 1) {
            Console.WriteLine($"Move disk 1 from {A} to {C}");
            return;
        }

        HanoiRecursive(disk - 1, A, C, B);

        Console.WriteLine($"Move disk {disk} from {A} to {C}");

        HanoiRecursive(disk - 1, B, A, C);
    }

    static void HanoiIterative(int disks) {
        int moves = (int)Math.Pow(2, disks) - 1;

        Stack<int> A = new Stack<int>(Enumerable.Range(1, disks).Reverse());
        Stack<int> B = new Stack<int>();
        Stack<int> C = new Stack<int>();

        if (disks % 2 == 0) {
            Stack<int> temp = C;
            C = B;
            B = temp;
        }

        WriteASCII(A, B, C, disks);

        for (int i = 1; i <= moves; i++) {
            if (i % 3 == 1) {
                    MoveDisk(A, C);
            }
            else if (i % 3 == 2) {
                    MoveDisk(A, B);
            }
            else if (i % 3 == 0) {
                    MoveDisk(B, C);
            }
            WriteASCII(A, B, C, disks);
        }
    }

    static void MoveDisk(Stack<int> from, Stack<int> to) {
        if (from.Count == 0 || (to.Count > 0 && to.Peek() < from.Peek())) {
            from.Push(to.Pop());
        }
        else {
            to.Push(from.Pop());
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

        string symbol = "**";
        string spacesIfEmpty = "";
        for (int i = 0; i < disks; i++) {
            spacesIfEmpty += "  ";
        }

        Console.WriteLine();

        for (int i = 0; i < disks; i++) {

            string output = "|  ";

            if (ListA.Count() >= disks - i) {
                output += JoinOutput(ListA, disks, symbol);
            }
            else {
                output += spacesIfEmpty;
            }

            output += "  |  ";

            if (ListB.Count() >= disks - i) {
                output += JoinOutput(ListB, disks, symbol);
            }
            else {
                output += spacesIfEmpty;
            }

            output += "  |  ";

            if (ListC.Count() >= disks - i) {
                output += JoinOutput(ListC, disks, symbol);
            }
            else {
                output += spacesIfEmpty;
            }
            
            output += "  |";
            Console.WriteLine(output);
            
        }
        Console.WriteLine("------------------------------------------------------------------------------");
    }

    static string JoinOutput(List<int> currPeg, int disks, string symbol) {

        string output = "";
        int value = currPeg[0];
        currPeg.RemoveAt(0);
        for (int j = 0; j < disks - value; j++) {
            output += " ";
        }
        for (int j = 0; j < value; j++) {
            output += symbol;
        }
        for (int j = 0; j < disks - value; j++) {
            output += " ";
        }
        return output;
    }
}