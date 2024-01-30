namespace Test_1.Settings
{
    public static class FileSetting
    {
        public const string ImagesPath = "/wwwrot/images";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
