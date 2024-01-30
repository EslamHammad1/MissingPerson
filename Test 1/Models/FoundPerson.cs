namespace Test_1.Models
{
    public class FoundPerson : BaseEntity
    {
        [Required]
        public string FoundCity { get; set; } = string.Empty;
    }
}
