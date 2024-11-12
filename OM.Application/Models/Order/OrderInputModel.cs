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
    public class OrderInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [DisplayName("Số lượng")]
        public string? Amount { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [DisplayName("Tổng")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        public int ProductId { get; set; }
    }
}
