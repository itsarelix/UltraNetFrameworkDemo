using System.ComponentModel.DataAnnotations;

namespace UltraNet.UI.Model
{
    public class CacheRequest
    {
        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; } = string.Empty;
    }
}
