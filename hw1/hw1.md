### Homework 1

1. The first thing to tackle was to download and install the *command line version* of the Git control system.
This was pretty simple. I just typed "Git Hub" into Google and I landed at [Github](Github's home page).
From there, I downloaded the command line version.

2. After the quick download, the next task was to create an account. I followed the prompts on the site and 
completed that task fairly easily (thinking of a password can be difficult at times). This step also included
setting up and syncing my environment. I started by creating a directory called "cs460repo" and eventually 
changed it to just "cs460" for clarity.
One super important step that needs to be done after creating a directory but before you can push, pull or fetch,
is to initialize the directory. The command to do that is 'git init' which is short for initialize.
I also started with a "README.md" file as recommended by the Github
tutorial (it still exists at this moment). I started writing my HTML code for part 3 and saved it in my repo.
After it was saved, I staged it using "git add index.html" and then committed it using "git commit -m" followed
by a commit message. Lastly, I pushed that onto the server with push command. Let's have a look at that code:

	```bash
	mkdir cs460
	cd cs460/
	git init
	git add index.html
	git commit -m "initial commit"
	git push origin master
	```

3. Here is a link to my first HTML site: [Fishing.html](https://jthatifled15.github.io/cs460/hw1/index.html)
	This site was created without the use of a WYSIWYG. I referenced my favorite site when needed: [W3Schools](https://www.w3schools.com/).
	Not using a WYSIWYG and maintaining a consist look was one of the main requirements.
	The other requirements that I had to follow (followed by code) were:
	  * Use Bootstrap for the layout of all pages
	
	```html
	<head>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" 
			integrity="sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ" crossorigin="anonymous">
	</head>"
	
	  * Use single column and multi-column format 
	
	"<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<p class="text-center">A List of Pros and Cons for Fishing</p>
			</div>
		</div>
		<div class="row">
			<div class="col-lg-6">Pros
				<ul>
					<li>Catching your own dinner is rewarding.</li>
					<li>Fishing is relaxing.</li>
					<li>You can catch trophy fish and brag about them to your friends.</li>
				</ul>
			</div>

			<div class="col-lg-6">Cons
				<ul>
					<li>It stinks when you don't catch fish.</li>
					<li>Getting tangles in your line can be stressful.</li>
					<li>No one knows if you are telling the truth about your stories without proof.</li>
				</ul>
			</div>
		</div>
	</div>
	```
	
	* Use a seperate CSS file
	
	```html
	<head>
		<link rel="stylesheet" href="localStyles.css">
	</head>
	```

	```css
	.navbar-default {
    background-color: #87c8ff;
    border-color: #e7e7e7;
	}

	.navbar-default .navbar-brand {
		color: #926448;
	}

	.footer.style {
		background-color: #87c8ff;
	}

	table, th, td {
		border: 1px solid black;
		border-collapse: collapse;
	}
	```

	* Use a navigation bar

	```html
	<nav class="navbar navbar-default" role="navigation">
		<div class="container">
			<div class="navbar-header"></div>
			<a class="navbar-brand" href="fishing.html">Home</a>
			<a class="navbar-brand" href="species.html">Species</a>
			<a class="navbar-brand" href="gear.html">Gear</a>
		</div>
	</nav>
	```

	* Create an ol

	```html
	<ol>
		<li>snacks</li>
		<li>bait</li>
		<li>pole</li>
		<li>tackle</li>
		<li>something to sit on</li>
	</ol>
	```

	* Create an ul

	```html
	<ul>
		<li>Catching your own dinner is rewarding.</li>
		<li>Fishing is relaxing.</li>
		<li>You can catch trophy fish and brag about them to your friends.</li>
	</ul>
	```
	
	  * Create a dl
	  
	```html
	<dl>
		<dt>Fishing Rod</dt><dd>- Used in conjuction with a fishing reel. It allows you to apply tension to the line.</dd>
		<dt>Fishing Reel</dt><dd>- Used to keep your line organized. It allows you to cast the line and "reel" it in.</dd>
		<dt>Fishing Line</dt><dd>- Uses the hook to catch the fish and allows you bring the fish to you.</dd>
	</dl>
	```
	
4. Steps 1 through 3 were performed on my laptop. I also needed to clone the repository onto my desktop. After
performing step 1 above on my desktop, I performed some of the same commands to set up my directoy and initial
the repository. The change happened after that when I had to set up the remote. The remote is the also known as
the remote site where the repository is located. After setting up my remote with 'git remote' commands, I also 
had to log into Github and authenticate who I was. This was done via a pop up window and it saved my credentials
because I don't have to log in to do it any more.
Here is the code I used to clone my repository as step 4 required:

	```bash
	mkdir cs460
	cd cs460/
	git init
	git remote add origin https://github.com/jthatfield15/cs460
	git remote -v
	git pull origin master
	git status
	```

5. This was one of the harder steps as it was hard for me to decipher between the Github repository "page" that I 
created and the Github Pages "page" feature that I was supposed to turn on. I did a little searching on Google and
found that I only had to go into settings and turn it on. After clicking the "on" switch in settings, I had to 
figure out how to navigate it. This took a little longer to figure out since I had to also navigate to my index.html
page. I kept trying to go directly to https://jthatfield15.github.io/ but there is index at that location. I 
finally figured out that I had to go to the index page at https://jthatfield15.github.io/cs460.

	Once I finally got to where I wanted, I created an index.md page was fairly simple, but gave me links to my homework
	to test my links and markdown site. Then I started working on this markdown page that looks better.

	All the meanwhile, I had to *stage* my files, *commit* them, and *push* them when I wanted to test an implementation or
	switch computers. I also had to make sure the first thing I did was *pull* them from the online repository before I 
		started working on them. This way there were no conflicts on versions and no branches to merge.

---------------
[My CS460 Homepage (html)](https://jthatfield15.github.io/cs460/)