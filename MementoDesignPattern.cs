using System;
using System.Collections.Generic;
namespace MementoDesignPattern
{
    //This is the Model class that is going to hold the Product information i.e. Led TV Details
    public class LEDTV
    {
        //Properties of the LED TV
        public string Size { get; set; }
        public string Price { get; set; }
        public bool USBSupport { get; set; }

        //Initializing the Properties using Constructor
        public LEDTV(string Size, string Price, bool USBSupport)
        {
            this.Size = Size;
            this.Price = Price;
            this.USBSupport = USBSupport;
        }

        //Fetching the Details of the LedTV
        public string GetDetails()
        {
            return "LEDTV [Size=" + Size + ", Price=" + Price + ", USBSupport=" + USBSupport + "]";
        }
    }
}
namespace MementoDesignPattern
{
    //This is going to be a class that holds the information about the Originator’s saved state.
    //Stores the internal state of the Originator object.
    public class Memento
    {
        //The following Variable is going to Hold the Internal State of the Originator object
        public LEDTV LedTV { get; set; }

        //Initializing the Internal State of Originator Object using Constructor
        public Memento(LEDTV ledTV)
        {
            LedTV = ledTV;
        }

        //This Method is going to return the Internal State of the Originator
        public string GetDetails()
        {
            return "Memento [LedTV=" + LedTV.GetDetails() + "]";
        }
    }
}

namespace MementoDesignPattern
{
    //This is going to be a class that is used to hold a Memento object for later use.
    //This acts as a store only; it never Checks or Modifies the contents of the Memento object.
    public class Caretaker
    {
        //This variable is going to hold the List of Mementos that are used by the Originator.
        private List<Memento> LedTvList = new List<Memento>();

        //This Method will add the memento i.e. the internal state of the Originator into the Caretaker i.e. Store Room 
        public void AddMemento(Memento m)
        {
            LedTvList.Add(m);
            Console.WriteLine("LED TV's snapshots Maintained by CareTaker :" + m.GetDetails());
        }

        //This Method is used to return one of the Previous Originator Internal States which saved in the Caretaker
        public Memento GetMemento(int index)
        {
            return LedTvList[index];
        }
    }
}
namespace MementoDesignPattern
{
    //This is going to be a class that creates a memento object containing a snapshot of the Originator's current state. 
    //It also restores the Originator to a previously stored state.
    public class Originator
    {
        //This Property is used to store the current state of the Originator
        public LEDTV LedTV;

        //It will Create a snapshot of the current state of the Originator i.e. Current LedTV 
        //and return that Memento which we can store in the Caretaker i.e. in the Store Room
        public Memento CreateMemento()
        {
            return new Memento(LedTV);
        }

        //This Method is going to change the Internal State of the Originator to one of its Previous State
        public void SetMemento(Memento memento)
        {
            LedTV = memento.LedTV;
        }

        //This Method is going to return the Details of the Current Internal State of the Originator
        public string GetDetails()
        {
            //To Fetch the Details, internally it is calling the GetDetails method on LedTV Object
            return "Originator [LEDTV=" + LedTV.GetDetails() + "]";
        }
    }
}
using System;
namespace MementoDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating an Instance of the Originator and setting the current state as a 42-Inch Led TV
            Originator originator = new Originator
            {
                LedTV = new LEDTV("42-Inch", "60000", false)
            };

            //Storing the Internal State (Memento i.e. the Current Led TV) of the Originator in the Caretaker i.e. Store Room
            //First, Create an instance of the Caretaker
            Caretaker caretaker = new Caretaker();

            //Second Create a snapshot or memento of the current internal state of the originator
            Memento memento = originator.CreateMemento();

            //Third, store the memento or snapshot in the store room i.e. Caretaker
            caretaker.AddMemento(memento);

            //Changing the Originator Current State to 46-Inch
            originator.LedTV = new LEDTV("46-Inch", "80000", true);

            //Again storing the Internal State (Memento) of the Originator in the Caretaker i.e. Store Room
            //Create the memento or snapshot of the current internal state of the originator
            memento = originator.CreateMemento();
            //Store the memento in the Caretaker
            caretaker.AddMemento(memento);

            //Again, Changing the Originator Current State to 50-Inch
            originator.LedTV = new LEDTV("50-Inch", "100000", true);

            //The Current State of the Originator is now 50-Inch Led TV
            Console.WriteLine("\nOrignator Current State : " + originator.GetDetails());

            //Restoring the Originator to one of its previous states
            //We have added two Memento to the Caretaker
            //Index-0 means the First memento i.e. 42 Inch LED TV
            //Index-1 means the Second memento i.e. 46 Inch LED TV
            Console.WriteLine("\nOriginator Restoring to 42-Inch LED TV");
            originator.SetMemento(caretaker.GetMemento(0));

            Console.WriteLine("\nOrignator Current State : " + originator.GetDetails());
            Console.ReadKey();
        }
    }
}
