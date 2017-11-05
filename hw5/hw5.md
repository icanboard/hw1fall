### Homework 5

[Jake's CS460 Repository](https://github.com/jthatfield15/cs460/)

[Jake's GitHub.io Homepage](https://jthatfield15.github.io/cs460/)

In this assigment, I added to what I learned in the last assignment of MVC and Visual Studios by implementing
a mySql database. I had to create an up.sql and down.sql script. Get the connectivity to work. Create a form to 
enter and collect data. Finally, input that data into our database. One of the requirements was to use stronly typed views
and avoid using pre-generated (scaffolded) code.

1. I started off by creating an empty MVC project. I already had my .gitignore file included in my repository so I skipped
that step. I created a simple landing page with links to the pages I created that you can interact with. 

2. The database and model I created reflected the [DMV form 735-6438, Change of Address Notice For DMV Records](http://www.oregon.gov/ODOT/Forms/DMV/6438fill.pdf). 

3. I was tasked with including everything from the form with the exception of the voter information and signature. I was only
required to collect one address as fll, either the new or old. It was also requested that we break the "city, state, zip"
into three entries.

4. The natual starting place for a project like this was the database. I started by writing my up.sql script by collecting 
the requirements of the form and putting them into their own columns. As I wrote the name, I decided if the field was required
or not, the type of the input, and the size for that input. Although we were using Transactional SQL (T-SQL) for this assignment,
I am very familiar with the mySql, so this was a fairly simple step for me with the exception of making up data. Here is a snippet.

	```sql
    CREATE TABLE dbo.CUSTOMERS
    (
	CID					INT IDENTITY (1,1) NOT NULL,
	ODL					NVARCHAR(7) NOT NULL,
	...
    )
    INSERT INTO dbo.CUSTOMERS (ODL, DOB, FullName, StreetAdd, CityAdd, StateAdd, ZipAdd, CountyAdd, DateSigned) VALUES
    ```
    
    As you can see, I started with an primary key, which I named CID for Customer ID. I also had to write a down.sql file to drop the table. Again, this was a trivial task.
    
    ```sql
    DROP TABLE IF EXISTS dbo.CUSTOMERS;
    ```
    One thing to be careful of here is that you need to be accessing the correct database in the drop down menu. If you add this
    to the master database, it won't connect like it is supposed to and it will appear that it is broken (because it kind of is).
    
    ![Succesful addition of my table](https://jthatfield15.github.io/cs460/hw5/4-1.JPG)
    
5. After I had the base (the database), I created the model. It was fairly simple to replicate it according to how I built the database.
I added some necessary allocation tags, such as the [Required] tag where appropriate. I also created the db context class 
to allow the database and model to work fluently together. I stored the db context file, named CustomerContext.cs, in the DAL foler inside
the Models folder. This is to keep track of the Data Access Layer so I know where it is when I need it.

6. After I linked everything together, needed to get the connection string to allow everything to actually work together. I found the 
connection string by looking at the properties of my database in the SQL Server Object Explorer. After I found the string, I placed it 
inside a <ConnectionString> tag inside the top-level Web.cofig file. I tested the connection, and it work!

7. The next logical step was to create a controller. This allowed me to access my database via my views. Then I created my action methods.
By using the GET-POST-Redirect pattern, I was able to get the view via a GET call, input the data into the form on the view and retrieve 
it via a POST call. After I received the POST call, I checked if the data was valid. If it was valid, I added the data to the database and sent
the user to a "Submission Successful" page. If the data was invalid, I sent the user to a "Submission Failed" page with a link to try again.

8. The action methods called the views, which is the next thing I built. The first view displays all the information about the
customers in the database. Since I added five entries with my up.sql script, there are initially five entries. There is a link at the top
navigation bar to create a new customer. If this form were to be functionally exact, it would be called something like "update customer",
but I don't edit the customers at this point because there just isn't enough data to work with. Validation has been built in to the form, but
it is still possible to submit the form with null values. This doesn't break the form, but sends the user to a submission failed page. 

9. Here is a demonstration (I compressed the window size to allow it to fit on a smaller screen):

Home Page - Displays all customers in the CUSTOMERS table.
![Home Page - Displays all customers in the CUSTOMERS table.](https://jthatfield15.github.io/cs460/hw5/9-1.JPG)

CreateCustomer Page - Blank Form ready for entry.
![CreateCustomer Page - Blank Form ready for entry.](https://jthatfield15.github.io/cs460/hw5/9-2.JPG)

Populated Form - Form is populated and ready to submit.
![Populated Form - Form is populated and ready to submit.](https://jthatfield15.github.io/cs460/hw5/9-3.JPG)

Submission Successful - Page displayed after a successful submission.
![Submission Successful - Page displayed after a successful submission.](https://jthatfield15.github.io/cs460/hw5/9-4.JPG)

Entry Added - The entry was added to the database and displayed correctly.
![Entry Added - The entry was added to the database and displayed correctly.](https://jthatfield15.github.io/cs460/hw5/9-5.JPG)

Populated Form With One Field Missing - Missing a field because I am trying to break the form.
![Populated Form With One Field Missing - Missing a field because I am trying to break the form.](https://jthatfield15.github.io/cs460/hw5/4-6.JPG)

Submission Failed - Page displayed after a failed submission.
![Submission Failed - Page displayed after a failed submission.](https://jthatfield15.github.io/cs460/hw5/4-7.JPG)