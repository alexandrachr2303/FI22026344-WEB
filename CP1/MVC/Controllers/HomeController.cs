using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Index(TheModel model)
    {
        ViewBag.Valid = ModelState.IsValid;
        if (ViewBag.Valid && !string.IsNullOrEmpty(model.Phrase))
        {

            var charArray = model.Phrase!.Where(c => !char.IsWhiteSpace(c)).ToList();

            foreach (var c in charArray)
            {
                if (!model.Counts!.ContainsKey(c))
                    model.Counts[c] = 0;
                model.Counts[c]++;
            }

            model.Lower = string.Concat(charArray.Select(c => char.ToLower(c)));
            model.Upper = string.Concat(charArray.Select(c => char.ToUpper(c)));
        }
        return View(model);
    }

}