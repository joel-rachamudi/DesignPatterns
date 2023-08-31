using System;
namespace CompositeDesignPattern
{
    // The Leaf class represents the end objects. 
    // A leaf can't have any children.
    // The Leaf object is the Object which does the actual work
    public class Leaf : IComponent
    {
        public int Price { get; set; }
        public string Name { get; set; }

        public Leaf(string name, int price)
        {
            this.Price = price;
            this.Name = name;
        }

        public void DisplayPrice()
        {
            Console.WriteLine($"\tComponent Name: {Name} and Price: {Price}");
        }
    }
}
using System.Collections.Generic;
namespace CompositeDesignPattern
{
    // The Composite class represents the complex components that have children. 
    // The Composite objects delegate the actual work to their children and then combine the result.
    public class Composite : IComponent
    {
        public string Name { get; set; }

        //The Object is used to hold all the child components of a composite components
        List<IComponent> components = new List<IComponent>();

        //The Constructor takes the Composite name as the input parameter
        public Composite(string name)
        {
            this.Name = name;
        }

        //The following Method is used to add Child Components inside the Composite Component
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        //Display the Price of Composite Components
        public void DisplayPrice()
        {
            foreach (var item in components)
            {
                //Delegates the work to the actual leaf object or child components
                item.DisplayPrice();
            }
        }
    }
}

using System;
namespace CompositeDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            // The client code works with all of the components (Both Leaf and Composite) via the base interface i.e. IComponent.
            // IComponent means the class that implements the IComponent Interface

            //Creating Leaf Objects or you can say child objects
            IComponent hardDisk = new Leaf("Hard Disk", 2000);
            IComponent ram = new Leaf("RAM", 3000);
            IComponent cpu = new Leaf("CPU", 2000);
            IComponent mouse = new Leaf("Mouse", 2000);
            IComponent keyboard = new Leaf("Keyboard", 2000);

            //Creating Composite Objects
            Composite motherBoard = new Composite("MotherBoard");
            Composite cabinet = new Composite("Cabinet");
            Composite peripherals = new Composite("Peripherals");
            Composite computer = new Composite("Computer");

            //Creating Tree Structure i.e. Adding Child Components inside the Composite Component
            //Adding CPU and RAM in Mother Board
            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);

            //Adding Mother Board and Hard Disk in Cabinet
            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);

            //Adding Mouse and Keyboard in peripherals
            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);

            //Adding Cabinet and Peripherals in Computer
            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);

            //To Display the Price of the Computer i.e. it will display the Price of all components
            Console.WriteLine("Price of Computer Composite Components");
            computer.DisplayPrice();

            //To display the Price of the Keyboard
            Console.WriteLine("\nPrice of Keyboard Child or Leaf Component:");
            keyboard.DisplayPrice();
            
            //To display the Price of the Cabinet
            Console.WriteLine("\nPrice of Cabinet Composite Component:");
            cabinet.DisplayPrice();

            Console.Read();
        }
    }
}