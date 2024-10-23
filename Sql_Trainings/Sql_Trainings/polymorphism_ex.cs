using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    interface Shape
{
    double CalculateArea();
}


class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}


class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double CalculateArea()
    {
        return Length * Width;
    }
}

class Square : Shape
{

    public double Side { get; set; }
    public Square(double side)
    {
        Side = side;
    }
    public double CalculateArea()
    {
        return Side * Side;
    }
}

    class polymorphism_ex
    {
        static void Main()
        {
            Console.WriteLine("Choose a shape: 1. Circle 2. Rectangle 3. Square");
            int choice = int.Parse(Console.ReadLine());

        Shape shape = null;
            if (choice == 1)
            {
                Console.WriteLine("Enter radius:");
                double radius = double.Parse(Console.ReadLine());
                shape = new Circle(radius);
            }
            else if (choice ==2)
            {
                Console.WriteLine("Enter length and width:");
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                shape = new Rectangle(length, width);
            }
            else if(choice == 3)
        {
            Console.WriteLine("Enter the side of");
            double side = double.Parse(Console.ReadLine());
            shape = new Square(side);
        }
        else
        {
            Console.WriteLine("Enter the corect valid number");
        }

            double area = shape.CalculateArea();
            Console.WriteLine($"The area is: {area}");
        }
    }

