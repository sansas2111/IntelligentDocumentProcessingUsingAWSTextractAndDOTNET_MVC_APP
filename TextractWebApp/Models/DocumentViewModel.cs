using System.ComponentModel.DataAnnotations;

namespace TextractWebApp.Models
{
    public class DocumentViewModel
    {
        [Required]
        public IFormFile? Document { get; set; }
        public List<string>? ExtractedText { get; set; }
    }
}
