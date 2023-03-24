# Assignment 2: Tower of Hanoi

## Main

``` c#
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

```

We call the correct function according to the input and pass the number of disks.

<br>

## Recursive

``` c#
    static void HanoiRecursive(int disk, char A, char B, char C) {
        if (disk == 1) {
            Console.WriteLine($"Move disk 1 from {A} to {C}");
            return;
        }

        HanoiRecursive(disk - 1, A, C, B);

        Console.WriteLine($"Move disk {disk} from {A} to {C}");

        HanoiRecursive(disk - 1, B, A, C);
    }

```

We pass the three pegs (A, B, C) to the function and recursively call itself, changing up the order based on the Mathematics behind the Tower of Hanoi.

<br>

## Iterative

``` c#
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
```

For the iterative approach, we create three Stacks, representing the three pegs. The content of the stacks are the disks, so we initialize stack A with all disks, represented by numbers (1 being the smallest disk). We then swap around the two empty stacks, if we have an even number of disks, since the starting move and thus every subsequent move is switched, according to the logic of the Tower of Hanoi.
The WriteASCII method then creates the ASCII-art based on the current status of the three stacks.

<br>

## MoveDisk

``` c#
    static void MoveDisk(Stack<int> from, Stack<int> to) {
        if (from.Count == 0 || (to.Count > 0 && to.Peek() < from.Peek())) {
            from.Push(to.Pop());
        }
        else {
            to.Push(from.Pop());
        }
    }
```

Here, we need to find the legal move, so we check which of the two pegs has the smaller disk. This is the disk we need to move to the other peg.