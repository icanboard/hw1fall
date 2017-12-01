### Homework 9

Homework 9 - Deploying to the cloud with Azure

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

[Jake's GitHub.io Homepage](https://jthatfield15.github.io/cs460/)

[Jake's Azure site - Homework 8 deployed for Homework 9](http://hw8.azurewebsites.net/)

This assignment was all about deploying my previous project, homework 8, to the cloud using Azure as the host.

The first thing I had to do was create an Azure account with Microsoft. I have done this in the past, so I had to
use a different email account to qualify for the free account. The last time I did this was many years ago and was
for educational purposes for school. The API has changed a lot since then.

After creating the account, we want to go to the [Azure site](https://portal.azure.com) and log in.

I might have skipped a step or two in this walkthrough because I started doing before I read the assignment. I didn't write down all the steps as I 
went because I was trying to see if I could do it on my own. I didn't make it far before I decided I should check the assignment for guidance so I didn't 
ruin anything and that's when I noticed I was supposed to be taking notes on every step. I tried to recall as many of the steps that I did, but I can't 
guarantee that I remembered all of them.

The first thing I remember doing was creating a new database. I clicked on the SQL databases tab on the left side and then the '+ Add' to add a new database.
I gave it a name, HW8, because it was the database for HW8. I filled out the rest of the form. I already had a server from when I was breezing through it, but I created a new
one to demonstrate the steps. Two things I changed were the 'Pricing tier' and the 'Pin to dashboard'.

![Adding a new database](https://jthatfield15.github.io/cs460/hw9/1.JPG)

Before creating the new database, I had to add a server. I clicked the button and followed the prompts. The information shown is all bogus, so don't use it to follow along with the rest of the images.

![Creating a Server](https://jthatfield15.github.io/cs460/hw9/2.JPG)

After the server was created, I created the database as well. It took a short amount of time to finish. I ensured it was created correctly.

![SQL Database is online](https://jthatfield15.github.io/cs460/hw9/3.JPG)

The next thing I did was download SSMS, or SQL Server Management Studio. This was recommended in class and it made this next step easy. After installing it and opening SSMS, 
I created opened the up script from the project folder. Simply put: FILE-OPEN-FILE or ALT-F, ALT-O, ALT-F. I selected the up script and loaded it in. I connected to the database with the
drop down menu. It was already listed, so I don't know how to explain this step. I just ensured that it was on the right database and then clicked execute.

![Execute the up script](https://jthatfield15.github.io/cs460/hw9/3.JPG)

I wanted to test the data so I did a quick query. It all looks good.

![Confirmed the data was valid](https://jthatfield15.github.io/cs460/hw9/6.JPG)

I went back to the Azure Portal and created a new web app. I clicked on App Services, then '+ Add', and then Web App.

![Create a new web app](https://jthatfield15.github.io/cs460/hw9/7.JPG)

That brought up a new window where I just clicked Create.

![Create the web app](https://jthatfield15.github.io/cs460/hw9/8.JPG)

From there, I followed the prompts and filled out the form. I already had the resource group from creating the database, so I put the resources together. This is where the projects
URL comes from for the web app. I thought HW8 would be fitting since the deployment was of homework 8's project, but looking back, HW9 would have been more fitting. Make sure to pin it to
the dashboard and create it.

![Still creating the web app](https://jthatfield15.github.io/cs460/hw9/9.JPG)

After the web app was complete, I went to Visual Studios to deploy the project. I opened Homework 8 and then in the Solution Explorer, right clicked on the projects name, and then clicked publish.

![Publish from Visual Studios](https://jthatfield15.github.io/cs460/hw9/10.JPG)

The first time you publish, it prompts you for some specific information. I wanted to create an Azure App, so I clicked on that. I also had an existing web app, so I selected that. It would have been faster
if I would have skipped the last steps and just created the web app from here, but I was following the notes I had. I then clicked publish.

![Publish already](https://jthatfield15.github.io/cs460/hw9/11.JPG)

I wasn't signed in with the correct email, so I got a bit of the run around here. After fixing that issue, it was easy to click on HW8, the web app I created. Don't bother with the Deployment Slots at this point. 
Then click OK.

![Ready to Publish](https://jthatfield15.github.io/cs460/hw9/12.JPG)

Back on the Azure Portal, I needed to connect my database to my web app. I clicked on SQL databases, then clicked the database I wanted, and then clicked connection strings. This brought up my connection string
and I clicked the click to copy button.

![Get the connection string](https://jthatfield15.github.io/cs460/hw9/13.JPG)

Then I had to plug in the connection string. I clicked on App Services, then clicked the web app I was working on, then clicked Application settings. I scrolled down to the Connections string. The name 
should be the same as the context file that interacts with the database. The value is the connection string, but you have to replace the username and password in the string to allow you access the 
database. After all the information is in and verified, click the save the button at the top.

![Saving the connection string](https://jthatfield15.github.io/cs460/hw9/14.JPG)

If everything went as it should have, the web app is up and running and the database is connected to it. Hurray!!!

![My app is on the web!!!](https://jthatfield15.github.io/cs460/hw9/15.JPG)