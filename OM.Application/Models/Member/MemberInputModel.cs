using System.ComponentModel.DataAnnotations;

namespace OM.Application.Models.Member
{
    public class MemberInputModel : BaseInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Trường {0} là bắt buộc")]
        [StringLength(256, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [Display(Name = "Tên")]
        public string? Name { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
    }
}
