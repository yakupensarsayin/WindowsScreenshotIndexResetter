namespace WindowsScreenshotIndexResetter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("> Ekran Görüntüsü sayacını sıfırlamak için E tuşuna, uygulamadan çıkmak için ESC tuşuna basınız.");
            ConsoleKeyInfo inputKey;
            do
            {
                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.E)
                {
                    Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.
                        OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", true);
                    string currentScreenshotIndexValue = registryKey.GetValue("ScreenshotIndex").ToString();
                    Console.WriteLine($"> Şu anki Ekran Görüntüsü sayacınız --> {currentScreenshotIndexValue}");
                    registryKey.SetValue("ScreenshotIndex", "1");
                    registryKey.Close();
                    Console.WriteLine("> Ekran Görüntüsü sayacı başarıyla sıfırlandı.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Çıkmak için herhangi bir tuşa basınız...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            } while (inputKey.Key != ConsoleKey.Escape);
            Environment.Exit(0);
           
        }
    }
}