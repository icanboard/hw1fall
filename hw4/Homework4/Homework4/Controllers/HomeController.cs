using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {

        // Controller Action Methods
        // GET ~/Home/Index
        // GET ~/Home
        // GET ~/
        public ActionResult Index()
        {
            
            return View();
        }
        
        // GET ~/Home/Page1
        public ActionResult Page1()
        {
            // Request the form data
            string degree = Request["degree"];
            string degreeType = Request["degreeType"];

            //Debug.WriteLine($"{degree}{degreeType}");

            // Initialize variables
            string newDegree = null;
            string newDegreeType = null;
            string newDegreeString = null;

            // If degree was not entered, makes it 0
            if (degree == null || string.Equals(degree, ""))
            {
                degree = '0'.ToString();
            }

            //Debug.WriteLine($"{degree}{degreeType}");

            // Calculates the new temperate for C or F
            if (string.Equals(degreeType, "C"))
            {
                // Swaps the degreetype from C to F
                newDegreeType = SwapDegreeType(degreeType);
                // Gets the converted temperature
                newDegree = FToC(degree);
            }
            else if (string.Equals(degreeType, "F"))
            {
                // Swaps the degreetype from F to C
                newDegreeType = SwapDegreeType(degreeType); 
                // Gets the converted temperature
                newDegree = CToF(degree);
            }
            
            // if newDegree is not null, print the converted temperature
            if (newDegree != null)
            {
                newDegreeString = string.Concat("The converted temperature is ", newDegree, newDegreeType);
                ViewBag.newDegreeString = newDegreeString;
            }

            Debug.WriteLine($"{degree}{degreeType}");

            return View();
        }

        // GET ~/Home/Page2
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
       
            return View();
        }

        // POST ~/Home/Page2
        [HttpPost]
        public ActionResult Page2(FormCollection data)
        {
            ViewBag.RequestMethod = "POST";

            // Get the form data
            string degree = data["degree"];
            string degreeType = data["degreeType"];

            //Debug.WriteLine($"{degree}{degreeType}");

            // If degree was not entered, makes it 0
            if (degree == null || string.Equals(degree, ""))
            {
                degree = '0'.ToString();
            }

            // Initialize variables
            string newDegree = null;
            string newDegreeString = null;

            //convert the degree 
            if (string.Equals(degreeType, "C"))
            {
                newDegree = FToC(degree);
            }
            else if (string.Equals(degreeType, "F"))
            {
                newDegree = CToF(degree);
            }
            // convert the degree type
            string newDegreeType = SwapDegreeType(degreeType);

            //Debug.WriteLine($"{degree}{degreeType}");

            // create new string
            newDegreeString = string.Concat("The converted temperature is ", newDegree, newDegreeType);
            ViewBag.newDegreeString = newDegreeString;

            return View();
        }

        // GET ~/Home/Page3
        [HttpGet]
        public ActionResult Page3()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

        // POST ~/Home/Page3
        [HttpPost]
        public ActionResult Page3(float? principal, float? interest, int? numberOfPayments, float? totalRepayment)
        {
            ViewBag.RequestMethod = "POST";
            ViewBag.principal = principal;
            ViewBag.interest = interest;
            ViewBag.numberOfPayments = numberOfPayments;

            if (principal == null || string.Equals(principal, ""))
            {
                principal = 5000;
            }
            if (interest == null || float.Equals(interest, ""))
            {
                interest = (float)4.5;
            }
            if (numberOfPayments == null || string.Equals(numberOfPayments, ""))
            {
                numberOfPayments = 60;
                ViewBag.numberOfPayments = 60;
            }
            
            ViewBag.monthlyPayment = (float)getMonthlyPayments((float)principal, (float)interest, (int)numberOfPayments);
            ViewBag.totalRepayment = (float)getTotalRepayment(ViewBag.monthlyPayment, (int)numberOfPayments);
            ViewBag.interestPaid = (float)getInterestPaid(ViewBag.totalRepayment, (float)principal);

            return View();
        }
        
        // Changes the degree type for display purposes.
        // param string degreeType
        // return string (swapped degree type)
        public string SwapDegreeType(string degreeType)
        {
            // swap C to F
            if (string.Equals(degreeType, "C"))
            {
                return "F";
            }
            // swap F to C
            else if (string.Equals(degreeType, "F"))
            {
                return "C";
            }
            // unknown input, return error
            else
            {
                return "error";
            }
        }

        // Converts Celsius to Fahrenheit
        // param string degree
        // return string (degrees in Fahrenheit)
        public string CToF(string degree)
        {
            // Parses string to float, then calculates the new degree = ((temp-32)*(5/9))
            float temp = float.Parse(degree);
            temp = temp - 32;
            temp = temp * ((float)5 / (float)9);

            // Convert Float to String
            return temp.ToString();
        }

        // Converts Fahrenheit to Celsius
        // param string degree
        // return string (degrees in Celsius)
        public string FToC(string degree)
        {
            // Parses string to float, then calculates the new degree = (temp*(9/5)+32)
            float temp = float.Parse(degree);
            temp = temp * ((float)9 / (float)5);
            temp = temp + 32;

            // Convert Float to String
            return temp.ToString();
        }
        
        // calculates the monthly payment with a given the principal, interest, and number of payments
        // params are floats, but calculations are done and returned as doubles for better accuracy
        // param float principal
        // param float interest
        // param int numberOfPayments
        // return double monthlyPayment
        public double getMonthlyPayments(float principal, float interest, int numberOfPayments)
        {
            // M = P * ( J / (1 - (1 + J) ^-N ) )
            // M = payment amount
            // P = pricipal
            // J = effective interest rate (example: 5/12 for 5 months)
            // N = total number of payments
            // As found at https://www.wikihow.com/Calculate-Loan-Payments

            // Another run through, using test data and in codable form
            //0 get interest 4.5 principal 5000 numberOfPayments 60
            //1 percent/100. .045
            //2 divide interest rate by 12. .00375
            //3 multiply that by principal 18.75 = temp
            //4 add 1 to (step 2) 1.00375
            //5 step 4 ^ #months included in loan 1.00375^60= 1.25179
            //6 1/step5 1/1.25179  .7988
            //7 1-step6 .2012 temp2
            //8 step3/step7 = monthly payment = 93.19 
            // as seen on https://www.youtube.com/watch?v=x77rCEKU29Y

            // Steps 1 through 3
            double temp = ((interest / 100) / 12) * principal;

            // Steps 4 through 7
            double temp2 = 1 - (1 / (Math.Pow((((interest / 100) / 12) + 1), (double)numberOfPayments)));

            // Step 8
            double monthlyPayment = temp / temp2;

            //Debug.WriteLine($"{temp}:{temp2}:{monthlyPayment}");

            return monthlyPayment;
        }

        // gets the total repayment of the loan, principle and interest
        // param double monthlyPayment
        // param double numberOfPayments
        // return double totalRepayments
        public double getTotalRepayment(double monthlyPayment, double numberOfPayments)
        {
            double totalRepayment = monthlyPayment * numberOfPayments;

            return totalRepayment;
        }

        // gets the total interest paid on the loan
        // param double totalRepayment
        // param double principal
        // return double interestPaid
        public double getInterestPaid(double totalRepayment, double principal)
        {
            double interestPaid = totalRepayment - principal;

            return interestPaid;
        }
    }
}