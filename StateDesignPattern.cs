namespace StateDesignPattern
{
    // The State Interface declares methods that all Concrete State Classes should implement 
    public interface IATMState
    {
        void InsertDebitCard();
        void EjectDebitCard();
        void EnterPin();
        void WithdrawMoney();
    }
}
namespace StateDesignPattern
{
    // The State Interface declares methods that all Concrete State Classes should implement 
    public interface IATMState
    {
        void InsertDebitCard();
        void EjectDebitCard();
        void EnterPin();
        void WithdrawMoney();
    }
}
using System;
namespace StateDesignPattern
{
    // Concrete States implement various behaviors, associated with a state of the Context Object.
    // The following Concrete State class implement behavior when the ATM State i.e. Context Object State is DebitCardNotInsertedState
    public class DebitCardNotInsertedState : IATMState
    {
        public void InsertDebitCard()
        {
            Console.WriteLine("DebitCard Inserted");
        }

        public void EjectDebitCard()
        {
            Console.WriteLine("You cannot eject the Debit CardNo, as no Debit Card in ATM Machine slot");
        }

        public void EnterPin()
        {
            Console.WriteLine("you cannot enter the pin, as No Debit Card in ATM Machine slot");
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("you cannot withdraw money, as No Debit Card in ATM Machine slot");
        }
    }
}using System;
namespace StateDesignPattern
{
    // Concrete States implement various behaviors, associated with a state of the Context Object.
    // The following Concrete State class implement behavior when the ATM State i.e. Context Objec State is DebitCardInsertedState
    public class DebitCardInsertedState : IATMState
    {
        public void InsertDebitCard()
        {
            Console.WriteLine("You cannot insert the Debit Card, as the Debit card is already there ");
        }

        public void EjectDebitCard()
        {
            Console.WriteLine("Debit Card is ejected");
        }

        public void EnterPin()
        {
            Console.WriteLine("Pin number has been entered correctly");
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("Money has been withdrawn");
        }
    }
}using System;
namespace StateDesignPattern
{
    // The Context Class defines the interface which is going to be used by the clients. 
    // It also maintains a reference to an instance of a State subclass, which represents the current state of the Context.
    public class ATMMachine : IATMState
    {
        // A reference to the current state of the Context.
        public IATMState AtmMachineState = null;

        public ATMMachine()
        {
            //Initially the AtmMachineState will be DebitCardNotInsertedState
            AtmMachineState = new DebitCardNotInsertedState();
        }

        // The Context Object allows changing the State of the object at runtime.
        public void InsertDebitCard()
        {
            //Inserting Debit card
            AtmMachineState.InsertDebitCard();
            
            if (AtmMachineState is DebitCardNotInsertedState)
            {
                // Debit Card has been inserted so the internal state of the ATM Machine
                // has been changed to DebitCardInsertedState
                AtmMachineState = new DebitCardInsertedState();

                Console.WriteLine($"ATM Machine internal state has been changed to : {AtmMachineState.GetType().Name}");
            }
        }

        // The Context Object allows changing the State of the object at runtime.
        public void EjectDebitCard()
        {
            //Ejecting the Debit Card
            AtmMachineState.EjectDebitCard();
            
            if (AtmMachineState is DebitCardInsertedState)
            {
                // Debit Card has been ejected so the internal state of the ATM Machine
                // has been changed to 'DebitCardNotInsertedState'
                AtmMachineState = new DebitCardNotInsertedState();
                Console.WriteLine($"ATM Machine internal state has been Changed to : {AtmMachineState.GetType().Name}");
            }
        }

        public void EnterPin()
        {
            //No need to Change the State, only perform the Operation
            AtmMachineState.EnterPin();
        }
        public void WithdrawMoney()
        {
            //No need to Change the State, only perform the Operation
            AtmMachineState.WithdrawMoney();
        }
    }
}using System;
namespace StateDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initially ATM Machine in DebitCardNotInsertedState
            ATMMachine atmMachine = new ATMMachine();

            Console.WriteLine("ATM Machine Current state : "
                            + atmMachine.AtmMachineState.GetType().Name);
            Console.WriteLine();
            atmMachine.EnterPin();
            atmMachine.WithdrawMoney();
            atmMachine.EjectDebitCard();
            atmMachine.InsertDebitCard();

            Console.WriteLine();

            // Debit Card has been inserted so the internal state of the ATM Machine
            // has been changed to DebitCardInsertedState

            Console.WriteLine("ATM Machine Current state : "
                            + atmMachine.AtmMachineState.GetType().Name);
            Console.WriteLine();

            atmMachine.EnterPin();
            atmMachine.WithdrawMoney();
            atmMachine.InsertDebitCard();
            atmMachine.EjectDebitCard();

            Console.WriteLine("");

            // Debit Card has been ejected so the internal state of the ATM Machine
            // has been changed to DebitCardNotInsertedState
            Console.WriteLine("ATM Machine Current state : "
                            + atmMachine.AtmMachineState.GetType().Name);

            Console.Read();
        }
    }
}