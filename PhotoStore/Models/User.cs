using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace PhotoStore.Models {
    public class User {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "message.required")]
        [Remote("UniqueUsername", "User", ErrorMessage = "message.existedUsername")]
        [DisplayName("field.username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "message.required")]
        [DisplayName("field.displayName")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "message.required")]
        [NotPartOf("Username", ErrorMessage = "message.strongPassword")]
        [DisplayName("field.password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "message.required")]
        [DisplayName("field.avatar")]
        public string Avatar { get; set; }
    }
}
