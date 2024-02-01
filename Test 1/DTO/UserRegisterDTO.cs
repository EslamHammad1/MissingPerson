namespace Test_1.DTO
{
    public class UserRegisterDTO
    {
        [Required]
<<<<<<< HEAD
        public string UserName { get; set; } = string.Empty;
=======
        public string Name { get; set; } = string.Empty;
>>>>>>> 37adc52dce82ee54449ea140264574bb0ea04451
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}
