### Homework 2

[Homework 2 website](https://jthatfield15.github.io/cs460/hw2/)

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

[Jake's GitHub.io Homepage](https://jthatfield15.github.io/cs460/)

This assignment was to create a functioning website that 
utilized Javascript and jQuery while still implementing CSS and Bootstrap.

1. I created a new folder in my Git repository named hw2. As I was working
on my pc at home from memory of the assignment, I forgot to create a branch
at first, but later created a branch and merged it into my master. I created
index.html

2. I spent some time thinking about what I wanted to make with my website.
I spend quite a bit of time driving, so I was thinking while I was driving,
and then the idea came to me. How much money do I spend a day driving? 
I decided to make a calculator to display how much I spend depending on the
gas price, miles per gallon, and how many miles I drive per day. I thought
that would be fun and interesting.

3. I created a wireframe while sitting at a table. I used paint and just
scribbled things down while waiting for class. I didn't save the original
wireframe (it looked like chicken scratch anyway), so I created a new one
from my pc when I got home. It is marginally better than the original, but 
the framework is still there and it is a similar layout to the original.
Take a look at it:![Homework 2 Wireframe](https://jthatfield15.github.io/cs460/hw2/WireFrameMockup.png)

4. It was fairly simple to create the page after creating the last one. And
I am fairly familiar with Javascript since I use it at work quite often. The 
jQuery was something I hadn't work with extensively, so I had to research that 
a bit. I found that I could just sprinkle it in since I had my code completed
with Javascript.

	The head for the site looks the same, except I added the jQuery and my Javascript to it.
	```html
	<script src='https://code.jquery.com/jquery-3.2.1.slim.min.js' integrity='sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN' crossorigin='anonymous'></script>
	<script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script type="text/javascript" src="localJS.js"></script>
	````

	As for the important parts of the website, I needed a place to put my output table
	so I created an empty output div.
	```html
	<div id="tableOutput" style="display:block"></div>
	```

	The Javascript was fun to build. I knew I wanted to build a table. The
	interesting part is building the tables with different variables so I 
	knew I would be using for loops and nested for loops. I also knew that I 
	had to use if statements to check if I was supposed to add an opening or
	closing tag depending on where I was in the code. Here is what I came up with.
	
	```javascript
	//start building the table
    outputString = '<br><table>';
	
	//build table
	for(var i=0; i<5; i++)
	{        
		//add title and build headers first
		if(i==0)
		{
			//k-1 number of headers headers
			for(var k=0; k<11; k++)
			{
				//add header and build tr before adding th and make an empty th for k=0
				if(k==0)
				{
					outputString += '<h2>Cost Per Trip</h2><tr><th></th>';
				}
				else
				{
					//add th and data
					outputString += '<th>' + tripMilesTemp + ' miles</th>';
					
					//increment tripMiles by 1
					tripMilesTemp++;
				}
				
				//close tr on final pass
				if(k==10)	
				{
					outputString += '</tr>';
				}
			}
		}
		
		//reset tripMilesTemp
		tripMilesTemp = tripMiles;
		
		//build content of table
		for(var j=0; j<11; j++)
		{
			//build tr on first pass
			if(j==0)
			{
				outputString += '<tr><th>' + parseInt(mpgTemp) + ' mpg</th>';
			}
			else
			{
				//add td and data. ensure the data is a float with parseFloat and 2 decimals with .toFixed(2)
				outputString += '<td>$' + parseFloat(tripMilesTemp/mpgTemp * ppg).toFixed(2) + '</td>';
				
				//increment tripMilesTemp
				tripMilesTemp++;
			}
			
			//close tr on final pass
			if(j==10)
			{
				outputString += '</tr>';
				
				//increment mpgTemp by 2; increment in final pass
				mpgTemp = parseInt(mpgTemp) + 2;
			}
		}
	}
	
	//close the table
	outputString += '</table>';
	```
	
	As you can see above, I started with a string and kept building it. I started with a break to 
	create a space between my elements and then started with the <table> tag. On the first trip through, 
	I add a title and then follow that by <th>'s. I used the loops to add the variable and create 
	incremental data from the starting point. After the table was completed, I closed it with the appropriate
	closing tags. 
	
	Getting parameters was easy. I put some input elements on my html page along with a submit button. I 
	enclosed the three inputs in a row so they will be displayed in a logical order when the window is resized.
	I put the submit button on the bottom and it followed my wireframe mockup. 
	
	```html
	<div class="row">
                <div class="col-md-4"><p>Price per Gallon: <input type="text" value="$" id="ppg" style="display:block"></p></div>
                <div class="col-md-4"><p>Miles per Gallon: <input type="text" id="mpg" style="display:block"></p></div>
                <div class="col-md-4"><p>Miles Driven: <input type="text" id="tripMiles" style="display:block"></p></div>
            </div>
            
            <div><button style="display:block" onclick="calculatePrices(this.value);" style="display:block">Process</button></div>
	```
	
	Anytime you let the user input a value, there is a need for validation. I put the validation in the Javascript
	code and ensured they were appropriately handled. I also included maximums and minimum inputs with alerts to 
	let the use know what was going on with them.
	
	```javascript
	function validateData(mpg, ppg, tripMiles)
	{
    //validate empty strings
	if(mpg == '' || ppg == '$' || ppg == '' || tripMiles == '')
	{
		alert("You must use a valid value for Price per Gallon, Miles per Gallon, and Miles Driven.");
        return(1);
	}
    
    //validate inputs are numbers
    if(isNaN(parseFloat(ppg)))
    {
        alert('Price per Gallon must be a number.')
        return(1);
    }
    if(isNaN(parseFloat(mpg)))
    {
        alert('Miles per Gallon must be a number.')
        return(1);
    }
    if(isNaN(parseFloat(tripMiles)))
    {
        alert('Miles Driven must be a number.')
        return(1);
    }
	
	//validate ppg is valid
	if(ppg<=0)
	{
		alert("Free gas? Hook me up!");
        return(1);
	}
	if(ppg>'20')
	{
		alert("Is that a realistic price for gas? I hope not!");
        return(1);
	}
	
	//validate mpg is valid
	if(mpg<5)
	{
		alert("Your car can't possible have that bad mpg! It has to be 5 or higher.");
        return(1);
	}	
	if(mpg>100)
	{
		alert("I want to buy your car. It's mpg is awesome!");
        return(1);
	}
	
	//validate tripMiles
	if(tripMiles<0)
	{
		alert('Are you driving in reverse? Trip miles needs to be greater than 0.');
        return(1);
	}
    return(0);
	}
	```

	I wrapped that in a seperate function so I could call it from the function that created the table.
	The idea is to validate the information before proceeding with creating the table because
	having invalid table would not display correctly.
	
	I also included a simple css file which to do some formatting. I wanted the 
	highlight of this site to be the table so I didn't include too much css.
	
	```css
	table {
    background-color: #ddd;
	}

	th, td {
		padding: 2px
	}

	h2 {
		color: blue;
	}
	```