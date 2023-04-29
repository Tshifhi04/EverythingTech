using EverythingTech.Data.Enum;

namespace EverythingTech.ViewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string projectName { get; set; }
        public string? projectDescription { get; set; }
        public string? DueDate { get; set; }
        public string? GitLink { get; set; }

        public string? HelperCredentials { get; set; }
        public ProjectCategory projectCategory { get; set; }

        //  public Address Address { get; set; }
        //will include it

        public string? Image { get; set; }
    }
}
