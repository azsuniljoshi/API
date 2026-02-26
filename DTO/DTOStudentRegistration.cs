using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTO
{
    public class DTOStudentRegistration
    {
        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string EmailID { get; set; }
    }
}
