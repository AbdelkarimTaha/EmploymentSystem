using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Application
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [ForeignKey("Vacancy")]
    public Guid VacancyId { get; set; }

    public Vacancy Vacancy { get; set; } = null!;

    [Required]
    [ForeignKey("Applicant")]
    public string ApplicantId { get; set; }

    public User Applicant { get; set; } = null!;
}