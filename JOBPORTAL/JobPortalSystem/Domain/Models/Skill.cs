using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Skill
{
    public Guid Id { get; set; } = new Guid();

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    //public List<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }

    //public Guid JobSeekerProfileId { get; set; }

    //public Guid JobPost { get; set; }

    //public virtual JobPost JobPostNavigation { get; set; } = null!;
}
