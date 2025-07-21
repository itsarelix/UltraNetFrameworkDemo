
using System.ComponentModel.DataAnnotations;

namespace UltraNet.UI.Model
{
    public class VerifyOtpRequest
    {
        [Required(ErrorMessage = "Receiver is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Receiver { get; set; } = string.Empty;
        [Required(ErrorMessage = "Code is required")]
        public string InputCode { get; set; } = string.Empty;

    }
}

