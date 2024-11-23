using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class EmployeeDetails
    {
        [Key]
        public int Id { get;private set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(100 ,ErrorMessage ="Name cannot exceed 100 characters")]
        public string Name { get; set; }=string.Empty;
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(100, ErrorMessage = "EmailAddress cannot exceed 100 characters")]
        public string ? Email { get; set; }
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 to 15 digits and can include an optional '+' prefix.")]
        public string ? PhoneNumber { get; set; }

        public DateTime createdDate { get; private set; }

        public DateTime modifiedDate { get; private set; }

        public bool IsDeleted { get; private  set; }

    }
}
