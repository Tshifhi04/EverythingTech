﻿namespace EverythingTech.ViewModel
{
    public class EditProfileViewModel
    {

        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }

        public IFormFile? Image { get; set; }
    }
}
