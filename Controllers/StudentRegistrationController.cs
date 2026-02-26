using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Models;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentRegistrationController : ControllerBase
    {

        private readonly ILogger<StudentRegistrationController> _logger;
        private readonly IStudentRegistrationService _studentRegistrationService;

        public StudentRegistrationController(ILogger<StudentRegistrationController> logger,
            IStudentRegistrationService studentRegistrationService)
        {
            _logger = logger;
            _studentRegistrationService = studentRegistrationService;
        }
        /// <summary>
        /// gets all student registration details and returns the result.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<APIResponse<List<StudentRegistration>>>> Get()
        {
            try
            {
                ServiceResponse<List<StudentRegistration>> serviceResponse = await _studentRegistrationService.GetAllStudentRegistrationsAsync();
                APIResponse<List<StudentRegistration>> apiResponse = new APIResponse<List<StudentRegistration>>
                {
                    Success = string.IsNullOrEmpty(serviceResponse.ErrorMessage),
                    Message = serviceResponse.ErrorMessage ?? "Student registrations retrieved successfully.",
                    Data = serviceResponse.Result
                };
                return Ok(apiResponse);
            }
            catch (Exception)
            {

                return StatusCode(500, new APIResponse<List<StudentRegistration>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving student registrations.",
                    Data = null
                });
            }
        }

        /// <summary>
        /// Creates a new student registration and returns the result.
        /// </summary>
        /// <param name="dtoStudentRegistration">The data transfer object containing student registration details.</param>
        /// <returns>An API response containing the list of student registrations and operation status.</returns>
        [HttpPost]
        public async Task<ActionResult<APIResponse<List<StudentRegistration>>>> Post(DTOStudentRegistration dtoStudentRegistration)
        {
            try
            {
                StudentRegistration studentRegistration = new StudentRegistration
                {
                    Name = dtoStudentRegistration.Name,
                    MobileNumber = dtoStudentRegistration.MobileNumber,
                    EmailID = dtoStudentRegistration.EmailID
                };
                ServiceResponse<List<StudentRegistration>> serviceResponse = await _studentRegistrationService.InsertStudentRegistrationsAsync(studentRegistration);
                APIResponse<List<StudentRegistration>> apiResponse = new APIResponse<List<StudentRegistration>>
                {
                    Success = string.IsNullOrEmpty(serviceResponse.ErrorMessage),
                    Message = serviceResponse.ErrorMessage ?? "Student registration added successfully.",
                    Data = serviceResponse.Result
                };
                return Ok(apiResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, new APIResponse<List<StudentRegistration>>
                {
                    Success = false,
                    Message = "An error occurred while adding the student registration.",
                    Data = null
                });
            }
        }



        /// <summary>
        /// updates an existing student registration 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="dtoStudentRegistration"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<APIResponse<StudentRegistration>>> Put(Int64 uid, DTOStudentRegistration dtoStudentRegistration)
        {
            try
            {

                var studentRegistration = new StudentRegistration
                {
                    ID = uid,
                    Name = dtoStudentRegistration.Name,
                    MobileNumber = dtoStudentRegistration.MobileNumber,
                    EmailID = dtoStudentRegistration.EmailID
                };

                ServiceResponse<StudentRegistration> serviceResponse = await _studentRegistrationService.UpdateStudentRegistrationsAsync(studentRegistration);
                APIResponse<StudentRegistration> apiResponse = new APIResponse<StudentRegistration>
                {
                    Success = string.IsNullOrEmpty(serviceResponse.ErrorMessage),
                    Message = serviceResponse.ErrorMessage ?? "Student registration updated successfully.",
                    Data = serviceResponse.Result
                };
                return Ok(apiResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, new APIResponse<StudentRegistration>
                {
                    Success = false,
                    Message = "An error occurred while updating the student registration.",
                    Data = null
                });
            }
        }

        /// <summary>
        /// Deletes a student registration 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<APIResponse<bool>>> Delete(Int64 uid)
        {
            try
            {
                ServiceResponse<bool> serviceResponse = await _studentRegistrationService.DeleteStudentRegistrationsAsync(uid);
                APIResponse<bool> apiResponse = new APIResponse<bool>
                {
                    Success = string.IsNullOrEmpty(serviceResponse.ErrorMessage),
                    Message = serviceResponse.ErrorMessage ?? "Student registration deleted successfully.",
                    Data = serviceResponse.Result
                };
                return Ok(apiResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, new APIResponse<bool>
                {
                    Success = false,
                    Message = "An error occurred while deleting the student registration.",
                    Data = false
                });
            }
        }
    }
}
