namespace SuperMario
{
    /// <summary>
    /// Main public static class initiated at the beginning of the program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Public static void which is the first method to be used. It's
        /// purpose is to lunch the Menu Scene at the begining of the program.
        /// It reads no arguments given by the player.
        /// </summary>
        public static void Main()
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
