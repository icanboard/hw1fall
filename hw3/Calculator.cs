// API Imports (USING)
using System;

/**
* Command line postfix calculator.  This code makes use of java.lang.IllegalArgumentException
* to indicate when there is a problem with the input expression.  I probably should have written my own
* exception class that is specific to this application, but this one sounds appropriate. 
* Converted from Java into C#.
*
* @author    Scot Morse
* @translator Jake Hatfield
*/
public class Calculator
{
    /**
	* Our data structure, used to hold operands for the postfix calculation.
	*/
    private IStackADT CalcStack = new LinkedStack();

    /** Scanner to get input from the user fromt he command line. */
    //private Scanner scin = new Scanner(System.Console.ReadLine);

    /**
	* Entry point method.Disregards any command line arguments.
    *
    * @param  args The command line arguments
    */
    public static void Main(string[] args)
    {
        // Instantiate a "Main" object so we don't have to make everything static.
        Calculator app = new Calculator();
        bool playAgain = true;
        Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
        while(playAgain) // loop the method until user closes or enters "q"
        {
            playAgain = app.DoCalculation();
        }
        Console.WriteLine("Bye.");
    }

    /**
	* Get input string from user and perform calculation, returning true when
	* finished. If the user wishes to quit this method returns false.
	*
	* @return    true if a calculation succeeded, false if the user wishes to quit
	*/
    private bool DoCalculation()
    {
        Console.WriteLine("Please enter q to quit");
        string input, output = " ";
        Console.Write("> "); // prompt user

        input = Console.ReadLine(); 
        
        // See if the user wishes to quit
        if(input.Trim().ToLower().StartsWith("q")) // similar to Javascript methods
        {
            return false;
        }
        // Go ahead with calculation
        try
        {
            output = EvaluatePostFixInput(input);
        }
        catch(ArgumentException e)
        {
            output = e.Message;
        }
        Console.WriteLine("\n>>> " + input + " = " + output + "\n");
        return true;
    }

    /**
	* Evaluate an arithmetic expression written in postfix form.
	*
	* @param  input                         Postfix mathematical expression as a String
	* @return                               Answer as a String
	* @exception  IllegalArgumentException  Something went wrong
	*/
    public string EvaluatePostFixInput(string input) //throws ArgumentException
    {
        if (input == null || input.Equals("")) // invalid input
        {
            throw new ArgumentException("Null or the empty string are not valid postfix expressions");
        }
        // clear our stack before doing a new calculation
        CalcStack.Clear();

        //String s; // temporary variable for token read
        double a; // temporary variable for operand
        double b; // temporary variable for operand
        double c; // temporary variable for answer
        double t; // temporary variable for testing if a string or a double, can be manipulated if its a double

        string[] s = input.Trim().Split(' '); // get input and parse it into seperate strings using a space as a delimiter

        foreach (string temp in s) // test each string in the array of strings
        {
            if (Double.TryParse(temp, out t)) // test if it is a double, then push it
            {
                CalcStack.Push(t);
            }
            else
            {
                // must be an operator or some other character or word
                if (temp.Length > 1) // only want operators so it can't be longer than 1
                {
                    throw new ArgumentException("Input Error: " + temp + " is not an allowed number or operator");
                }
                // it may be an operator so pop two values off the stack and perform the indicated operation
                if (CalcStack.IsEmpty()) // check if there is operand to use with the operator
                {
                    throw new ArgumentException("Improper input format. Stack became empty when expecting second operand");
                }
                b = (double)CalcStack.Pop(); 
                if (CalcStack.IsEmpty()) // check if there is another operand to use with the operator
                {
                    throw new ArgumentException("Improper input format. Stack become empty when expecting first operand");
                }
                a = (double)CalcStack.Pop(); 
                                                    
                // wrap up all operations in a single method, easy to add other binary operators this way if desired
                c = DoOperation(a, b, temp);
                // push the answer back on the stack
                CalcStack.Push(c);
            }
        }

        return CalcStack.Pop().ToString();
    }

    /**
    * Perform arithmetic.  Put it here so as not to clutter up the previous method, which is already pretty ugly.
    *
    * @param  a                             First operand
    * @param  b                             Second operand
    * @param  s                             operator
    * @return                               The answer
    * @exception  IllegalArgumentException  Something's fishy here
    */
    public double DoOperation(double a, double b, string s) //throws IllegalArgumentException
    {
        double c = 0.0; // initialize answer
        if (s.Equals("+")) // can't use a switch-case with Strings, so we do if-else
        {
            c = (a + b);
        }
        else if (s.Equals("-"))
        {
            c = (a - b);
        }
        else if (s.Equals("*"))
        {
            c = (a * b);
        }
        else if (s.Equals("/"))
        {
            try
            {
                c = (a / b);
                if (c == Double.NegativeInfinity || c == double.PositiveInfinity)
                {
                    throw new ArgumentException("Can't divide by zero");
                }
            }
            catch (ArithmeticException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        else
        {
            throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
        }
        return c;
    }
}