using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MainSite.Models
{
    public enum TicketStatus
    {
        ToDo,
        InProgress,
        [Display(Name = "Quality Assurance")]
        QA,
        Done
    }
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(1, 99)]
        public int SprintNumber { get; set; }
        [Required]
        [Range(1,20)]
        public int PointValue { get; set; }
        [Required]
        public TicketStatus Status { get; set; }
    }
}
