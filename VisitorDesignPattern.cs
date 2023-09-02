namespace VisitorDesignPattern
{
    // The Element interface declares an Accept method that should take the
    // base visitor interface as an argument.
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}
namespace VisitorDesignPattern
{
    // The Concrete Element implements the Accept operation that takes a visitor as an argument
    public class Kid : IElement
    {
        //The following Property is going to hold the Kid Name
        public string KidName { get; set; }

        //Initializing the KidName Property using Class Constructor
        public Kid(string name)
        {
            KidName = name;
        }

        //The following Method will call the Concrete Visitor Visit method by passing the current Kid Object
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
namespace VisitorDesignPattern
{
    // The Visitor Interface declares the Visit Method that corresponds to the Element class. 
    // The Visit Method will accept the IElement object as a parameter i.e. the concrete class 
    // which implements the IElement Interface. In this case the Kid object
    public interface IVisitor
    {
        void Visit(IElement element);
    }
}
using System;
namespace VisitorDesignPattern
{
    // Concrete Visitors implement several versions of the same algorithm, which
    // can work with all concrete component classes.

    // The following Concrete Visitor class implements the Visit Method declared by Visitor Interface. 
    // The Visit Method implements a fragment of the algorithm defined for the corresponding Element class. 
    public class Doctor : IVisitor
    {
        //The following Property store the Name of the Doctor
        public string Name { get; set; }

        //Initializing the Name Property using Class Constructor
        public Doctor(string name)
        {
            Name = name;
        }

        //The Following is the Method we want to execute for each element of the collection or Data Structure
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Doctor: {Name} did the health checkup of the child: {kid.KidName}");
        }
    }
}

using System;
namespace VisitorDesignPattern
{
    // The following Concrete Visitor class implements the Visit Method declared by Visitor Interface. 
    // The Visit Method implements a fragment of the algorithm defined for the corresponding Element class. 

    class Salesman : IVisitor
    {
        //The following Property store the Name of the Salesman
        public string Name { get; set; }

        //Initializing the Name Property using Class Constructor
        public Salesman(string name)
        {
            Name = name;
        }

        //The Following is the Method we want to execute for each element of the collection or Data Structure
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Salesman: {Name} give a school bag to the child: {kid.KidName}");
        }
    }
}
using System.Collections.Generic;
namespace VisitorDesignPattern
{
    // ObjectStructure
    // The ObjectStructure contains the list of elements that a visitor wants to visit
    
    public class School
    {
        private static readonly List<IElement> Elements =  new List<IElement>();
        static School()
        {
            Elements = new List<IElement>
            {
                new Kid("Ram"),
                new Kid("Sara"),
                new Kid("Pam")
            };
        }

        //The following Method Accepts the Concrete Visitor Object as a Parameter
        public void PerformOperation(IVisitor visitor)
        {
            // Loop Through Each Element of the Collection or Data Structure
            foreach (var kid in Elements)
            {
                //Calling Accept Method of the Element Object by passing the Visitor Object as an argument
                kid.Accept(visitor);
            }
        }
    }
}