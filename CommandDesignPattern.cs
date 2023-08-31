using System;
namespace CommandDesignPattern
{
    // Receiver Object 
    // The Receiver contains the business logic. 
    // They know how to perform all kinds of operations
    // They Know how to handle the Request i.e. Performing the actual Operation
    public class Document
    {
        public void Open()
        {
            Console.WriteLine("Document Opened");
        }

        public void Save()
        {
            Console.WriteLine("Document Saved");
        }

        public void Close()
        {
            Console.WriteLine("Document Closed");
        }
    }
}
namespace CommandDesignPattern
{
    // Command Interface
    // It declares a method for executing a command
    public interface ICommand
    {
        void Execute();
    }
}
namespace CommandDesignPattern
{
    // ConcreteCommand A 
    // It defines a binding between a Receiver Object i.e. Document and an Action i.e. Open
    public class OpenCommand : ICommand
    {
        //Reference of Receiver Object
        private Document document;

        //Initializing the Receiver Object using the Constructor
        public OpenCommand(Document doc)
        {
            document = doc;
        }

        //Execute Method will internally call the Receiver Object Open Method
        public void Execute()
        {
            document.Open();
        }
    }
}
namespace CommandDesignPattern
{
    //ConcreteCommand B 
    //It defines a binding between a Receiver Object i.e. Document and an Action i.e. Save
    class SaveCommand : ICommand
    {
        //Reference of Receiver Object
        private Document document;

        //Initializing the Receiver Object using the Constructor
        public SaveCommand(Document doc)
        {
            document = doc;
        }

        //Execute Method will internally call the Receiver Object Save Method
        public void Execute()
        {
            document.Save();
        }
    }
}
namespace CommandDesignPattern
{
    //ConcreteCommand C 
    //It defines a binding between a Receiver Object i.e. Document and an Action i.e. Close
    class CloseCommand : ICommand
    {
        //Reference of Receiver Object
        private Document document;

        //Initializing the Receiver Object using the Constructor
        public CloseCommand(Document doc)
        {
            document = doc;
        }

        //Execute Method will internally call the Receiver Object Close Method
        public void Execute()
        {
            document.Close();
        }
    }
}
namespace CommandDesignPattern
{
    // Invoker  
    // The Invoker is associated with one or several commands. 
    // It sends a request to the command.
    public class MenuOptions
    {
        private ICommand openCommand;
        private ICommand saveCommand;
        private ICommand closeCommand;

        public MenuOptions(ICommand open, ICommand save, ICommand close)
        {
            this.openCommand = open;
            this.saveCommand = save;
            this.closeCommand = close;
        }

        //The Invoker cannot handle the Request, so it internally calls the Execute Method
        //of the Command Object. 
        public void ClickOpen()
        {
            openCommand.Execute();
        }

        //The Invoker cannot handle the Request, so it internally calls the Execute Method
        //of the Command Object. 
        public void ClickSave()
        {
            saveCommand.Execute();
        }

        //The Invoker cannot handle the Request, so it internally calls the Execute Method
        //of the Command Object. 
        public void ClickClose()
        {
            closeCommand.Execute();
        }
    }
}
using System;
namespace CommandDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an Instance of Receiver
            Document document = new Document();

            //Create the Command Object by passing the Receiver Instance
            ICommand openCommand = new OpenCommand(document);
            ICommand saveCommand = new SaveCommand(document);
            ICommand closeCommand = new CloseCommand(document);

            //Create the Invoker instance by passing the command objects
            MenuOptions menu = new MenuOptions(openCommand, saveCommand, closeCommand);

            //Giving command to the Invoker to do the operation
            menu.ClickOpen();
            menu.ClickSave();
            menu.ClickClose();

            Console.ReadKey();
        }
    }
}