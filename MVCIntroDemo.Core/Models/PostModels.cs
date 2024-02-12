using Microsoft.EntityFrameworkCore;
using static MVCIntroDemo.Infrastructure.Constants.ValidationConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Core.Models
{
    /// <summary>
    /// Post Models
    /// </summary>
    public class PostModels
    {
        /// <summary>
        /// Post identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Post title
        /// </summary>
        [Required(ErrorMessage = ErrorMessageRequiredField)]
        [StringLength
            (
            PostTitleMaxLength,
            MinimumLength = PostTitleMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]

        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Post content
        /// </summary>
        [Required(ErrorMessage = ErrorMessageRequiredField)]
        [StringLength
            (
            PostContentMaxLength,
            MinimumLength = PostContentMinLength,
            ErrorMessage = StringLengthErrorMessage
            )]
        public string Content { get; set; } = string.Empty;
    }
}
