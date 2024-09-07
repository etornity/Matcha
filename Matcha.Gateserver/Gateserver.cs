namespace Matcha.Gateserver
{
    using Matcha.Gateserver.Network;
    using Matcha.Shared.Configuration;
    using Matcha.Shared.Exceptions;
    using NLog;

    internal static class Gateserver
    {
        private const string Title = "[2.5.0] Matcha.Gateserver";

        private static readonly Logger s_log = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            AppDomain.CurrentDomain.UnhandledException += OnFatalException;

            Console.Title = Title;
            Console.WriteLine("\nMatcha is a revival of https://git.xeondev.com/Moux23333/FreeSR/");
            Console.WriteLine("Be sure to join https://discord.gg/reversedrooms/\n");

            s_log.Info("Initializing...");

            ConfigurationManager<GateserverConfiguration>.Instance.Initialize("Gateserver.json");
            var serverConfiguration = ConfigurationManager<GateserverConfiguration>.Instance.Model;
            NetworkManager.Instance.Initialize(serverConfiguration.Network).GetAwaiter().GetResult();

            s_log.Info("Server is ready!");
            Thread.Sleep(-1); // TODO: Console handler
        }

        private static void OnFatalException(object sender, UnhandledExceptionEventArgs args)
        {
            if (args.ExceptionObject is ServerInitializationException initException)
            {
                Console.WriteLine("Server initialization failed, unhandled exception!");
                Console.WriteLine(initException);
            }
            else
            {
                Console.WriteLine("Unhandled exception in runtime!");
                Console.WriteLine(args.ExceptionObject);
            }

            Console.WriteLine("Press enter to close this window...");
            Console.ReadLine();
        }
    }
}