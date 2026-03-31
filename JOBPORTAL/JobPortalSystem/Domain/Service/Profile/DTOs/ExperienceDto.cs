using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Profile.DTOs
{
    public class ExperienceDto
    {
        public Guid JobSeekerProfileId { get; set; }

        public string JobTitle { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public DateTime ServiceStart { get; set; }

    }
}
