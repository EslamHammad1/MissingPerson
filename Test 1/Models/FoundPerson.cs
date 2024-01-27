using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Test_1.Models;

namespace Test_1.models
{
    public class FoundPerson :BaseEntity
    {
        [Required]
        public string FoundCity { get; set; } = string.Empty;
    }
}
