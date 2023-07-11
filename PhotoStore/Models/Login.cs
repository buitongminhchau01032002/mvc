using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhotoStore.Models {
    public class Login {
        [Required(ErrorMessage = "message.required")]
        [DisplayName("field.username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "message.required")]
        [DisplayName("field.password")]
        public string Password { get; set; }
    }
}
