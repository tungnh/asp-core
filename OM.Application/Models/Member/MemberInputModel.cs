using OM.Application.Utils;
using System.ComponentModel.DataAnnotations;

namespace OM.Application.Models.Member
{
    public class MemberInputModel : BaseInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessage.Required)]
        [StringLength(256, ErrorMessage = ErrorMessage.StringLength)]
        [Display(Name = "Tên")]
        public string? Name { get; set; }

        [StringLength(10, ErrorMessage = ErrorMessage.StringLength)]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
    }
}
