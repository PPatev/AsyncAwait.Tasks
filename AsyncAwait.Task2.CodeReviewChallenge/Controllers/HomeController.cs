using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AsyncAwait.Task2.CodeReviewChallenge.Models;
using AsyncAwait.Task2.CodeReviewChallenge.Models.Support;
using AsyncAwait.Task2.CodeReviewChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwait.Task2.CodeReviewChallenge.Controllers;

public class HomeController : Controller
{
    private readonly IAssistant _assistant;

    private readonly IPrivacyDataService _privacyDataService;
    private readonly ICloudService _cloudService;

    public HomeController(IAssistant assistant, IPrivacyDataService privacyDataService, ICloudService cloudService)
    {
        _assistant = assistant ?? throw new ArgumentNullException(nameof(assistant));
        _privacyDataService = privacyDataService ?? throw new ArgumentNullException(nameof(privacyDataService));
        _cloudService = cloudService ?? throw new ArgumentNullException(nameof(cloudService)); 
    }

    public async Task<IActionResult> Index()
    {
        var visitsCount = await _cloudService.GetVisitsCountAsync(HttpContext.Request.Path);
        ViewBag.VisitsCount = visitsCount.ToString();

        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        var visitsCount = await _cloudService.GetVisitsCountAsync(HttpContext.Request.Path);
        ViewBag.VisitsCount = visitsCount.ToString();
        ViewBag.Message = _privacyDataService.GetPrivacyData();

        return View();
    }

    public async Task<IActionResult> Help()
    {
        var visitsCount = await _cloudService.GetVisitsCountAsync(HttpContext.Request.Path);
        ViewBag.VisitsCount = visitsCount.ToString();
        ViewBag.RequestInfo = await _assistant.RequestAssistanceAsync("guest").ConfigureAwait(false);

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
