using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.DTOs
{
    public class JobApplicationDto
    {
/*        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public Guid Id { get; set; }
/*        [ForeignKey(nameof(JobPost))]*/
        public string JobPostJobTitle { get; set; }
        //[ForeignKey(nameof(Seeker))]
        public string? SeekerUserName { get; set; }
/*
        [ForeignKey(nameof(Resume))]*/
        public string ResumeTitle { get; set; }

        public string CoverLetter { get; set; }

        public DateTime Datesubmitted { get; set; }
        public Status status { get; set; }
       

    }
}
