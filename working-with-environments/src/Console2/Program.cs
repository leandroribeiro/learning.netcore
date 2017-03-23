using System;
using System.Collections.Generic;
using Microsoft.Extensions.CommandLineUtils;

namespace Console2
{
    class Program
    {
        static void Main(params string[] args)
        {
            // Program.exe <-g|--greeting|-$ <greeting>> [name <fullname>]
            // [-?|-h|--help] [-u|--uppercase]
            var commandLineApplication = new CommandLineApplication(throwOnUnexpectedArg: false);
            CommandArgument names = null;
            commandLineApplication.Command("name", (target) => names = target.Argument("fullname", "Enter the full name of the person to be greeted.", multipleValues: true));

            var greeting = commandLineApplication.Option(
                "-$|-g |--greeting <greeting>",
                "The greeting to display. The greeting supports"
                + " a format string where {fullname} will be "
                + "substituted with the full name.",
                CommandOptionType.SingleValue);

            var uppercase = commandLineApplication.Option("-u | --uppercase", "Display the greeting in uppercase.", CommandOptionType.NoValue);

            commandLineApplication.HelpOption("-? | -h | --help");
            commandLineApplication.OnExecute(() =>
            {
                if (greeting.HasValue())
                {
                    Greet(greeting.Value(), names.Values, uppercase.HasValue());
                }
                return 0;
            });

            commandLineApplication.Execute(args);

        }

        private static void Greet(
  string greeting, IEnumerable<string> values, bool useUppercase)
        {
            Console.WriteLine(greeting);
        }

    }

}
