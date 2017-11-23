### Homework 7

Homework 7 - Using an API

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

[Jake's GitHub.io Homepage](https://jthatfield15.github.io/cs460/)

For this homework, I was tasked with creating a website the interacted with Giphy API. I needed to allow the user
to enter a search term and send a request to Giphy to get the results and display them on my site. This had to be
an asynchronous call using ajax. 

[Youtube Demo of my site in action](https://youtu.be/7-mm6JBx5Fs)

![Empty Form](https://jthatfield15.github.io/cs460/hw7/1.JPG) 

![Search Complete](https://jthatfield15.github.io/cs460/hw7/2.JPG) 
	
I started the project by creating an empty MVC project. I removed the nav bar and footer from the Shared/_Layout.cshtml
per the instructions as well. I then added a form to my Index to allow me to get a search term from the user.
The next thing I had to do was go to the Giphy site for developers and register to get an API key. After getting the 
API key, I had to work on setting up the configuration to use the API key. It took me a couple attempts to get this to
work correctly. Since the API key is private, I needed to store it in a file on my local machine outside of the repository.
I stored it one level up from my repository so I could access it with the a local path. I named the file Giphy.config. 
I had to put this inside the file:

```c#
<appSettings>
	<add key="GiphyAPIKey" value=" ...API Key... " />
</appSettings>
```
Inside the global web.config file I appended this inside the <appSettings> tag:

```c#
<appSettings file="..\..\..\..\Giphy.config">
```

Inside the controller, I pulled out the API Key and logged it to test:

```c#
string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
Debug.WriteLine("API key = " + apiKey);
```

Now that I had my API key working, I was ready work on getting data from Giphy. I started doing this in the incorrect way: I 
was passing the API Key to the client and creating a URL request string to query Giphy. This was fine while I was working
locally, but as soon as I put this anywhere else and the client had access to the API Key, I would have major confidentiality
and security issues. This left my GiphyImage controller as a shell just to get to the Index page. From the Index page, I called
the Search controller to and had it return the information I needed.

So inside my Search controller I added the paramaters that I wanted to pass from the client to query Giphy. These included the 
termString, which was the words the user wanted to query. I converted the spaces in the string to '-' as Giphy does on their site
when searching for multi-word strings. I did this using javascript on the client side to lesson the load on my server (not that
my server is under stress, but this sounded good when I was doing it). I did some research to ensure that I wasn't just replacing
the first space, but all the spaces, so I used the code below to accomplish that.

```javascript
var termString = searchTerms.split(" ").join('-'); //change spaces to - as Giphy does on their site
```

I also passed the topResult string and rating string to my Search controller. I used kept these strings in their original state so 
I could log them in the database as their original terms. This would save minimal space in the database, but it was
the reason for my decision. After passing in the variables and I had the API key, I was able to build the request URL:

```c#
 public ActionResult Index(string termString, string topResult, string rating)
	{
		...
		var requestURL = "http://api.giphy.com/v1/gifs/search?q=" + termString + topResult + ratingString + "&api_key=" + apiKey;
	}
```
From there, I just took the string I made and pasted it int he browser to confirm it worked. It did, so I continued to 
research how to create the request using a .ajax call. The first issue I ran into was trying to pass the parameters. The first
thing I found said to use a .post request instead so passing the parameters in was easier. I could understand it. I started
with that and created a .post request. This was all done on my javascript, which I had put in a seperate file name LocalJS.js in
my Scripts folder. I linked my Index page with to the javascript with this bit of code:

```html
@section Javascript 
{   <!--Includes the java script. Still need to list the source below-->
	<script type="text/javascript" src="@Url.Content("/Scripts/LocalJS.js")"></script>    
}
```

I also added the script to source to the inside of the <body> tag in my shared _Layout.cshtml file:

```html
<body>

<div class="container body-content">
	@RenderBody()
	@RenderSection("Javascript", required:false)
</div>

<script src="~/Scripts/jquery-1.10.2.min.js"></script>
<script src="~/Scripts/bootstrap.min.js"></script>
<script src="~/Scripts/LocalJS.js"></script>

</body>
```

So now, in my javascript, I had a .post call, which I converted a .ajax call very easily after I grasped what was going on. It looks
like this:

```javascript
$.ajax({
	url: "/Search/",
	type: "POST",
	data: { termString: termString, topResult: topResult, rating: rating },
	success: function (returnData) { //On Success, Return Images into a grid 
		returnData.data.forEach(function (item) {
			$('#output').append(`<div class="col-lg-4 imgDiv"><img src="${item.images.fixed_height.url}" class="col-lg -4 imgClass"></div>`);
		}
	)}
});
```

The $ indicated it is jquery. The ajax call works by creating key value pairs, with the url being a custom route I defined in my routeConfig.cs file
to route directly to my Search controller, which is only used for asynchronous calls to Giphy and returns the results to the clients javascript call.
The key value pairs indicate I am contacting my url, "/Search/" with a "POST" method. The data is the parameters and they are in key/value pairs as well.
The success was the tricky part. What it means is on a successful call, it will run a function using the returnData. With the returnData, each item in the 
return data will be used to append the "output" div with a column of <img> tags with the source being the value returned from Giphy. I used the 
fixed_height.url since they would scale nicely in my grid view. I wrapped the images in a div to allow me to set the column width on each one. I wanted
to display three per row, so I set the columns to a width of four.

Of course, I could only create the grid after getting the correct response from Giphy. This gave me some trouble as I was getting a json object back.
I thought I was getting the wrong response because there was so much data included, but I was getting the right thing back. I just had to learn to work
through the response. When I looked at the response I received by directly inputing the URL string to the browswer, I could see I was getting a json object,
but doing it through the server, I was getting a lot of nothing. I found a couple sites that helped me create a WebRequest object, a serializer (or deserializer),
and how to parse the json object. The first being a [Microsoft link](https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class)
and the second a [Stack Overflow link](https://stackoverflow.com/questions/20437279/getting-json-data-from-a-response-stream-and-reading-it-as-a-string).
I ultimately came up with this code to get what I needed from the server:

```c#
// build a WebRequest
WebRequest request = WebRequest.Create(requestURL);

// get the response from the WebRequest via the passed URL
WebResponse response = request.GetResponse();

// build a Stream AND get the Stream Response
Stream dataStream = response.GetResponseStream();

//StreamReader reader = new StreamReader(dataStream);
StreamReader reader = new StreamReader(response.GetResponseStream());

// Read the content.  
string responseFromServer = reader.ReadToEnd();

// Display the content.  
Debug.WriteLine(responseFromServer);

// Clean up the streams and the response.  
reader.Close();
response.Close();

// Create a JObject, using Newtonsoft NuGet package
JObject json = JObject.Parse(responseFromServer);
Debug.WriteLine(json);

// Create a serializer to deserialize the string response (string in JSON format)
JavaScriptSerializer serializer = new JavaScriptSerializer();

// Store JSON results in results to be passed back to client (javascript)
var results = serializer.DeserializeObject(responseFromServer);  
```

I also had to deal with returning the json object correctly and then allow access to the URL's I returned. Returning the json object was as 
easy as telling MVC I was returning a json object. To allow the URL's to be used I had to tell it to allow the objects to use a get request. 
It looked like this:

```c#
// return the Json object
return Json(results, JsonRequestBehavior.AllowGet);
```

Finally, I had to do some css magic to get the images, grid, and general page to look nice. I did a decent job, although I am no web designer. I used 
different elements to tie my page together and ultimately, I think it came out looking decent. I would be lying if I said it were perfect. 

The last part of the project was to attach a database to capture some information about the requests. This required creating a new local database, writing 
and up script and a down script, creating a model from the database, add the "using Homework7.Models" line in the controller, adding the dbContext class and 
moving that into the DAL folder, and creating the connection string. All of which has been explained in the previous homework assignments and were simple
steps for me now that I have done them. Capturing the data in the database looked like this:

```c#
// build new Request to enter into db
Request userInfo = db.Requests.Create();

// add all the attributes of a user request to add it to the db
userInfo.RequestDate = DateTime.Now;
userInfo.RequestString = termString;
userInfo.Rating = rating;
userInfo.UserIP = userIP;
userInfo.UserAgent = userAgent;

// sets empty string or null to ---, allows save to database of emptry string
if (userInfo.RequestString == null || userInfo.RequestString == "")
{
	userInfo.RequestString = "---"; 
}

// add to and save the db
db.Requests.Add(userInfo);
db.SaveChanges();
```

The two things I had to get from the user that I didn't already have were the user's IP address and the user's agent information, which is the 
information about their browswer. The userIP is always going to be the IPv6 version of the local callback address of "::1" while working on my
local host and I used the same browswer for each request so it was always the same as well. I used these commands to capture that data:

```c#
// get userIP and userAgent for tracking purposes
string userIP = Request.UserHostAddress;
string userAgent = Request.UserAgent;
```

![Search Complete](https://jthatfield15.github.io/cs460/hw7/3.JPG) 

I wanted to capture the entire URL string, but I logged the data after I built the string so it contained the API Key, so I opted not to log it.

Now I have a function website that asynchronously searches Giphy for gifs and logs information about the user in my database while nicely displaying
information the user requested in my webpage. The page doesn't reload when a user submits a search, it calls the server, gets the response and 
dynamically displays it on the screen in a matter of moments.