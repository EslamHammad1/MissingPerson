namespace Test_1.models
{
    public class FoundPerson :BaseEntity
    {
        [Required]
        public string FoundCity { get; set; } = string.Empty;
    }
}
