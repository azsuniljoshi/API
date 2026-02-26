using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table(name: "student_registration", Schema = "dbo")]
    public class StudentRegistration
    {
        [Key]
        [Column("id")]
        public Int64 ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("mobileNumber")]
        public string MobileNumber { get; set; }

        [Column("emailID")]
        public string EmailID { get; set; }
    }
}
