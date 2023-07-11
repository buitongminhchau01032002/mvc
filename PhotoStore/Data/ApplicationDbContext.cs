using Microsoft.EntityFrameworkCore;
using PhotoStore.Models;

namespace PhotoStore.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Username = "minhchau", DisplayName = "Minh Chau", Password = "96e79218965eb72c92a549dd5a330112", Avatar = "https://hips.hearstapps.com/hmg-prod/images/domestic-cat-lies-in-a-basket-with-a-knitted-royalty-free-image-1592337336.jpg?crop=0.668xw:1.00xh;0.247xw,0&resize=1200:*" },
                new User() { Id = 2, Username = "chauminh", DisplayName = "Chau Minh", Password = "96e79218965eb72c92a549dd5a330112", Avatar = "https://t3.ftcdn.net/jpg/01/39/57/98/360_F_139579875_x5jJX0QBhdjzDJbjB9abyHK6k0xDr1nf.jpg" }
            );

            modelBuilder.Entity<Photo>().HasData(
                new Photo() { Id = 1, ImageUrl= "https://images.unsplash.com/photo-1685625762287-5d08e37d5292?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxMHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60", Title= "The desert with sand dunes", CreatedAt= DateTime.Now, UserId= 1 },
                new Photo() { Id = 2, ImageUrl= "https://images.unsplash.com/photo-1671600938989-40d68c9d1c05?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDI5fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=500&q=60", Title= "Beach and mountains at sunset ", CreatedAt= DateTime.Now, UserId= 1 },
                new Photo() { Id = 3, ImageUrl= "https://images.unsplash.com/photo-1685016762514-2af20a9b0105?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDM4fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=500&q=60", Title= "Small road inside a forest", CreatedAt= DateTime.Now, UserId= 1 },
                new Photo() { Id = 4, ImageUrl= "https://images.unsplash.com/photo-1671600939110-7b0625c25ef5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDE0fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=500&q=60", Title= "A peacock in a forest", CreatedAt= DateTime.Now, UserId= 2 },
                new Photo() { Id = 5, ImageUrl= "https://images.unsplash.com/photo-1686224736284-074484ae7c9b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHx0b3BpYy1mZWVkfDM5fDZzTVZqVExTa2VRfHxlbnwwfHx8fHw%3D&auto=format&fit=crop&w=600&q=60", Title= "A side of the sky mountains ", CreatedAt= DateTime.Now, UserId= 1 },
                new Photo() { Id = 6, ImageUrl= "https://images.unsplash.com/photo-1686548812883-9d3777f4c137?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzfHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60", Title= "A small river inside a forest", CreatedAt= DateTime.Now, UserId= 2 },
                new Photo() { Id = 7, ImageUrl= "https://images.unsplash.com/photo-1682685797818-c9dc151d241e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHwyNnx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60", Title= "The mountains in a desert", CreatedAt= DateTime.Now, UserId= 2 }
            );
        }
    }
}
