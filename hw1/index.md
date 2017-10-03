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

3. Here is a link to my first HTML site: [https://jthatifled15.github.io/cs460/fishing.html](Fishing.html)

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
finally figured out that I had to go to the index page at [https://jthatfield15.github.io/cs460](https://jthatfield15.github.io/cs460).

Once I finally got to where I wanted, I created an index.md page was fairly simple, but gave me links to my homework
to test my links and markdown site. Then I started working on this markdown page that looks better.

All the meanwhile, I had to *stage* my files, *commit* them, and *push* them when I wanted to test an implementation or
switch computers. I also had to make sure the first thing I did was *pull* them from the online repository before I 
started working on them. This way there were no conflicts on versions and no branches to merge.

---------------
[My CS460 Homepage (html)](https://jthatfield15.github.io/cs460/)