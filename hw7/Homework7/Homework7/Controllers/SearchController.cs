using Homework7.Models; //required to add the dbcontext class
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Homework7.Controllers
{   
    public class SearchController : Controller
    {
        // Gets me access to the database via the dbContext
        private RequestContext db = new RequestContext(); // brings in dbcontext

        // GET: Search
        // Gets the API Key and sets up a URL for a request to the other server (GIPHY), reads the response and
        // deserializes it to pass it back to javascript to display on the client. Also logs request info in db.
        // param termstring: the search terms
        // param topResult: if the user only wants the top result
        // param rating: the rating the user is requesting (default currently set to Y)
        // return JSON object
        public ActionResult Index(string termString, string topResult, string rating)
        {
            // get the api key from a file outside the repo
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];

            // Debug to Debugger output to confirm things are working
            Debug.WriteLine("API key = " + apiKey);
            Debug.WriteLine("termString = " + termString);
            Debug.WriteLine("topResult = " + topResult);
            Debug.WriteLine("rating = " + rating);

            // If topResult isn't checked, limit to 18 results for better appearance
            if(topResult == "")
            {
                topResult = "&limit=18";
            }

            var ratingString = "&rating=" + rating;

            // build the requestURL
            var requestURL = "http://api.giphy.com/v1/gifs/search?q=" + termString + topResult + ratingString + "&api_key=" + apiKey;
            Debug.WriteLine("requestURL = " + requestURL);

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

            // get userIP and userAgent for tracking purposes
            string userIP = Request.UserHostAddress;
            string userAgent = Request.UserAgent;
            Debug.WriteLine(userIP);
            Debug.WriteLine(userAgent);

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
            
            // return the Json object
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}