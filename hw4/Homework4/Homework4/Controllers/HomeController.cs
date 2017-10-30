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

            Debug.WriteLine($"{degree}{degreeType}");

            // Initialize variables
            string newDegree = null;
            string newDegreeType = null;
            string newDegreeString = null;

            // If degree was not entered, makes it 0
            if (degree == null || string.Equals(degree, ""))
            {
                degree = '0'.ToString();
            }

            Debug.WriteLine($"{degree}{degreeType}");

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
        
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET";
       
            return View();
        }

        [HttpPost]
        public ActionResult Page2(FormCollection data)
        {
            ViewBag.RequestMethod = "POST";

            // Get the form data
            string degree = data["degree"];
            string degreeType = data["degreeType"];

            Debug.WriteLine($"{degree}{degreeType}");

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

            Debug.WriteLine($"{degree}{degreeType}");

            // create new string
            newDegreeString = string.Concat("The converted temperature is ", newDegree, newDegreeType);
            ViewBag.newDegreeString = newDegreeString;

            return View();
        }

        [HttpGet]
        public ActionResult Page3()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }

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

        public double getMonthlyPayments(float principal, float interest, int numberOfPayments)
        {
            // M = P * ( J / (1 - (1 + J) ^-N ) )
            // M = payment amount
            // P = pricipal
            // J = effective interest rate (example: 5/12 for 5 months)
            // N = total number of payments
            // As found at https://www.wikihow.com/Calculate-Loan-Payments

            //1 get interest rate 5000 
            //1 percent/100. .045
            //2 divide interest rate by 12 .00375
            //3 multiply that by principal 18.75 = temp
            //4 add 1 to (step 2) 1.00375
            //5 step 4 ^ #months included in loan 1.00375^60= 1.25179
            //6 1/step5 1/1.25179  .7988
            //7 1-step6 .2012 temp2
            //8 step3/step7 93.19 
            // gives monthly payment

            // as seen on https://www.youtube.com/watch?v=x77rCEKU29Y

            double temp = ((interest / 100) / 12) * principal;

            double temp2 = 1 - (1 / (Math.Pow((((interest / 100) / 12)  + 1), (double)numberOfPayments)));

            double monthlyPayment = temp / temp2;

            Debug.WriteLine($"{temp}:{temp2}:{monthlyPayment}");

            return monthlyPayment;
        }

        public double getTotalRepayment(double monthlyPayment, double numberOfPayments)
        {
            double totalRepayment = monthlyPayment * numberOfPayments;

            return totalRepayment;
        }

        public double getInterestPaid(double totalRepayment, double principal)
        {
            double interestPaid = totalRepayment - principal;

            return interestPaid;
        }

        [HttpGet]
        public ActionResult FormExample3()
        {
            ViewBag.RequestMethod = "GET";
            return View();
        }
        
        public string SwapDegreeType(string degreeType)
        {
            if (string.Equals(degreeType, "C"))
            {
                return "F";
            }
            else if (string.Equals(degreeType, "F"))
            {
                return "C";
            }
            else
            {
                return "error";
            }
        }

        public string CToF(string degree)
        {
            // Parses string to float, then calculates the new degree = ((temp-32)*(5/9))
            float temp = float.Parse(degree);
            temp = temp - 32;
            temp = temp * ((float)5 / (float)9);
            // Convert Float to String
            return temp.ToString();
        }

        public string FToC(string degree)
        {
            // Parses string to float, then calculates the new degree = (temp*(9/5)+32)
            float temp = float.Parse(degree);
            temp = temp * ((float)9 / (float)5);
            temp = temp + 32;
            // Convert Float to String
            return temp.ToString();
        }
    }
}