﻿using OM.Application.Utils;
using System.ComponentModel.DataAnnotations;

namespace OM.Web.Models.Account
{
    public class RegisterViewModel
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = ErrorMessages.ErrorValidationStringLength)]
        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = ErrorMessages.ErrorValidationStringLength)]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = ErrorMessages.ErrorValidationStringLengthWithMinimum, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = ErrorMessages.ErrorValidationConfirmPassword)]
        public string ConfirmPassword { get; set; }
    }
}
