using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures2._0.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, Nullable<int>> myDict = new Dictionary<string, Nullable<int>>();
        public int indexToDelete;

        public ActionResult IndexD()
        {
            ViewBag.Dict = myDict;
            return View();
        }

        public ActionResult AddOne()
        {
            if (myDict.Count > 0)
            {
                myDict.Add(String.Concat("New Entry ", myDict.Values.Last() + 1), myDict.Values.Last() + 1);
            }
            else
            {
                myDict.Add("New Entry 1", 1);
            }

            ViewBag.Dict = myDict;

            return View("IndexD");
        }

        public ActionResult AddHuge()
        {
            myDict.Clear();
            int numToAdd = 2000;

            for (var iCount = 1; iCount <= numToAdd; iCount++)
            {
                myDict.Add(String.Concat("New Entry ", iCount), iCount);
            }
            ViewBag.Dict = myDict;
            return View("IndexD");
        }

        public ActionResult Display()
        {
            ViewBag.Dict = myDict;
            return View("IndexD");
        }

        public ActionResult DeleteFrom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteItem(Nullable<int> index = null)
        {
            try
            {
                myDict.Remove(String.Concat("New Entry ", index));
            }
            catch (ArgumentException) {
                return View("~/Views/Shared/DeleteError.cshtml");
            }
            ViewBag.Dict = myDict;
            return View("IndexD");
        }

        public ActionResult Clear()
        {
            myDict.Clear();
            ViewBag.Dict = myDict;

            return View("IndexD");
        }
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            string result = myDict.ContainsKey("New Entry 3").ToString();

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;
            ViewBag.Result = result;


            ViewBag.Dict = myDict;
            return View();
        }
        public ActionResult Return()
        {
            ViewBag.Dict = myDict;
            return View("Index", "Home");
        }
    }
}
