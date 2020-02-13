using System;

namespace myApi.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string Sex { get; set; }
        public string Role { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Update_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
