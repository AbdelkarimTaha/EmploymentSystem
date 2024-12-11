using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class User: IdentityUser
{
    [Required]
    public int UserRole { get; set; } // 1 = Employer, 2 = Applicant
    public DateTime? LastAppliedDate { get; set; }
}