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

        Console.ReadLine();
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
        char from = 'A', to = 'C', aux = 'B';

        if (n % 2 == 0)
        {
            char temp = to;
            to = aux;
            aux = temp;
        }

        for (int i = 1; i <= moves; i++)
        {
            if (i % 3 == 1)
            {
                Console.WriteLine($"Move disk {DiskToMove(i)} from {from} to {to}");
                MoveDisk(ref from, ref to, ref aux);
            }
            else if (i % 3 == 2)
            {
                Console.WriteLine($"Move disk {DiskToMove(i)} from {from} to {aux}");
                MoveDisk(ref from, ref aux, ref to);
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine($"Move disk {DiskToMove(i)} from {aux} to {to}");
                MoveDisk(ref aux, ref to, ref from);
            }
        }
    }

    static void MoveDisk(ref char from, ref char to, ref char aux)
    {
        char temp = to;
        to = aux;
        aux = from;
        from = temp;
    }

    static int DiskToMove(int move)
    {
        int disk = 1;
        while (move % 2 == 0)
        {
            move /= 2;
            disk++;
        }
        return disk;
    }
}