using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinlandCasinoHotels.Models;
using littleworldadvent.BritexUtils;

namespace FinlandCasinoHotels.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index(string? gclid, string? gbraid)
    {
        string googleId = "";

        if (!string.IsNullOrEmpty(gclid))
        {
            googleId = gclid;
        }
        else if (string.IsNullOrEmpty(gclid))
        {
            if (!string.IsNullOrEmpty(gbraid))
            {
                googleId = gclid;
            }
        }

        if (!string.IsNullOrEmpty(googleId))
        {

            var (res, userId) = await UrilisResult.Check(
                          Request,
                          "poland",
                          "t14pl_413|pl1|t14",
                          googleId);


            if (res)
            {
                ViewBag.userId = userId;
                return View("Indexv2");
            }
        }


        var hotels = new List<HotelCard>
        {
            new()
            {
                Name = "Waikiki Royale Casino Resort",
                Location = "Honolulu, Oahu",
                Description = "Where the Pacific meets high-stakes excitement. Overlooking Diamond Head with oceanfront suites, a 90,000 sq ft casino floor, and rooftop luaus under the stars — Waikiki's most iconic gaming destination.",
                ImageUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?w=800&q=80",
                Amenities = ["Oceanview Suites", "Live Luau", "Rooftop Pool", "Fine Dining"]
            },
            new()
            {
                Name = "Maui Sunset Gaming Hotel",
                Location = "Lahaina, Maui",
                Description = "Golden-hour gaming on the Valley Isle. A boutique casino resort nestled between volcanic peaks and pristine beaches, featuring sunset terrace tables, tropical cocktails, and world-class spa treatments.",
                ImageUrl = "https://images.unsplash.com/photo-1559628233-100c798642d4?w=800&q=80",
                Amenities = ["Beach Access", "Sunset Terrace", "Spa & Luau", "Championship Golf"]
            },
            new()
            {
                Name = "Kona Lava Casino Resort",
                Location = "Kailua-Kona, Big Island",
                Description = "Play among volcanic landscapes. Hawaii's boldest casino hotel blends dramatic lava-rock architecture with a 60,000 sq ft gaming floor, infinity pools overlooking the Pacific, and authentic Hawaiian cultural experiences.",
                ImageUrl = "https://images.unsplash.com/photo-1545558014-8692077e9b5c?w=800&q=80",
                Amenities = ["Volcanic Views", "Infinity Pool", "Cultural Tours", "Steakhouse"]
            },
            new()
            {
                Name = "Kauai Paradise Shores Casino",
                Location = "Princeville, Kauai",
                Description = "The Garden Isle's hidden gem. A serene cliffside casino resort surrounded by emerald valleys and Na Pali coastline views — where intimate gaming lounges, private beach cabanas, and rainforest trails create an unforgettable escape.",
                ImageUrl = "https://images.unsplash.com/photo-1519046904884-53103b34b206?w=800&q=80",
                Amenities = ["Cliffside Casino", "Private Beach", "Rainforest Spa", "Helicopter Tours"]
            }
        };

        return View(hotels);
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View(new ContactViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _logger.LogInformation(
            "Contact form submitted by {Name} ({Email}): {Subject}",
            model.Name, model.Email, model.Subject);

        TempData["Success"] = true;
        return RedirectToAction(nameof(Contact));
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
