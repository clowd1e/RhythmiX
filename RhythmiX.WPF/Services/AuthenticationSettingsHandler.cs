namespace RhythmiX.WPF.Services
{
    public static class AuthenticationSettingsHandler
    {
        public static void SaveSettings(string username, string password)
        {
            Properties.Settings.Default.Username = username;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();
        }

        public static void LoadSettings(out string username, out string password)
        {
            username = Properties.Settings.Default.Username;
            password = Properties.Settings.Default.Password;
        }
    }
}
