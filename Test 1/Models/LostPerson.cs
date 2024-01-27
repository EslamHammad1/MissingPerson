namespace Test_1.Models
{
    public class LostPerson : BaseEntity
    {
        [Required]
        public string LostCity { get; set; } = string.Empty;
    }
}
