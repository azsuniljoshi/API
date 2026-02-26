using API.Models;
namespace API.Services
{
    public interface IStudentRegistrationService
    {
        Task<ServiceResponse<List<StudentRegistration>>> GetAllStudentRegistrationsAsync();

        Task<ServiceResponse<List<StudentRegistration>>> InsertStudentRegistrationsAsync(StudentRegistration studentRegistration);

        Task<ServiceResponse<StudentRegistration>> UpdateStudentRegistrationsAsync(StudentRegistration studentRegistration);

        Task<ServiceResponse<bool>> DeleteStudentRegistrationsAsync(Int64 id);
    }
}
