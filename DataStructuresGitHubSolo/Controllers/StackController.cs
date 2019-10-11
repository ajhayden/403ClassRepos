using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresGitHubSolo.Controllers
{
    public class StackController : Controller
    {

        //Creates a stack 
        static Stack<string> myStack = new Stack<string>();

        //Creates a stopwatch
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            return View();
        }
        
        //This adds one entry
        public ActionResult AddOne()
        {
            myStack.Push("New Entry: " + (myStack.Count + 1));
            return View("Index");
        }

        //This adds 2000 entries
        public ActionResult AddHugeList()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry: " + (myStack.Count + 1));
            }
            return View("Index");
        }

        //This displays all entries
        public ActionResult Display()
        {
            if (myStack.Count() == 0)
            {
                ViewBag.Error = "There are no entries to display";
            }
            
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //This deletes the specific entry 9
        public ActionResult Delete()
        {
            string deleteString = "New Entry: 9";
            int myStackCount = myStack.Count();
            Stack<string> tempStack = new Stack<string>();
            ViewBag.Error = "The chosen entry does not exist.";

            for (int iCount = 0; iCount < myStackCount; iCount++)
            {
                string currentItem = myStack.Pop();

                if (currentItem != deleteString)
                {
                    tempStack.Push(currentItem);
                }
                else
                {
                    ViewBag.Error = null;
                    break;
                }
            }

            while (tempStack.Count() != 0)
            {
                string tempStackItem = tempStack.Pop();
                myStack.Push(tempStackItem);
            }
            return View("Index");
        }

        //This deletes all entries
        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyStack = null;
            return View("Index");
        }

        //This searches for entry 9 and then records search time
        public ActionResult Search()
        {
            sw.Start();

            string searchString = "New Entry: 9";
            int myStackCount = myStack.Count();
            Stack<string> tempStack = new Stack<string>();

            ViewBag.SearchInfo = "Entry 9 was not found.";


            for (int iCount = 0; iCount < myStackCount; iCount++)
            {
                string currentItem = myStack.Pop();
                tempStack.Push(currentItem);

                if (currentItem == searchString)
                {
                    ViewBag.SearchInfo = "Entry 9 was found.";
                    break;
                }
                
            }

            while (tempStack.Count() != 0)
            {
                string tempStackItem = tempStack.Pop();
                myStack.Push(tempStackItem);
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = "Time elapsed to search for entry: " + ts;

            ViewBag.MyStack = null;
            return View("Index");
        }

        //Return to HomeController and index method
        public ActionResult ReturnHome()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}