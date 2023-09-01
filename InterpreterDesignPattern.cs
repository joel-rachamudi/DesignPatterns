using System;
namespace InterpreterDesignPattern
{
    //This is a class that contains information (Input and Output) that is going to be used by the Interpreter.
    public class Context
    {
        //The Expression Property is going to hold the Output
        public string Expression { get; set; }

        //The Date Property is going to hold the Input
        public DateTime Date { get; set; }

        //While Creating the Context Object, we need to send the Input data
        public Context(DateTime date)
        {
            //Initializing the Input Date Property through the Constructor input parameter value
            Date = date;
        }
    }
}
namespace InterpreterDesignPattern
{
    //This is going to be an interface that defines the Interpret operation, which must be implemented by each subclass.
    public interface IExpression
    {
        void Evaluate(Context context);
    }
}
namespace InterpreterDesignPattern
{
    //This is going to be a Concrete class that implements the Expression Interface.
    //The following Concrete DayExpression Class evaluates the Day grammar
    //That is Replacing DD with the Day from the Input Date Property
    public class DayExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace("DD", context.Date.Day.ToString());
        }
    }
}
namespace InterpreterDesignPattern
{
    //This is going to be a Concrete class that implements the Expression Interface.
    //The following Concrete MonthExpression Class evaluates the Month grammar
    //That is Replacing MM with the Month from the Input Date Property
    public class MonthExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace("MM", context.Date.Month.ToString());
        }
    }
}
namespace InterpreterDesignPattern
{
    //This is going to be a Concrete class that implements the Expression Interface.
    //The following Concrete YearExpression Class evaluates the Year grammar
    //That is Replacing YYYY with the Year from the Input Date Property
    public class YearExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace("YYYY", context.Date.Year.ToString());
        }
    }
}
namespace InterpreterDesignPattern
{
    //This is going to be a Concrete class that implements the Expression Interface.
    //The following Concrete SeparatorExpression Class evaluates the separate grammar
    //That is Replacing space with the - in the Expression string which is going to be our output
    class SeparatorExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace(" ", "-");
        }
    }
}
using System;
using System.Collections.Generic;
namespace InterpreterDesignPattern
{
    //This is the class that builds the abstract syntax tree for a set of instructions in the given grammar.
    //This tree builds with the help of instances of NonTerminalExpression and TerminalExpression classes.
    class Program
    {
        static void Main(string[] args)
        {
            //The following is going to be our Expression Tree
            List<IExpression> objExpressions = new List<IExpression>();

            //Creating the context object by passing the current date-time value
            Context context = new Context(DateTime.Now);

            //We want to Interpret the current date time as a specific format
            //Ask the user to select the format
            Console.WriteLine("Please Select the Expression  : MM DD YYYY or YYYY MM DD or DD MM YYYY ");
            context.Expression = Console.ReadLine();

            //Split Expression which the user selects to an array so that we can apply different Expression rules
            string[] strArray = context.Expression.Split(' ');

            //Looping through Each Element of the Expression and adding the Appropriate Expression with the Expression Tree
            foreach (var item in strArray)
            {
                if (item == "DD")
                {
                    objExpressions.Add(new DayExpression());
                }
                else if (item == "MM")
                {
                    objExpressions.Add(new MonthExpression());
                }
                else if (item == "YYYY")
                {
                    objExpressions.Add(new YearExpression());
                }
            }

            //Adding the SeparatorExpression
            objExpressions.Add(new SeparatorExpression());
            foreach (var obj in objExpressions)
            {
                //Finally Evaluate Each Expression which is added in the Expression Tree
                obj.Evaluate(context);
            }

            //Print the Expression as Output
            Console.WriteLine(context.Expression);
            Console.Read();
        }
    }
}