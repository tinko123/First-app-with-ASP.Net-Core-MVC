using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Infrastructure.Constants
{   
    /// <summary>
    /// Validation Constants
    /// </summary>
    public static class ValidationConstants
    {
        public const int PostTitleMaxLength = 50;
        public const int PostTitleMinLength = 10;
        public const int PostContentMaxLength = 1500;
        public const int PostContentMinLength = 30;
        public const string ErrorMessageRequiredField = "The {0} field is required";
        public const string StringLengthErrorMessage = "The {0} must be between {2} and {1} characters";

    }
}
