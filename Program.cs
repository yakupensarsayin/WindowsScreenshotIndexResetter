namespace WindowsScreenshotIndexResetter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("> Press the E key to reset the Screenshot Counter, and the ESC key to exit the application.");
            ConsoleKeyInfo inputKey;
            do
            {
                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.E)
                {

                    try
                    {
                        Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.
                            OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", true);
                        string currentScreenshotIndexValue = registryKey.GetValue("ScreenshotIndex").ToString();
                        Console.WriteLine($"> Your Screenshot Counter before reset --> {currentScreenshotIndexValue}");
                        registryKey.SetValue("ScreenshotIndex", 1);
                        registryKey.Close();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("> Screenshot Counter reset successfully.");
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("> The specified directory could not be found. The application will be closed.");
                        CloseApp();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("> An unexpected error has occurred. The application will be closed.");
                        CloseApp();
                    }

                    CloseApp();

                }

            } while (inputKey.Key != ConsoleKey.Escape);

            Environment.Exit(0);
           
        }

        static void CloseApp()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to exit...");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}