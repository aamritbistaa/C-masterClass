using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Dto.Request.Helpers
{
    public class CheckIfUserIsEligibleToVoteRequest
    {
        [Required]
        [StringLength(30,MinimumLength =10,ErrorMessage = "Name must be more than 10 and not exceed 30")]
        public string Name { get; set; }
        [Required]
        [Range(18,60,ErrorMessage ="You must be between 18 to 60 to Vote.")]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Nationality { get; set; }
    }
}
