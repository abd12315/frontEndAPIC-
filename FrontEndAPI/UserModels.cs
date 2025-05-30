using System.Collections.Generic;

namespace UserModels
{
    public class User
    {
        public string Username { get; set; } = string.Empty; // Default to empty string
        public string Password { get; set; } = string.Empty; // Default to empty string
    }

    public class UserList
    {
        public List<User> Users { get; set; } = new List<User>(); // Always initialize to an empty list
    }
}
