namespace PhotoStore.Models {
    public class PhotoCard {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserAvatar { get; set; }
        public string UserDisplayName { get; set; }
    }
}
