namespace Matcha.Dispatch
{
    using Matcha.Dispatch.Service;
    using Matcha.Dispatch.Service.Manager;
    using Matcha.Shared.Configuration;
    using Matcha.Shared.Exceptions;
    using NLog;

    internal static class Dispatch
    {
        private const string Title = "Matcha.Dispatch";

        private static readonly Logger s_log = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            AppDomain.CurrentDomain.UnhandledException += OnFatalException;

            Console.Title = Title;
            Console.WriteLine("\nMatcha is a revival of https://git.xeondev.com/Moux23333/FreeSR/");
            Console.WriteLine("Be sure to join https://discord.gg/reversedrooms!\n");

            s_log.Info("Initializing...");

            ConfigurationManager<DispatchConfiguration>.Instance.Initialize("Dispatch.json");
            var serverConfiguration = ConfigurationManager<DispatchConfiguration>.Instance.Model;

            RegionManager.Initialize(serverConfiguration.Region);
            HttpDispatchService.Initialize(serverConfiguration.Network);

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