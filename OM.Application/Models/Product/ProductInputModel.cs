using OM.Application.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Models 
{
    public class ProductInputModel
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [Display(Name = "Tên sản phẩm")]
        public string? Name { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayName("Giá")]
        public decimal? Price { get; set; }
    }
}
