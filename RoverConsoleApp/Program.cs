using RoverConsoleApp;


class Program

{
    static void Main(string[] args)
    {
        Rover rover = GetInitialPosition();
        string commands = GetCommands();

        ExecuteCommands(rover, commands);

        DisplayFinalPosition(rover);

        double distance = CalculateDistance(rover.X, rover.Y);
        Console.WriteLine($"Toplam kat edilen mesafe: {distance:F2}");
    }

    static Rover GetInitialPosition()
    {
        Console.Write("Başlangıç konumunu ve yönünü girin (örn: 4 2 N): ");
        string[] input = Console.ReadLine().Split();
        return new Rover
        {
            X = int.Parse(input[0]),
            Y = int.Parse(input[1]),
            Direction = char.Parse(input[2])
        };
    }

    static string GetCommands()
    {
        Console.Write("Komutları girin (M: İleri, L: Sol, R: Sağ): ");
        return Console.ReadLine().ToUpper();
    }

    static void ExecuteCommands(Rover rover, string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    MoveForward(rover);
                    break;
                case 'L':
                    TurnLeft(rover);
                    break;
                case 'R':
                    TurnRight(rover);
                    break;
            }
        }
    }

    static void MoveForward(Rover rover)
    {
        switch (rover.Direction)
        {
            case 'N': rover.Y++; break;
            case 'S': rover.Y--; break;
            case 'E': rover.X++; break;
            case 'W': rover.X--; break;
        }
    }

    static void TurnLeft(Rover rover)
    {
        rover.Direction = rover.Direction switch
        {
            'N' => 'W',
            'W' => 'S',
            'S' => 'E',
            'E' => 'N',
            _ => rover.Direction
        };
    }

    static void TurnRight(Rover rover)
    {
        rover.Direction = rover.Direction switch
        {
            'N' => 'E',
            'E' => 'S',
            'S' => 'W',
            'W' => 'N',
            _ => rover.Direction
        };
    }

    static void DisplayFinalPosition(Rover rover)
    {
        Console.WriteLine($"Rover'ın son konumu: {rover.X} {rover.Y} {rover.Direction}");
    }

    static double CalculateDistance(int x, int y)
    {
        return Math.Sqrt(x * x + y * y);
    }
}