using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using PenaltyCalculator.Extentsions;
using PenaltyCalculator.Models;
using System.Diagnostics;

namespace PenaltyCalculator.Controllers
{
    public class HomeController : Controller
    {

        private ICountryService _countryService;
        public HomeController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        private List<Country> AllCountries() { return _countryService.GetListAll(); }
        public IActionResult Index()
        {
            // pass Countries lis to view
            ViewBag.CountryList = AllCountries();

            // pass calculation result to view
            ViewBag.CalculatePenaltyModel = JsonConvert.DeserializeObject<CalculatePenaltyModel>((string)TempData["penalty"] ?? "");

            return View(new FormModel());
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FormModel model)
        {
            ViewBag.CountryList = AllCountries();
            if (!ModelState.IsValid)
            {
                return View(model);
                
            }

            //check if  checked out Date bigger than returned date
            if (model.checkedOut_Date > model.return_Date)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Message = "Returned date should be bigger than check out date!",
                    AlertType = "danger"
                });
                return View(model);
            }

            // get country with its holidays 
            Country cntry = _countryService.GetCountryByIdNaWithHolies(model.CountryId);

            int busnissDays = 0;
            for (DateTime dt = model.checkedOut_Date.Date; dt <= model.return_Date.Date; dt = dt.AddDays(1))
            {
                // check if a National or Religious Day
                bool isNatHoldy = cntry.NationalReligiousDays.Any(x => x.DayDate.Date == dt.Date);

                // check  if a weekend day for this country
                bool isWeekEnd = cntry.CountryWeekendDays.Any(x => x.WeekDay.Name.ToLower() == dt.DayOfWeek.ToString().ToLower());

                if (isNatHoldy==false && isWeekEnd==false)
                {
                    busnissDays++;
                }
            }
            // Calculate late days 
            int lateDays = busnissDays - 10;

            double penalty = 0;
            if (lateDays>0)
            {
                penalty = lateDays * cntry.PenaltyAmount;
            }
            CalculatePenaltyModel pnm=new CalculatePenaltyModel();
            // return number of business days
            pnm.BusinessDays= busnissDays;
            // return Penalty
            pnm.Penalty= penalty;
            pnm.CountryCurrencey = cntry.CurrencyCode;
            pnm.CheckDate = model.checkedOut_Date;
            pnm.ReturnedDate = model.return_Date;
            pnm.Country = cntry.Name;

            TempData["penalty"] = JsonConvert.SerializeObject(pnm);

            return RedirectToAction(nameof(Index));
        }


    }
}