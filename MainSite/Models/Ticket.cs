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

        public string Name { get; set; }
        public string Description { get; set; }
        public int SprintNumber { get; set; }
        public int PointValue { get; set; }
        public TicketStatus Status { get; set; }
    }
}
