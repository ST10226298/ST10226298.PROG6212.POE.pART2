using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ContractClaimSystem.ViewModels
{
    public class ClaimViewModel
    {
        public int ClaimId { get; set; }

        [Required]
        public required string LecturerName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal ClaimAmount { get; set; }

        public required IFormFile SupportingDocuments { get; set; }

        public string ClaimStatus { get; set; } = "Pending"; // Default status
    }
}
