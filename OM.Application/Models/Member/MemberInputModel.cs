using OM.Application.Utils;
using System.ComponentModel.DataAnnotations;

namespace OM.Application.Models.Member
{
    public class MemberInputModel : BaseInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [StringLength(256, ErrorMessage = ErrorMessages.ErrorValidationStringLength)]
        [Display(Name = "Tên")]
        public string? Name { get; set; }

        [StringLength(10, ErrorMessage = ErrorMessages.ErrorValidationStringLength)]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
    }
}
