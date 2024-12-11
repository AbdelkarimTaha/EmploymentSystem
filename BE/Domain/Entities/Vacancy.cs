using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Vacancy
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [ForeignKey("Employer")]
    public string EmployerId { get; set; }

    public User Employer { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    public int MaxApplications { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}