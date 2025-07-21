using System.ComponentModel.DataAnnotations;

namespace UltraNet.UI.Model
{
    public class RateLimitRequest
    {
        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; } = string.Empty;
    }
}
