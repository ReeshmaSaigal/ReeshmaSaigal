using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp.Interfaces
{
    public interface ISignUpRequestRepository
    {
        Task AddJobSeekerAsync(Models.JobSeeker jobseeker);
        Guid AddSignupRequest(SignUpRequest signUpRequest);
        Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId);
        void UpdateSignupRequest(SignUpRequest signUpRequest);

        public Task addResume(Guid resumeId, string title, byte[] fileData);

        public Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId,string profileName,string profileSummary);

        public Task<Guid> getResumeId(Guid profileId);

        public Task UpdateResume(Guid resumeId, byte[] fileData);

        public Task<List<Resume>> getResume(Guid resumeId);
        public Task<byte[]> getResumeFile(Guid resumeId);

        public Task DeleteResume(Guid resumeId);
    }
}
