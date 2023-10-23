// See https://aka.ms/new-console-template for more information
// if statement


Console.WriteLine("Enter a number between 0 and 9");
int x = Convert.ToInt32(Console.ReadLine());
int y = 0;
while (x > 0)
{
    if (x! < 9)
    {
        y = x switch
        {
            // till 10
            0 => 1,
            1 => 2,
            2 => 3,
            3 => 4,
            4 => 5,
            5 => 6,
            6 => 7,
            7 => 8,
            8 => 9,
            9 => 10,
            _ => 0
        };

        Console.WriteLine($"The value of y is {y}");
        Console.WriteLine("Enter another number between 0 and 9");
        x = Convert.ToInt32(Console.ReadLine());
    }
    else
    {
        Console.WriteLine("The number is greater than 9");
        break;
    }
}