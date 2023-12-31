﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        /*ALT 1*/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
        public IActionResult Index()
        {
            return View();
        }

        /*ALT 1*/
        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}

        /*ALT 2*/
        //// GET: /HelloWorld/Welcome/ 
        //// Requires using System.Text.Encodings.Web;
        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //}

        /*ALT 4*/
        //public string Welcome(string name, int ID = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //}


        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}