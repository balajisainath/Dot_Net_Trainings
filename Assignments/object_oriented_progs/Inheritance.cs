using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


     class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Some animal sound");
        }
    }
    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog speaking");
        }
    }
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat speaking");
        }
    }

    class Crow : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("crow speaking");
        }
    }

    class Inheritance
    {
        public static void Main()
        {
            Console.WriteLine("Choose an animal: 1. Dog 2. Cat 3. Crow");
            int choice = int.Parse(Console.ReadLine());

            Animal animal=null;
            if (choice == 1)
            {
                animal = new Dog();
            }
            else if (choice == 2)
            {
                animal = new Cat();
            }
            else if (choice ==3)
            {
                animal = new Crow();
            }
            else
            {
                Console.WriteLine("please choose the correct number from given list");
            }


            animal.MakeSound();
        }

    }

