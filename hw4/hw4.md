### Homework 4

Homework 4 - Intro to MVC (no database)

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

This weeks assignment was to get familiar with the GET/POST process and to get familiar with 
Microsoft Visual Studio and MVC.

This assignment wasn't too bad, but the learning curve on VS was a little steep for me as I was pulled unfamiliar
with starting the process. I used it in the last assignment, but I imported previously started code and didn't have to 
create a project. I had quite a hard time getting the project to register my repository and getting it to display the 
web pages properly. I took my notes from class and applied them to completing this assignemnt.

The first two websites were fairly straightforward and easily accomplished. I ran into an issue as I was trying to 
implement a "terms" parameter that allowed the repayment period be something other than months. I had the input working,
but couldn't get the formula to work correctly. I followed a couple guides and they had no mention of how to change from
months to other terms such as years, days or weeks so I scrapped the idea. It was interesting to see how the information
passed from client to server and the language differnce affected what the types had to be. 

1. I started with an empty MVC project (more than once).

2. I created a feature branch called HW4Feature. I added my changes to it and will merge it into the master when this file is complete.

3. This was the easiest part. I used the @Html.ActionLink as instructed in an unordered list.

	![@Html.ActionLink in action](https://jthatfield15.github.io/cs460/hw4/3-1.JPG)
	
	As mentioned in the comments, I copied the nav bar from the class example. It made it much easier for me to navigate
	around my pages to confirm changes when I published the pages.
	
	![Index Page](https://jthatfield15.github.io/cs460/hw4/3-2.JPG)
	
4. Creating page 1 was fairly easy as well. The goal of Page 1 is to get information from the client and pass it to the 
	server via a GET/POST routine. First the client sends the GET request and then the server sends the GET response.
	The calculation is made on the server side: it merely converts the degree the user provided to the opposite degree type.
	The first page was done using the REQUEST object. 
	
	![REQUEST in action]](https://jthatfield15.github.io/cs460/hw4/4-1.JPG)
	
	![Form Input]](https://jthatfield15.github.io/cs460/hw4/4-2.JPG)
	
	![Form Output]](https://jthatfield15.github.io/cs460/hw4/4-3.JPG)
	
5. Creating page 2 was easier after creating page 1. It was more or less the same using FormCollection. This was similar
	to the javascript that I have scripted before but this was much easier because the server was already aware of the 
	form object. The first difference here is that there is a different page for the GET request and POST request. 
	The GET request is a simple display of the view with not data.
	
	![Get Method]](https://jthatfield15.github.io/cs460/hw4/5-1.JPG)
	
	The second difference is that there is a parameter in the POST method. The parameter is a FormCollection object. 
	This collects the data that is passed by the POST in a FormCollection object and then you can call those almost like
	they are attributes. After accessing the data, the rest is the same. I used the same methods I wrote for page 1 to 
	convert the temperature.
	
	![POST and FormCollection]](https://jthatfield15.github.io/cs460/hw4/5-2.JPG)
	
6. This was the tough one. Page 3 is supposed to use model binding. After watching this done in class, I had confused
	model binding with the model aspect of MVC so I started down the path of creating a model. I didn't realize when I
	start that this was the same as a database. I scrapped the idea, and created a new project (this was the 3rd or 5th 
	by this time). Model binding is easy after you understand the requirements. First, start with a normal GET request to
	display the form to allow you to get the information. 

	![Get Method]](https://jthatfield15.github.io/cs460/hw4/6-1.JPG)
	
	Create a view with a form, just like the other pages, but this one required a bit more validation to ensure the 
	form wouldn't crash or break when invalid data was input. We were supposed to create a loan calculator with three 
	inputs: principal, interest, and number of payments. Page 1 was easy to validate because it was just a server side check
	but this one you have to check on the client side as well to ensure the form would behave normally. If you pass a 
	POST request with missing data, the functions would break. Passing null is fine after you set the paramaters as 
	nullable by adding a ? to the end of the data type. 
	
	![Parameterization]](https://jthatfield15.github.io/cs460/hw4/6-2.JPG)
	
	I decided to make all of mine nullable so I could handle the nulls on the server side. The only one that had to be
	nullable for this to work was the totalRepayment since it was created on the serverside and wasn't something the 
	client could pass to the server. After getting the form data from the client, the server did some functions on the 
	data to get the monthly payments and interest. That was passed back to the client and displayed if the totalRepayment
	was not null. 
	
	As for the formula, I followed a few online tutorials to ensure I got the math correct. One thing that was different
	from what I had worked with before was the casting and the specific types allowed for certain methods. Take, for
	example, the Math.Pow method. It doesn't play nice when you have two number types that aren't the same. This makes
	sense, but it sure gave me some trouble as I was unfamiliar with it. One nice feature of this is that you can 
	reuse the same data since it can be passed back in the POST request.
	
	Ultimately, I came out with a decent product that does exactly what it is intended to.
	
	![Calculator after POST]](https://jthatfield15.github.io/cs460/hw4/6-3.JPG)
	
	
	