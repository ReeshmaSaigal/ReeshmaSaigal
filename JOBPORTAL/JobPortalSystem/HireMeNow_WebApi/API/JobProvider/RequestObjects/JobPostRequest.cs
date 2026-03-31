//using Domain.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeNow_WebApi.API.JobProvider.RequestObjects
{
    public class JobPostRequest
    {
        public string JobTitle { get; set; } = null!;

        public string JobSummary { get; set; } = null!;
/*        [ForeignKey(nameof(Location))]*/
        public Guid LocationId { get; set; }

/*        [ForeignKey(nameof(Company))]*/
        public Guid CompanyId { get; set; }
/*        [ForeignKey(nameof(JobCategory))]*/
        public Guid CategoryId { get; set; }
/*        [ForeignKey(nameof(Industry))]*/
        public Guid IndustryId { get; set; }

        public Guid PostedBy { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
