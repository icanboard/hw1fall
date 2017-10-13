// API Imports (USING)
//using java.util.scanner;
//using System.IO; //java.io.IOException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    private IStackADT stack = new LinkedStack();

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
        Boolean playAgain = true;
        Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");
        while(playAgain)
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
    private Boolean DoCalculation()
    {
        Console.WriteLine("Please enter q to quit\n");
        string input = "2 2 +";
        Console.Write("> "); // prompt user

        input = Console.ReadLine(); // scin.NextLine();
        // looks like nextLine() blocks for input when used on an InputStream (System.in). Docs don't say that!

        // See if the user wishes to quit
        if(input.StartsWith("q") || input.StartsWith("Q"))
        {
            return false;
        }
        // Go ahead with calculation
        String output = "4";
        try
        {
            output = EvaluatePostFixInput(input);
        }
        catch(System.ArgumentException e)
        {
            output = e.ToString();
        }
        Console.WriteLine("\n\t>>> " + input + " = " + output);
        return true;
    }

    /**
	* Evaluate an arithmetic expression written in postfix form.
	*
	* @param  input                         Postfix mathematical expression as a String
	* @return                               Answer as a String
	* @exception  IllegalArgumentException  Something went wrong
	*/
    public String EvaluatePostFixInput(String input) //throws ArgumentException
    {
        if(input==null || input.Equals(""))
        {
            throw new System.ArgumentException("Null or the empty string are not valid postfix expressions");
        }
        // clear our stack before doing a new calculation
        stack.Clear();

        //String s; // temporary variable for token read
        double a; // temporary variable for operand
        double b; // temporary variable for operand
        double c; // temporary variable for answer

        string s = null; // Console.ReadLine(); //Scanner st = new Scanner(input);
        //while(st.HasNext())
        do
        {
            st = Console.ReadLine();

            if (Regex.IsMatch(input, @"^\d+$"))
            {
                stack.Push((s)); // if it's a number, push it on the stack
            }
            else
            {
                // must be an operator or some other character or word
                //s = st.Next();
                if (s.Length > 1)
                {
                    throw new System.ArgumentException("Input Error: " + s + " is not an allowed number or operator");
                }
                // it may be an operator so pop two values off the stack and perform the indicated operation
                if (stack.IsEmpty())
                {
                    throw new System.ArgumentException("Improper input format. Stack became empty when expecting second operand");
                }
                b = ((double)(stack.Pop())); //.DoubleValue();
                if (stack.IsEmpty())
                {
                    throw new System.ArgumentException("Improper input format. Stack become empty when expecting first operand");
                }
                a = ((double)(stack.Pop())); //.Doublevalue();
                // wrap up all operations in a single method, easy to add other binary operators this way if desired
                c = DoOperation(a, b, s);
                // push the answer back on the stack
                stack.Push((double)(c));
            }
        } while (s != "q\n" || s != "Q\n"); // end while
        return ((double)(stack.Pop())).ToString();
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
    public Double DoOperation(Double a, Double b, String s) //throws IllegalArgumentException
    {
        Double c = 0.0;
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
                if (c == double.NegativeInfinity || c == double.PositiveInfinity)
                {
                    throw new System.ArgumentException("Can't divide by zero");
                }
            }
            catch (ArithmeticException e)
            {
                throw new System.ArgumentException(e.ToString());
            }
        }
        else
        {
            throw new System.ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
        }
            return c;
    }
}