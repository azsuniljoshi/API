using API.Models;
using API.EFContext;

namespace API.Services
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        private readonly ApplicationDBContext _context;
        public StudentRegistrationService(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all student registrations from the database and return them in a ServiceResponse object.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<StudentRegistration>>> GetAllStudentRegistrationsAsync()
        {
            try
            {

                var studentRegistrations = _context.StudentRegistrations.ToList();

                return new ServiceResponse<List<StudentRegistration>>
                {
                    Count = studentRegistrations.Count,
                    Result = studentRegistrations
                };


            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<StudentRegistration>>
                {
                    ErrorMessage = $"An error occurred while retrieving student registrations: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Add a new student registration to the database and return the updated list of student registrations in a ServiceResponse object.
        /// </summary>
        /// <param name="studentRegistration"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<StudentRegistration>>> InsertStudentRegistrationsAsync(StudentRegistration studentRegistration)
        {
            try
            {
                _context.StudentRegistrations.Add(studentRegistration);
                await _context.SaveChangesAsync();
                var studentRegistrations = _context.StudentRegistrations.ToList();
                return new ServiceResponse<List<StudentRegistration>>
                {
                    Count = studentRegistrations.Count,
                    Result = studentRegistrations
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<StudentRegistration>>
                {
                    ErrorMessage = $"An error occurred while inserting student registration: {ex.Message}"
                };
            }
        }

        public async Task<ServiceResponse<StudentRegistration>> UpdateStudentRegistrationsAsync(StudentRegistration studentRegistration)
        {
            try
            {
                var existingRegistration = _context.StudentRegistrations.Find(studentRegistration.ID);

                if (existingRegistration == null)
                {
                    return await Task.FromResult(new ServiceResponse<StudentRegistration>
                    {
                        ErrorMessage = "Student registration not found."
                    });
                }

                existingRegistration.Name = studentRegistration.Name;
                existingRegistration.MobileNumber = studentRegistration.MobileNumber;
                existingRegistration.EmailID = studentRegistration.EmailID;

                //await _context.UpdateAsync(existingRegistration);   
                await _context.SaveChangesAsync();

                return new ServiceResponse<StudentRegistration>
                {
                    Result = existingRegistration
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteStudentRegistrationsAsync(Int64 id)
        {
            try
            {
                var existingRegistration = _context.StudentRegistrations.Find(id);
                if (existingRegistration == null)
                {
                    return await Task.FromResult(new ServiceResponse<bool>
                    {
                        ErrorMessage = "Student registration not found."
                    });
                }
                _context.StudentRegistrations.Remove(existingRegistration);
                await _context.SaveChangesAsync();
                return new ServiceResponse<bool>
                {
                    Result = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
