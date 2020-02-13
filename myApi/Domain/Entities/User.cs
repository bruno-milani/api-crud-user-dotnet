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
    }
}
