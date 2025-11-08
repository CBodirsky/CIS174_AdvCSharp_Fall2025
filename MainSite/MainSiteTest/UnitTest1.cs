using MainSite.Data.Repositories;
using MainSite.Data.Services;
using MainSite.Models;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Xunit;

namespace MainSiteTest
{
    public class SanityTests
    {
        [Fact]
        public void TrueShouldBeTrue()
        {
            Assert.True(true);
        }
    }
    public class TicketValidationTests
    {
        private IList<ValidationResult> ValidateModel(Ticket ticket)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(ticket, null, null);
            Validator.TryValidateObject(ticket, context, results, true);
            return results;
        }

        [Fact]
        public void Ticket_WithValidData_ShouldPassValidation()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Name = "Implement login",
                Description = "Add login functionality with JWT",
                SprintNumber = 2,
                PointValue = 5,
                Status = TicketStatus.ToDo
            };

            var results = ValidateModel(ticket);

            Assert.Empty(results); // no validation errors
        }

        [Fact]
        public void Ticket_WithMissingName_ShouldFailValidation()
        {
            var ticket = new Ticket
            {
                Id = 2,
                Description = "Missing name field",
                SprintNumber = 1,
                PointValue = 3,
                Status = TicketStatus.InProgress
            };

            var results = ValidateModel(ticket);

            Assert.Contains(results, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Ticket_WithInvalidPointValue_ShouldFailValidation()
        {
            var ticket = new Ticket
            {
                Id = 3,
                Name = "Invalid points",
                Description = "Point value too high",
                SprintNumber = 1,
                PointValue = 50, // outside [1,20]
                Status = TicketStatus.QA
            };

            var results = ValidateModel(ticket);

            Assert.Contains(results, r => r.MemberNames.Contains("PointValue"));
        }
    }

}