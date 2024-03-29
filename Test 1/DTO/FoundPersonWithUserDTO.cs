﻿namespace Test_1.DTO
{
    public class FoundPersonWithUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string FoundCity { get; set; } = string.Empty;
        public string Address_City { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string PersonWhoFoundhim { get; set; } = string.Empty;
        public string PhonePersonWhoFoundhim { get; set; } = string.Empty;
    }
}
