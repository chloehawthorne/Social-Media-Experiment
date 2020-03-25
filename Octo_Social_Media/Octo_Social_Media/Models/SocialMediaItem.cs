using SQLite;


namespace Octo_Social_Media.Models
{
    public class SocialMediaItem
    {
        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        [PrimaryKey, Unique]
        public string Username { get; set; }
        public string Password { get; set; }


    }
}
