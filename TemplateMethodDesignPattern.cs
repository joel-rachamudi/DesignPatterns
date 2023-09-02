using System;
namespace TemplateMethodDesignPattern
{
    public abstract class HouseTemplate
    {
        // Template Method defines the sequence for building a house
        public void BuildHouse()
        {
            //Define the Steps to Build a House
            BuildFoundation(); //Step1
            BuildPillars(); //Step2
            BuildWalls(); //Step3
            BuildWindows(); //Step4
            Console.WriteLine("House is Built");
        }

        // Methods to be implemented by subclasses
        protected abstract void BuildFoundation();
        protected abstract void BuildPillars();
        protected abstract void BuildWalls();
        protected abstract void BuildWindows();
    }
}

using System;
namespace TemplateMethodDesignPattern
{
    public class ConcreteHouse : HouseTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building foundation with cement, iron rods and sand");
        }

        protected override void BuildPillars()
        {
            Console.WriteLine("Building Concrete Pillars with Cement and Sand");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Building Concrete Walls");
        }

        protected override void BuildWindows()
        {
            Console.WriteLine("Building Concrete Windows");
        }
    }
}
using System;
namespace TemplateMethodDesignPattern
{
    public class WoodenHouse : HouseTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building foundation with cement, iron rods, wood and sand");
        }

        protected override void BuildPillars()
        {
            Console.WriteLine("Building wood Pillars with wood coating");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Building Wood Walls");
        }

        protected override void BuildWindows()
        {
            Console.WriteLine("Building Wood Windows");
        }
    }
}

using System;
namespace TemplateMethodDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build a Concrete House\n");
            HouseTemplate houseTemplate = new ConcreteHouse();
            //Call the Template Method to Build the Concrete House
            houseTemplate.BuildHouse();

            Console.WriteLine();

            Console.WriteLine("Build a Wooden House\n");
            houseTemplate = new WoodenHouse();
            //Call the Template Method to Build the Wooden House
            houseTemplate.BuildHouse();

            Console.Read();
        }
    }
}