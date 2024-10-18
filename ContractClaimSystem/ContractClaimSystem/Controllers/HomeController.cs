using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string LecturerName, DateTime ClaimDate, decimal ClaimAmount, IFormFile SupportingDocuments)
    {
        // Logic to handle claim submission and saving
        // You can save the file, process the data, and redirect to a confirmation page

        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }
}
