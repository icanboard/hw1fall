### Homework 2

[Homework 2](https://jthatfield15.github.io/cs460/hw2/)

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

	The head for the site looks the same, except I added the jQuery and my Javascipt to it.
	'''html
	<script src='https://code.jquery.com/jquery-3.2.1.slim.min.js' integrity='sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN' crossorigin='anonymous'></script>
	<script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script type="text/javascript" src="localJS.js"></script>
	'''

	As for the important parts of the website, I needed a place to put my output table
	so I created an empty output div.
	'''html
	<div id="tableOutput" style="display:block"></div>
	'''

	The Javascript was fun to build. I 