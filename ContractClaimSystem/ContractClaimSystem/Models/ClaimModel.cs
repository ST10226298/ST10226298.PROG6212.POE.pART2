using System;
using System.ComponentModel.DataAnnotations;

namespace ContractClaimSystem.Models
{
    public class ClaimModel
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public required string LecturerName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }

        [Required]
        public decimal ClaimAmount { get; set; }

        // public required string SupportingDocuments { get; set; }
        public string? SupportingDocuments { get; set; } // Nullable property


        public string ClaimStatus { get; set; } = "Pending"; // Default status

        public DateTime SubmittedOn { get; set; }
    }
}