namespace RhythmiX.WPF.Services
{
    public static class AuthenticationSettingsHandler
    {
        public static void SaveSettings(string email, string password)
        {
            Properties.Settings.Default.Email = email;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();
        }

        public static void LoadSettings(out string email, out string password)
        {
            email = Properties.Settings.Default.Email;
            password = Properties.Settings.Default.Password;
        }
    }
}
