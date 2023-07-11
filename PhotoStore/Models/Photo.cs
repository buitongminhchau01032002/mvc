using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhotoStore.Models {
    public class Photo {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "message.required")]
        [DisplayName("field.photoUrl")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "message.required")]
        [IgnoreBadWord(ErrorMessage = "message.ignoreBadWord")]
        [DisplayName("field.title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "message.required")]
        [DisplayName("field.createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int UserId { get; set; }

    }
}
