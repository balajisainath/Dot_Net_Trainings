using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Trainings
{
    abstract class Operation
    {
        public abstract double Execute(double num1, double num2);
    }

    
    class AdditionOperation : Operation
    {
        public override double Execute(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    class SubtractionOperation : Operation
    {
        public override double Execute(double num1, double num2)
        {
            return num1 - num2;
        }
    }
    class MultiplicationOperation : Operation
    {
        public override double Execute(double num1,double num2)
        {
            return num1 * num2;
        }
    }
    class reminderOperation: Operation
    {
        public override double Execute(double num1, double num2)
        {
            return num1 % num2;
            
        }
    }

    class Start
    {
        static void Main()
        {
            Console.WriteLine("Select operation: 1. Add 2. Subtract 3. Multiply 4. Reminder");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter two numbers:");
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            Operation operation;
            if (choice == 1)
            {
                operation = new AdditionOperation();
            }
            else if(choice ==2)
            {
                operation = new SubtractionOperation();
            }
            else if(choice == 3)
            {
                operation = new MultiplicationOperation();
            }
            else
            {
                operation = new reminderOperation();
            }

            double result = operation.Execute(num1, num2);
            Console.WriteLine($"Result: {result}");
        }
    }
}

