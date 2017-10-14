### Homework 3

This weeks assignment was to translate a Postfix Calculator that was written in Java into C#.

The largest challenge for me was the naming conventions. I rewrote all of the code and did not copy 
and paste any of it. I used Visual Studio IDE Community 2017 as recommended. 

I proceded to translate the code as I went, line per line. It was interesting how the IDE knew
what I wanted to type and gave me the correct gramar for some instances of the keywords. When I came 
across strings, it was confusing on which one to use, 'String' vs 'string'. I originally went with the
capital version. I had quite a rough start tring to get the project to load my code and compile it. After 
quite a bit of searching on Google, watching videos, and just trying to break the IDE, I finally got the 
program to load. 

1. I got the IDE installed quite easily.

2. I downloaded the Java code and unzipped it so I could follow allow with it.

3. I replicated the Java code into C# with the challenges as described above. 

	Along with the capitalization, my next hurdle was printing to the console. It didn't take me long to
	figure that out though, it was pretty straight forward. I noticed that there was quite a bit of code
	that seemed similar to Javascript for me.
	
	The largest hurdle I had was trying to figure out how to replace the Scanner class that Java has. My 
	original attempt was a do-while loop. I thought I could just read it line by line, but then I had to
	worry about the return and it just wasn't working. After banging my head against the wall with that for
	a while, I thought I could just use a delimiter and build an array as I have done with Javascript.
	That seemed to be exactly what I needed. Then walking through it was easy with a for each loop.
	
	```c#
	string[] s = input.Trim().Split(' '); // get input and parse it into seperate strings using a space as a delimiter

        foreach (string temp in s) // test each string in the array of strings
    ```
	
	After getting the strings, I had to turn them into doubles (or was that Doubles?). I tried many
	different casting schemes only to end up frustrated with the end result. Again, as seen in Javascript,
	I could easily parse a string as anything I wanted so that brought me to the idea of parsing. I found
	a great technique of parsing as a double to see if it was a number, and pushing that on the stack as
	a double instead of a string. That made life much easier to manipulate the output. 
	
	```c#
	if (Double.TryParse(temp, out t)) // test if it is a double, then push it
            {
                CalcStack.Push(t);
            }
	```
	
	After dealing with the doubles I interpretted from the input, dealing with the strings, or really the
	operators, was a breeze.
	
	```c#
	if (temp.Length > 1) // only want operators so it can't be longer than 1
                {
                    throw new ArgumentException("Input Error: " + temp + " is not an allowed number or operator");
                }
	```
	
	At that point, all I had to do was call the function to do the math operation and I was in business. Of
	course, none of this would have been possible without first creating the stack, which was implemented as an
	interface (with the I infront of it per the c# naming conventions). It wall came together nicely in the end
	and I included the final .exe file in my repository if you are interested in running in.
	
4. I created all this on a new Github branch and merged it into my master. 
	
	
	
	