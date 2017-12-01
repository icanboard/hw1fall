### Homework 8

Homework 8 - MVC with a multi-table, relational database I created using provided seed data

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

[Jake's GitHub.io Homepage](https://jthatfield15.github.io/cs460/)

[Youtube Demo of my site in action](https://youtu.be/Ip7Rzd53w4U)

In this assignment, I was tasked with creating an E-R diagram and database from some seed data with Artist being the main entity in the model. Then implement CRUD functionality on Artists.

1. The first thing to do was create a new MVC application. Simple: create new project and name the file. Create a new feature branch: done.

2. I was given four entities at this point with the following seed data. I created the following ERD:

	![Seed Data](https://jthatfield15.github.io/cs460/hw8/1-seed_data.JPG)

	![E-R Diagram](https://jthatfield15.github.io/cs460/hw8/HW8_ERD.JPG)

	I then created an SQL up and SQL down script. It was important to note that I used integers as primary keys on all but the Genre. 
	
3. Using the up script, I created my database on the local server. This was easy after creating the script. I created the model at this point to ensure the database correctly reflected the up
script and the models were accuratly reflecting what was in the database. 

	To create the database, I right clicked on "databases" folder and created a new database. I gave it the name HW8 and changed the destination folder to match my repository. To seed the data, I had to connect
	to the database using the connection string found in the properties of the database. I right clicked on the database I created and clicked on properties, I scrolled through the properties until I found the
	connection string. I used that connection string to connect the up script to the database and was able to run my up script. The only part of the connection string I needed was this:
	
	```c#
	(localdb)\MSSQLLocalDB
	```
	
	After having the database set up, I created the model. I right clicked on the "Models" folder and clicked on "add new item". I selected "Data" and then "ADO.NET Entity Data Model". I changed the name to something
	relevant, "ArtistsContext", before clicking "Add". Followig the wizard, I selected "code first from database" and this is when I had to use the connection string from above. I left the box checked to save the
	connection string to the Web.Config file so I wouldn't have to do it manually. I changed the name of the string to match the name of my context file. I then checked the box to add the tables and left "pluralize" checked.
	I created a "DAL" folder in the "Models" folder and moved the context file into that folder. My model was created.

4. On the shared layout, I created a menu item for the three views: Artists, ArtWorks, and Classifications. I kept the names the same for simplicity and since I did it this way, I was able to 
create the menu items before I created the controller and views. I placed them int he navigation bar for simplicity and to maintain consistency when navigating to different pages. Each of these
views contained all the information about each entity, with the exception of the integer primary key. I also added some a few blurbs to make my landing page a bit more welcoming.

	I added the buttons first:

	```c#
	@Html.ActionLink("Home", "Index", "Artists", new { area = "" }, new { @class = "navbar-brand" })
	@Html.ActionLink("Artists", "Artists", "Artists", new { area = "" }, new { @class = "navbar-brand" })
	@Html.ActionLink("Artworks", "Artworks", "Artists", new { area = "" }, new { @class = "navbar-brand" })
	@Html.ActionLink("Classifications", "Classifications", "Artists", new { area = "" }, new { @class = "navbar-brand" })
	```

	This is when I created the controller. I right clicked on the "Controller" folder and clicked on "add controller". 
	I added an "MVC Controller with read/write actions" to allow me to easily implement the CRUD functionality. After creating the controller, I had to do two things to allow access to the database and dbcontext file:

	I added "using Homework_8.Models;" to the top of the controller.

	I added "private ArtistsContext db = new ArtistsContext();" just below (inside) the public class controller.

	Then I created a view for each of them: Artists, Artworks, and Classifications.
	
	In the controller action method for each one, I added a variable that assigned the list of that entity and returned it to the view to allow the view to manipulate and display the data. Here is a sample for 
	Artists, where the other two would just change the entity names:
	
	```c#
	var artists = db.ARTISTS;
	return View(artists);
	```
	
	In the view for each one, I added the model that corresponded with the entity and a foreach loop to iterate through the data. Artworks and Classificatons were fairly simple because all I had to do was display the
	data.
	
	```c#
	//
	@model IEnumerable<Homework_8.Models.ARTWORK>
	@foreach (var item in Model.ToList())
	{
		<h4>@Html.ValueForModel(item.Title + " by " + item.ARTIST.ArtistName)</h4>
	}
	
	--------------------------------
	
	@model IEnumerable<Homework_8.Models.CLASSIFICATION>
	@foreach (var item in Model.ToList())
	{
		<h4>@Html.ValueForModel(item.Genre + " : " + item.ARTWORK.Title)</h4>
	}
	```
	
	Artists was a bit different since I have to implement CRUD on it. It wasn't extremely different, but I had to add links to allow CRUD to be implemented. I was planning ahead at this point, so when I 
	created the links, the targest weren't set up correctly. I fixed them in step 6, but am displaying them correctly below. I just included the links after displaying the information for each Artist:
	
	```c#
	@model IEnumerable<Homework_8.Models.ARTIST>
	@{
		ViewBag.Title = "Artists";
	}
	<h2>Artists</h2>
	@foreach (var item in Model.ToList())
	{
		<h4>@Html.ValueForModel(item.ArtistName) 
		@Html.ActionLink("Details", "/Details/" + item.AID)
		@Html.ActionLink("Edit", "/Edit/" + item.AID)
		@Html.ActionLink("Delete", "/Delete/item.AID")</h4>
	}
	```
	
5. I commited to my local repository. This was a requirement to show I used Git while working on my code.

6. The next step was to officially implement CRUD functionality for Artists. I wanted to start with "Details" so I could display the information of each Artist. This was the easiest one to check since I had
the seed data and knew it was correct in the database. I could also use the details page to confirm the create was working properly. So I created a view by right clicking on the "details" action method in the controllera
and clicked on "create view".

	From previous experience I knew that passing the integer primary key via the "id" was an easy way to select only the Artist I wanted to view. Since I had the actions links somewhat set up, I just appeneded the "id" 
	to the URL. The details page was already set up to accept the id, so completed the setup by adding this to the controller action method of details:
	
	```c#
	var artist = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault();
	return View(artist);
	```
	
	This only sent the information of the requested Artist to the view. So when I was setting up the view, I added this line to the top of the view to only manipulate a single Artist:
	
	```c#
	@model Homework_8.Models.ARTWORK
	```
	
	I tested the view for details and it was good to go.
	
	The next one I wanted to work on was create. I created a view for "Create". When I created it with the read/write functions, it created a GET and a POST action method. The GET method simply returned the view with
	no additional information from the controller. On the view, I created a small form to capture the data to be inserted into the database:
	
	```html
	<form method="POST" onsubmit="return validateForm();">
    <display for="Artist Name">Artist's Name</display>
    <input type="text" name="artistName" id="artistname" title="Artist Name" />
    <br /><br />
    <dispay for="Birth City">Birth City</dispay>
    <input type="text" name="birthCity" id="birthCity" title="Birth City" />
    <br /><br />
    <display for="Birth Date">Birth Date</display>
    <input type="date" name="birthDate" id="birthDate" title="Birth Date" />
    <br /><br />
    <input type="submit" value="Submit"/>
	</form>
	```
	
	On the controller for create, I had to create a new Artist object and use the data I collected from the form to populate the new Artist object with values. Since I validate the data on the client side, I just save
	the data to the database after adding the new Artist object tot he database.
	
	```c#
	ARTIST artist = db.ARTISTS.Create();
	artist.ArtistName = collection["artistName"];
	artist.BirthCity = collection["birthCity"];
	artist.BirthDate = collection["birthDate"];
	db.ARTISTS.Add(artist);
	db.SaveChanges();
	```

	I realized I had no way to intereact with the create form, so on the Artists view, I added a link to the create form: 
	
	```c#
	<h3>@Html.ActionLink("Add an Artist", "Create")</h3>
	```
	
	Now that I could create and view Artists, I tested create and it was working and saving to the database. Next I worked on edit. I created the view for edit and copied the form from Create Artist to edit the Artist
	since it was all the same data I needed to manipulate. I added default values by adding the values to the ViewBag on the controller. I wanted to do it differently, but this was the only way I could get it to work. Again,
	I used the id to get the information for the specific Artists. I put that information in the ViewBag so I didn't need to return anything else to view:
	
	```c#
	public ActionResult Edit(int id)
        {
            ViewBag.aName = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().ArtistName;
            ViewBag.aCity = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().BirthCity;
            ViewBag.aDOB = db.ARTISTS.Where(a => a.AID == id).FirstOrDefault().BirthDate;
            return View();
        }
	```
	
	After setting the default values, I found that the seed data for the dates weren't in the correct format that I needed to display the default values. My solution was to adjust the seed data to reflect the formatting I 
	needed. This was acceptable because it was not altering the data, just the formatting. After getting the information into the form, the form used the POST method to send it to the controller. The controller captured
	the information and used the FormCollection data to get the artist and then update the entries. I didn't add a check to see if the data was different, I just updated everything:
	
	```c#
	// POST: Artists/Edit/5
	[HttpPost]
	public ActionResult Edit(int id, FormCollection collection)
	{
		try
		{
			var artistToUpdate = db.ARTISTS.Find(id);

			artistToUpdate.ArtistName = collection["artistName"];
			artistToUpdate.BirthCity = collection["birthCity"];
			artistToUpdate.BirthDate = collection["birthDate"];

			db.SaveChanges();

			return RedirectToAction("Details/" + id);
		}
		catch
		{
			return View();
		}
	}
	```
	
	I confirmed that worked by adding the return to details, that way the user can also verify the changes after they were made. I then moved on to deleting an entry. I added the Delete view. I used the display from Details to
	display the Artists information to ensure the correct Artist was going to be deleted. I added a small form with a POST method:
	
	```html
	<form method="POST">
	<input type="submit" value="Delete Artist and All Their Works" />
	</form>
	```
	
	This allowed me to post information. This wasn't really required, but it was the path I went down to send the data and ensure it wasn't just collecing the view. I queried the database for the Artist by id and then
	remove the artist from the databse and save the database. I returned the user to the Artists list to verify the Artist was deleted:
	
	```c#
	// POST: Artists/Delete/5
	[HttpPost]
	public ActionResult Delete(int id, FormCollection collection)
	{
		try
		{
			var artist = db.ARTISTS.Find(id);

			db.ARTISTS.Remove(artist);
			db.SaveChanges();
			
			return RedirectToAction("Artists");
		}
		catch
		{
			return View();
		}
	}
	```
	
	
7. The requirements of this step were to ensure that while editing an Artist, the name was not allowed to be longer than 50 characters and the date of birth entered could not be in the future. I simply added a max field on the 
name field to ensure it wouldn't allow something longer than 50 characters. As for the date of birth, I included a javascript method on submit. I created a new file in the "scripts" folder name LocalJS. The javascript method 
looks like this:

	```javascript
	function validateForm() 
	{
		// Today's Date
		var today = new Date();
		var dd = today.getDate();
		var mm = today.getMonth() + 1; //January is 0!
		var yyyy = today.getFullYear();
		// /Today's Date

		var DOB = document.getElementById("birthDate").value;
		DOB = DOB.split("-");
		//DOB[0] = Year //DOB[1] = Month //DOB[2] = Day

		// Confirm birthdate is not in the future
		if (DOB[0] > yyyy)
		{
			alert("Birth Date can't be in the future!");
			return false;
		}
		else if (DOB[0] == yyyy)
		{
			if (DOB[1] > mm)
			{
				alert("Birth Date can't be in the future!");
				return false;
			}
			else if (DOB[1] == mm)
			{
				if (DOB[2] > dd)
				{
					alert("Birth Date can't be in the future!");
					return false;
				}
			}
		}
		else
		{   
			return true;
		}
	}
	```
	
	I had to add this line to the top of the view to include the javascript:
	
	```c#
	@section Javascript
	{   <!--Includes the javascript. Still need to list the source below-->
		<script type="text/javascript" src="@Url.Content("/Scripts/LocalJS.js")"></script>
	}
	```
	
	I also had to add this line to the shared layouts:
	
	```c#
	@RenderSection("Javascript", required: false)
	```
	
	I decided to add this code to the Create Artist form as well since it was probably good to not allow future birthdays for artists at all.
	
8. The last thing to do was to add buttons for every Genre to the home page using a Razor foreach loop. When the button was clicked, it had to return all the works of art with that classification to an output list 
or table and replace the previous data. The data to be returned was artwork title and artists name and sorted by title. It had to be done with an AJAX call. The logical first step here was to create the buttons. I also 
added the output div while I was working ont he html.:

	```
	@foreach (var item in Model.ToList())
	{
		<button onclick="makeAjaxCall('@item.Genre1');">@item.Genre1</button>
	}
	<br /><br />
	<div id="output"></div>
	```

	As you can see, I added an onclick event named MakeAjaxCall. That was the next thing to work on in my LocalJS.js file:
	
	```javascript
	function makeAjaxCall(genre)
	{
		document.getElementById('output').innerHTML = null;

		$.ajax({
			url: "/Artists/Genre/",
			data: { genre: genre },
			type: "POST",
			//datatype: "json",
			success: function (returnData) { //On Success, Return Images into a grid
				returnData.arr.forEach(function (item) {
					$('#output').append(item);
				}
				)
			}
		});
	}
	```
	
	That was simple enough from previous experience and struggles. One struggle I ran into was trying to get my Genre class to work. As you will see in my controller, there is a "Genre1" and "GENRE1". Somehow, when running
	my up scripts, I had two tables named Genre, although they weren't exactly named Genre. I found my ArtWork table was actally named Genre. It wasn't that way in the up script, so I don't know how it happend. I fixed it
	by correctly renaming the ARTWORK table. I did not fix the keys inside though. After struggling with that, I finally got the return data to work. I had some help from [stack overflow](https://stackoverflow.com/questions/25304610/how-to-get-a-list-from-mvc-controller-to-view-using-jquery-ajax)
	on this one: 
	
	```c#
	// POST: Artists/Genre
	[HttpPost]
	public JsonResult Genre(string genre)
	{
		var artwork = db.GENRES.Find(genre).CLASSIFICATIONS.ToList().OrderBy(t => t.ARTWORK.Title).Select(a => new { aw = a.AWID, awa = a.ARTWORK.AID }).ToList();
		string[] artworkCreator = new string[artwork.Count()];
		for (int i = 0; i < artworkCreator.Length; ++i)
		{
			artworkCreator[i] = $"<ul>{db.ARTWORKS.Find(artwork[i].aw).Title} by {db.ARTISTS.Find(artwork[i].awa).ArtistName}</ul>";
		}
		var data = new
		{
			arr = artworkCreator
		};
		
		return Json(data, JsonRequestBehavior.AllowGet);
	}
	```
	
	I finally got it work. Not a huge fan of Linq, but I am working with it and maybe eventually I will like it.
	
	