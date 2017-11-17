### Homework 6

Homework 6 - MVC with an existing database

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

[Jake's GitHub.io Homepage](https://jthatfield15.github.io/cs460/)

This weeks assignment was to use an larger existing database, AdventureWorks, to get familiar with conneting to an interacting with the
database. Linq was also introduced this week.

This weeks assignment had a rough start. From importing the database to getting the information from the database, it
was all fairly new and interesting. The thing that I didn't like (and it may change with time), is Linq. It seems 
nice but it was difficult to use in LinqPad because the free version doesn't have intellisense. Using it in Visual
Studios, it had intellisense, but no way of testing the data set before running it. 

The goal of this week's assignment was to implement two features: search for a product by the category and subcategories
and view and add reviews to products. The second part of the assignment was much easier than the first, probably because
I had some experience working with Linq and the database connection after doing the first part. 

1. I started the project by creating an empty project. 

2. The first thing I did after that was add the database. The instructions I kept seeing on the interent said to restore the database
but I couldn't find a restore database option anywhere. After struggling with that for a while, I searched for another
option and came across an sql restore option. It also showed the restore database option that I couldn't get to work, so I thought
the other option must work. This was directly from [Mircrosoft](https://msdn.microsoft.com/en-us/library/mt710790.aspx)
so I thought I would give it a try. It went like this: create a new query, run a query to restore the filelist only from the 
.bak file, and then use the logical name from that query to actually restore the database. It worked!

3. The next step was to add the model from the database. This was fairly simple as all I had to do was add a model from database
by right clicking on the model folder and add a class. This brought up a window where I selected Data under Visual C# and
then ADO.NET Entity Data Model. I changed the name to reflect my project, AdventureWorksContext. This created the models
for me. I created a DAL folder in my Models folder and moved the context file into the DAL.

4. The next thing I did was connect LinqPad to the database. I spent a large amount of time trying to figure out Linq. At 
this moment, I still prefer SQL. I foresee us using Linq in the future and hopefully it will grow on me. After gettting some
of the queries I wanted, such as getting all the categories and subcategories, I took a break. I told you I wasn't fond of Linq.

5. I continued with creating a controller. I just added a new empty one. The first thing I did was add the database connection
using the contextfile. Along with using the contextfile, I had to add a using statement at the bop.
	```c#
	using Homework6.Models;
	---
	private AdventureWorksContext db = new AdventureWorksContext();
	```
	I adjusted the Index to get the categories using this code: 
	```c#
	 // get all the productcategories (4 of them)
	var categories = db.ProductCategories;
	
	return View(categories);
	```
6. To test that I was getting the information correctly and could view it, I had to create a view. I added a razor foreach loop
to create links with the ProductCategoryID. This was not the first thing I attemped. I wanted to do buttons that would link give
the ProductCategoryID and bring up a list, but since I was first attempting it, I spent a lot of time on it and jumped to an 
easier route. After completing the assignment, I think I could figure out how to get the buttons to work, but it is done and I 
don't want to break things or refactor the methods. 
	
	The links make use of the 'id' property that we discussed in class. It appends the ProductCategoryID as id, to the end
	of the URL. This is picked up via my RouteConfig.cs as the id parameter. Then when use the links, the id is passed and
	I can use the same view, Index, to display the subcategories. I know this reloads the whole page through a GET request, 
	but I couldn't figure out how to access the data when I did it. I think I could have querried the categories on the 
	controller and then returned the subcategories in arrays. My largest problem was getting Linq and razor to play nice with javascript.
	```html
	 @foreach (var item in Model.ToList())
	//iterate over the product categories and create links
	{
		ViewBag.CategoryName = item.Name;
		<h4>@Html.ActionLink(item.Name, "Index/" + item.ProductCategoryID)</h4>
	}
	```
	
	In order to access the data from the database on the view, I had to add this statement:
	```c#
	@model IEnumerable<Homework6.Models.ProductCategory>
	```
	Which returned an IEnumerable of the ProductCategory objects. I also had to add a nullable parameter to Index to accept
	the id. If id wasn't null, it would add it to the ViewBag. When Index was displayed, it would check the ViewBag for id
	and if it was there, it would display the subcategories using another foreach loop.
	```c#
	@if (ViewBag.catID != null)
    // this will be null on initial load
    {
        // displays Subcategory name
        <h2>@Model.Where(p => p.ProductCategoryID == ViewBag.catID).FirstOrDefault().Name</h2>

        //iterate over subcategories if the category match the ID
        foreach (var item in Model.Where(p => p.ProductCategoryID == ViewBag.catID).Select(p => p.ProductSubcategories).ToList().FirstOrDefault())
        {
            <h4>@Html.ActionLink(item.Name, "Products/" + item.ProductSubcategoryID)</h4>
        }
    }
	```
	
	![Showing all subcategories](https://jthatfield15.github.io/cs460/hw6/6-1.JPG)
	
7. Now that I have the ProductSubcategoryID, I need to get the products. I created a new view, Products, to display all of
products in that subcategory. This time, I passed Products to the view so I could iterate over them. I created a list of
the products on the controller using this Linq command: 
	```C#
	var products = db.ProductSubcategories.Find(id).Products.ToList();
	```
	I displayed the product nmae with the price on the Products page. My thought was to order them by price, but never made it that far. I was
	also going to do pagination, but the way that I displayed them in columns, they all fit on one page so I skipped that thought.
	I don't beleive pagination would have been hard to implement. It looked like you just take a number of results and skip a number
	of results to get the list to display the results you want. Again, I thought about it, but tested every subcategory and they 
	all fit on one page so I skipped that idea.
	
	```html
	@model IEnumerable<Homework6.Models.Product>
	
	@foreach (var item in Model) // iterate over all products
	{
		<div class="col-md-4"><h4>@Html.ActionLink(item.Name, "Product/" + item.ProductID, "Products")</h4></div>
		<div class="col-md-2"><h4>: $@Html.DisplayFor(modelItem => item.ListPrice)</h4></div>
	}
	```
	
	![Showing all products in a chosen subcategory](https://jthatfield15.github.io/cs460/hw6/7-1.JPG)

8. The link from the Products page sent a GET request to the Product page. So that was what I created next. Again, I used
the 'id' field appended at the end of the URL. I querried Products to find the product I wanted and returned that to the
Product page.
	```C#
	var product = db.Products.Find(id);
	
	return View(product);
	```

9. The product page was fun to play with since I was also contemplating on how to get the image. Linq was not nice to me and
after spending quite a bit of time fiddling with it, I opted to skip it and possibly go back after this is all done. Since I 
returned only a single product from the controller, my @model statement is only for a single object rather than an IEnumerable.
This made it easy to grab the product information and display it. I opted to take the extra time to put the items in the ViewBag
so it would make my display strings look nice. I could have skipped it though. My though was to put the information into the ViewBag
on the controller side and not pass it back an object. I thought this would help me get the images I wanted to display. I had too 
much trouble with Linq and skipped it at least for now. I was able to display all of the other product information. One thing I 
struggled with was displaying (or not displaying) information if it was null or an empty string. I tried multiple variations of 
checks, but couldn't get them to work, so for now, if the string is empty or null, it is still displayed. That met the requirements
for the first feature: find a product and display it.
	```html
	@model Homework6.Models.Product 
	@{//pass in single object not IEnumerable, that was passed in from the controller
    ViewBag.Title = "Product";
    ViewBag.pID = Html.DisplayFor(p => p.ProductID);
    ViewBag.pName = @Html.DisplayFor(p => p.Name);
    ViewBag.pClass = @Html.DisplayFor(p => p.Class);
    ViewBag.pColor = @Html.DisplayFor(p => p.Color);
    ViewBag.pListPrice = @Html.DisplayFor(p => p.ListPrice);
    ViewBag.pProductLine = @Html.DisplayFor(p => p.ProductLine);
    ViewBag.pProductNumber = @Html.DisplayFor(p => p.ProductNumber);
    ViewBag.pSize = @Html.DisplayFor(p => p.Size) + " " + @Html.DisplayFor(p => p.SizeUnitMeasureCode);
    ViewBag.pStyle = @Html.DisplayFor(p => p.Style);
    ViewBag.pWeight = @Html.DisplayFor(p => p.Weight) + " " + @Html.DisplayFor(p => p.WeightUnitMeasureCode);
	}
	<h2>@ViewBag.pName</h2>

	<h4>Class: @ViewBag.pClass</h4>
	<h4>Color: @ViewBag.pColor</h4>
	<h4>List Price: $@ViewBag.pListPrice</h4>
	<h4>Product Line: @ViewBag.pProductLine</h4>
	<h4>Product Number: @ViewBag.pProductNumber</h4>
	<h4>Size: @ViewBag.pSize</h4>
	<h4>Style: @ViewBag.pStyle</h4>
	<h4>Weight: @ViewBag.pWeight</h4>
	```

10. I just went an implemented the photo for the individual products. It is only one of the two images I could display,
but to display the thumbnail images on the Products page, I definitely would need to include pagination and a lot of 
re-work. To implement the image display of the individual products, I used a join of the Product and ProductPhotos (ProductPhotoes as
implemented by the model) using the many-to-many table ProductProductPhotos (ProductProductPhotoes). I figured a join would be needed
as there is an interesecting table involved. After getting the image, which is in Byte[] format, I put it in the ViewBag and
passed it to the view. The code looks simple, but it took me a while to figure it out.
	
	```c#
	var photo = (from item in db.ProductPhotoes
	where item.ProductProductPhotoes.Any(p => p.ProductID == id)
	select item.LargePhoto).FirstOrDefault();
	
	ViewBag.pPhoto = photo;
	```
	
	After passing the 'image' to the view, I had to convert the Byte[] into an image. I used some code I found on [Stack Overflow](https://stackoverflow.com/questions/22475513/how-can-i-render-an-html-image-from-byte-data)
	which showed me how to render an image from byte data. It worked perfectly. All I had to do after that was to call the 
	variable I created in an image tag calling my new image variable as the source.
	
	```html
	@{ 
    var base64 = Convert.ToBase64String(ViewBag.pPhoto);
    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
	}
	
	<h4><img src="@imgSrc"; /></h4>
	```
	
	![Displaying a single Product](https://jthatfield15.github.io/cs460/hw6/10-1.JPG)
	
11. Looking ahead, I wanted to add a search feature on the Index page to jump straight to a product to write the review. This
was fairly simple because all I had to do was get an input and create a link with it. Once I appended the id to the Product field, 
I was able to go directly to the product. The assumption for the second feature was the customer know the ProductID. I created a 
small form with a 'submit' button to process the Redirect.

	```html
	<h4>Know the Product Id? <br />Enter it here:</h4>
        
		<form action="/Products/Product/" >
			<input type="number" name="id" size="12" />
			<button type="submit" value="Submit">Find it!</button>			
		</form>
	```
	
12. I jumped back over to LinqPad to determine how to get the ProductReview. I found that really easy since there is a ProductReview
table that uses the ProductID as a key. Moving forward, I think I started in reverse order because I attempted to input into the 
table before I tried to display the information. I had very little problems doing it this way so it was ok.

13. I created a form to insert the data that was supposed to be collected from the instructions: name, email, rating, and comments.
I quickly found out after my first attempt, that I needed to pass all the information in the table to the database since the fields
in the table weren't nullable. I addressed this by creating DateTime stamps to pass in. This was done on a POST request of the form.

	```html
	<form name="myForm" id="myForm" method="post">
    <input name="id" type="number" value="@ViewBag.pId" style="display:none"/>
    <p>
        <label for="name">Name:</label>
        <input type="text" name="name" />
    </p>
    <p>
        <label for="email">Email:</label>
        <input type="text" name="email" />
    </p>
    <p>
        <label for="rating">Rating (1 to 5 scale):</label>
        <input type="number" name="rating" min="1" max="5" />
    </p>
    <p>
        <label for="comments">Comments:</label>
        <textarea name="comments" form="myForm"></textarea>
    </p>
    <button type="submit">Submit Review</button>
	</form>    
	```
	![Review Form](https://jthatfield15.github.io/cs460/hw6/13-1.JPG)
	
	After creating the form, I wanted to add a way to show and hide the form. I have done this in the past so I just added
	a little javascript to take care of the sytle:display and that was taken care of.
	
	```html
	function toggleElementVisibilty(elementId)
    {
        var element = document.getElementById(elementId);

        if (element.style.display == "none")
        {
            element.style.display = "block";
        }
        else
        {
            element.style.display = "none";
        }
    }
	```
	
	Now I could fill out the form and submit it. Once it is submitted, a POST request is sent and the controller takes the
	variables and creates a new ProductReview object and insert it into the database. It then saves the database. If it is
	successful, it returns the user to a simple Success page. If it is not successful, it redirects the user to a Failure page.
	
	![Success](https://jthatfield15.github.io/cs460/hw6/13-2.JPG)
	
	![Failure](https://jthatfield15.github.io/cs460/hw6/13-3.JPG)
	
14. Since I did the inserts first, I had to go back and work on displaying the data. I thought it would be easiest to just show
it, but wanted to hide it incase you wanted to use the form. So I implemented the same code to show/hide the review data. I 
then had to implement a way to insert the review data into the page. I did this with a for each loop in the reviewsDiv. That was simple.
Then I did a check to see if the reviewsDiv was empty. If it was was, I could display a custome message to let the user know there 
are no reviews for that item.

	![No Reviews to Display](https://jthatfield15.github.io/cs460/hw6/14-1.JPG)
	
	Then I had to check that my data was being displayed. Here is the review I added in the previous step. 
	
	![Review Displayed](https://jthatfield15.github.io/cs460/hw6/14-2.JPG)
