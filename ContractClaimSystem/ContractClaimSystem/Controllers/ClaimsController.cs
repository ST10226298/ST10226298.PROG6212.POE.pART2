using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ContractClaimSystem.Models;
using ContractClaimSystem.ViewModels;
using System;

namespace ContractClaimSystem.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly AppDbContext _context;

        public ClaimsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(ClaimViewModel claimVm)
        {
            if (ModelState.IsValid)
            {
                var newClaim = new ClaimModel
                {
                    LecturerName = claimVm.LecturerName,
                    ClaimDate = claimVm.ClaimDate,
                    ClaimAmount = claimVm.ClaimAmount,
                    SubmittedOn = DateTime.Now
                };

                if (claimVm.SupportingDocuments != null)
                {
                    var fileName = System.IO.Path.GetFileName(claimVm.SupportingDocuments.FileName);
                    var filePath = System.IO.Path.Combine("uploads", fileName);
                    using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                    {
                        claimVm.SupportingDocuments.CopyTo(fileStream);
                    }
                    newClaim.SupportingDocuments = fileName;
                }

                _context.Claims.Add(newClaim);
                _context.SaveChanges();

                return RedirectToAction("TrackClaim", new { id = newClaim.ClaimId });
            }
            return View(claimVm);
        }

        [HttpGet]
        public IActionResult TrackClaim(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            return View(claim);
        }

        [HttpGet]
        public IActionResult ApproveClaim(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.ClaimStatus = "Approved";
                _context.SaveChanges();
            }
            return RedirectToAction("PendingClaims");
        }

        [HttpGet]
        public IActionResult RejectClaim(int id)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.ClaimStatus = "Rejected";
                _context.SaveChanges();
            }
            return RedirectToAction("PendingClaims");
        }

        [HttpGet]
        public IActionResult PendingClaims()
        {
            var claims = _context.Claims.Where(c => c.ClaimStatus == "Pending").ToList();
            return View(claims);
        }
    }
}
