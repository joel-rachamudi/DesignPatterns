namespace StrategyDesignPattern
{
    // Strategy Interface
    // The Strategy Interface declare methods that are common to all supported versions of the algorithm.
    // The Context Object is going to use this Strategy Interface to call the algorithm defined by Concrete Strategies.
    public interface ICompression
    {
        void CompressFolder(string compressedArchiveFileName);
    }
}

using System;
namespace StrategyDesignPattern
{
    // Concrete Strategy A
    // The following RarCompression Concrete Strategy implement the Strategy Interface and 
    // Implement the CompressFolder Method. 
    public class RarCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using Rar approach: '" + compressedArchiveFileName
                 + ".rar' file is created");
        }
    }
}

using System;
namespace StrategyDesignPattern
{
    // Concrete Strategy B
    // The following ZipCompression Concrete Strategy implement the Strategy Interface and 
    // Implement the CompressFolder Method. 
    public class ZipCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine("Folder is compressed using zip approach: '" + compressedArchiveFileName
                 + ".zip' file is created");
        }
    }
}

namespace StrategyDesignPattern
{
    // The Context Provides the interface which is going to be used by the Client.
    public class CompressionContext
    {
        // The Context has a reference to one of the Strategy objects. 
        // The Context does not know the concrete class of a strategy. 
        // It should work with all strategies via the Strategy interface.
        private ICompression Compression;

        //Initializing the Strategy Object i.e. Compression using Constructor
        public CompressionContext(ICompression Compression)
        {
            // The Context accepts a strategy through the constructor, 
            // but also provides a setter method to change the strategy at runtime
            this.Compression = Compression;
        }

        //The Context allows replacing a Strategy object at runtime.
        public void SetStrategy(ICompression Compression)
        {
            this.Compression = Compression;
        }

        // The Context delegates the work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public void CreateArchive(string compressedArchiveFileName)
        {
            //The CompressFolder method is going to be invoked based on the strategy object
            Compression.CompressFolder(compressedArchiveFileName);
        }
    }
}

using System;
namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // The client code picks a concrete strategy and passes it to the context. 
            // The client should be aware of the differences between strategies in order to make the right choice.

            //Create an instance of ZipCompression Strategy
            ICompression strategy = new ZipCompression();

            //Pass ZipCompression Strategy as an argument to the CompressionContext constructor
            CompressionContext ctx = new CompressionContext(strategy);
            ctx.CreateArchive("DotNetDesignPattern");

            //Changing the Strategy using SetStrategy Method
            ctx.SetStrategy(new RarCompression());
            ctx.CreateArchive("DotNetDesignPattern");

            Console.Read();
        }
    }
}