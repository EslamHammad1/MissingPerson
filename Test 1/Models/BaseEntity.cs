using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Test_1.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;
        [AllowNull]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        //[Required]
        //[Phone]
        //public string Phone { get; set; } = string.Empty;
        [Required]
        public string Address_City { get; set; } = string.Empty;
        [Required]
        public string Image { get; set; } = string.Empty;
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
