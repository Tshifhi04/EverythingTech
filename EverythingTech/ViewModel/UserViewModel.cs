namespace EverythingTech.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }

        public IFormFile? Image { get; set; }
        public string? ProfileImageUrl { get; internal set; }
        public string? ProfileBio { get; internal set; }
    }
}
