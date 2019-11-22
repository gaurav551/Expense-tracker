using System.Diagnostics;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTracker.Data;
using System.Collections.Generic;

namespace ExpenseTracker.Controllers
{
    public class TradeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TradeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult DeleteTrade(int id, string c2)
        {
           var s = _context.Trades.FirstOrDefault(x=>x.Id == id);
           _context.Remove(s);
           _context.SaveChanges();
           return RedirectToAction(nameof(Index), new {companyName = c2});

        }
        public IActionResult Index(string companyName, string search = null)
        {

            var a = _context.Trades.Where(x => x.CompanyName2.Equals(companyName)).ToList();
          
            ViewBag.cname = companyName;

            if (string.IsNullOrEmpty(search))
            {
                var data = _context.Trades.Where(x => x.CompanyName2.Equals(companyName)).OrderByDescending(x=>x.Id).ToList();
                ViewBag.cname = companyName;
                return View(data);

            }
            else
            {

                var data = a.Where(x => x.CompanyName.Contains(search)).OrderByDescending(x=>x.Id).ToList();
                ViewBag.cname = companyName;
                
                return View(data);

            }

        }
        public IActionResult Add(string company2)
        {
            var x = _context.Companies.ToList();

            ViewBag.Name = new SelectList(x, "CompanyName", "CompanyName");
            @ViewBag.Company2 = company2;

            return View();
        }

        public float Tot(float a, float b)
        {
            return (a / 100 * b + b);
        }
        [HttpPost]
        public IActionResult SaveRecord(Trade T, string cname, string company2)
        {
            string a = cname;
            var data = _context.Companies.FirstOrDefault(x => x.CompanyName.Equals(a));
            T.CompanyId = data.Id;
            T.CompanyPanNumber = data.PanNumber;



            T.CompanyName = cname;
            T.Total = Tot(T.Tax, T.TaxableAmount);
            if (cname == company2)
            {
                ViewBag.company2 = company2;
                TempData["ER"] = "Sorry " + cname + " cannot trade with " + company2;
                return RedirectToAction(nameof(Add), new { ViewBag.company2 });
            }
            _context.Trades.Add(T);
            _context.SaveChanges();
            ViewBag.Company2 = company2;
            return RedirectToAction(nameof(Add), new { ViewBag.Company2 });
        }
        public IActionResult AddCompany(Company C, string pan, string cname)

        {
            C.PanNumber = pan;
            C.CompanyName = cname;
            if (_context.Companies.Any(x => x.CompanyName.Equals(cname) || x.PanNumber.Equals(pan)))
            {
                return Content("The Company " + (cname) + " or Pan  number " + (pan) + " ALready Exist in Database");
            }
            else
                _context.Companies.Add(C);
            _context.SaveChanges();
            return RedirectToAction(nameof(Home));
        }
         public IActionResult SaveCompany1(Company C, string pan, string cname, string company3)

        {
            C.PanNumber = pan;
            C.CompanyName = cname;
            if (_context.Companies.Any(x => x.CompanyName.Equals(cname) || x.PanNumber.Equals(pan)))
            {
                return Content("The Company " + (cname) + " or Pan  number " + (pan) + " ALready Exist in Database");
            }
            else
                _context.Companies.Add(C);
            _context.SaveChanges();
            return RedirectToAction(nameof(Add), new {company2 = company3});
        }

        // public IActionResult All(Trade T)
        // {
        //     List<TradeResult> tradeResult = new List<TradeResult>();
        //     var s = _context.Trades
        //       .GroupBy(m => new { m.CompanyId, m.CompanyName, m.CompanyPanNumber })
        //       .Select(n => new
        //       {
        //           CompanyId = n.Key.CompanyId,
        //           CompanyName = n.Key.CompanyName,
        //           CompanyPanNumber = n.Key.CompanyPanNumber,
        //           Total = n.Sum(i => i.Total)
        //       }).ToList();
        //     foreach (var t in s)
        //     {
        //         TradeResult trade = new TradeResult
        //         {
        //             CompanyName = t.CompanyName,
        //             CompanyId = t.CompanyId,
        //             Total = t.Total,
        //             CompanyPanNumber = t.CompanyPanNumber
        //         };
        //         tradeResult.Add(trade);
        //     }
        //     return View(tradeResult);
        // }
        public IActionResult All(string company2)
        {
            ViewBag.cname = company2;

            List<TradeResult> tradeResult = new List<TradeResult>();
            var s = _context.Trades.Where(x => x.CompanyName2.Equals(company2))
              .GroupBy(m => new { m.CompanyName, m.CompanyPanNumber })
               .Select(n => new
               {

                   CompanyName = n.Key.CompanyName,
                   CompanyPanNumber = n.Key.CompanyPanNumber,
                   TaxableAmount = n.Sum(i => i.TaxableAmount),

                   Total = n.Sum(i => i.Total)
               }).ToList();
            foreach (var t in s)
            {
                TradeResult trade = new TradeResult
                {
                    CompanyName = t.CompanyName,

                  
                    CompanyPanNumber = t.CompanyPanNumber,
                    TaxableAmount = t.TaxableAmount,
                    Tax = 13,
                    Total = t.Total

                };
                tradeResult.Add(trade);
            }
            return View(tradeResult);

        }
        public IActionResult Details(int id, string company2)
        {
            var a = _context.Trades.Where(x => x.CompanyId == id && x.CompanyName2.Equals(company2)).ToList();
            ViewBag.c2 = company2;
            ViewBag.cname = _context.Companies.FirstOrDefault(x => x.Id == id).CompanyName;

            ViewBag.pan = _context.Companies.FirstOrDefault(x => x.Id == id).PanNumber;
            ViewBag.tax = _context.Trades.FirstOrDefault(x => x.CompanyId == id).Tax;


            ViewBag.taxableamount = a.Sum(x => x.TaxableAmount);
            ViewBag.tot = a.Sum(x => x.Total);
            return View();

        }

        public IActionResult DeleteCompany(int id )
        {
            var c = _context.Companies.FirstOrDefault(x=>x.Id==id);
            var t = _context.Trades.Where(x=>x.CompanyId==id).ToList();
            foreach(var x in t)
            _context.Trades.Remove(x);
            _context.Companies.Remove(c);
            _context.SaveChanges();
            

            return RedirectToAction(nameof(AllCompanies));
        }
        public IActionResult Delete(int id, string c2)
        {

            var delete = _context.Trades.FirstOrDefault(x => x.Id == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new { companyname = c2 });

        }
        public IActionResult Home()
        {
            var x = _context.Companies.ToList();
           if(x.Count()<=0)
           {
               TempData["c"] = "No company on the list, Please Create Companies to Get Started";
           }

            ViewBag.Name = new SelectList(x, "CompanyName", "CompanyName");
            return View();
        }
        public IActionResult AllCompanies()
        {
            return View(_context.Companies.ToList());
        }

    }
}