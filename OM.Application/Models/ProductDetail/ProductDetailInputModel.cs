using OM.Application.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OM.Application.Models
{
    public class ProductDetailInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [StringLength(100, ErrorMessage = ErrorMessages.ErrorValidationStringLengthWithMinimum)]
        [DisplayName("Tên sản phẩm")]
        public string? Name { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [DisplayName("Giá")]
        public decimal? Price { get; set; }
        [StringLength(300, ErrorMessage = ErrorMessages.ErrorValidationStringLengthWithMinimum)]
        [DisplayName("Mô tả")]
        public string? Description { get; set; }
        [DisplayName("Loại")]
        public string? Type { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [DisplayName("Số lượng")]
        public string Quantity { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [DisplayName("Xuất xứ")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        [DisplayName("Thương hiệu")]
        public string Brand { get; set; }
        [Required(ErrorMessage = ErrorMessages.ErrorValidationRequired)]
        public int ProductId { get; set; }
    }
}
