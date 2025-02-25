using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Postnummer.Models;
using Postnummer.Models.Api;
using Postnummer.Services;
using Postnummer.ViewModels;

namespace Postnummer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IApiService _apiService;

    public HomeController(ILogger<HomeController> logger, IApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        return RedirectToAction(nameof(SearchVillage));
    }

    public IActionResult SearchVillage()
    {
        var model = new PostalCodeVM(); // Se till att modellen är instansierad

        return View(model);
    }

    [HttpPost]
    public IActionResult SearchVillage(PostalCodeVM obj)
    {
        if (obj.Search != null)
        {
            string village = obj.Search.Trim();
            var response = _apiService.GetPostalCodeListBySearch(village);

            try
            {
                List<Result> resultList = response.Result;
                
                var postalCodeItemList = new List<PostalCodeItemsVM>();

                foreach (var result in resultList)
                {
                    var postalCodeItem = new PostalCodeItemsVM()
                    {
                        PostalCode = result.Postal_code,
                        City = result.city,
                    };

                    postalCodeItemList.Add(postalCodeItem);
                }

                obj.SearchResult = postalCodeItemList;
            }
            catch (Exception e)
            {
                string errorMessage = e.Message;
            }
        }

        return View(obj);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
