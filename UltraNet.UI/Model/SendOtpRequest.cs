using System.ComponentModel.DataAnnotations;

namespace UltraNet.UI.Model
{
    public class SendOtpRequest
    {
        [Required(ErrorMessage = "Receiver is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Receiver { get; set; } = string.Empty;
    }
}
