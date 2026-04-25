// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static(double volume, string unit) CalculateVolume(double length, double breadth, double height)
{
    double volume = length * breadth * height;

    return (volume, "cubic units");

}
Console.WriteLine("enter a length: ");
double l = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("enter a breadth: ");
double b = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("enter a height: ");
double h = Convert.ToDouble(Console.ReadLine());

var result = CalculateVolume(l, b, h);

Console.WriteLine($"Volume = {result.volume}");

