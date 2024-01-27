using System.Text.Json.Serialization;

namespace Test_1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Min Length is 6  characters")]
        public string Name { get; set; } = string.Empty;
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; } = string.Empty;
        //[Required]
        //[MinLength(8, ErrorMessage = "Min Length is 8 characters")]
        //public string Password { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;
       // [JsonIgnore]
        public virtual FoundPerson? FoundPerson { get; set; }
     //   [JsonIgnore]
        public virtual LostPerson? LostPerson { get; set; }

    }
}
