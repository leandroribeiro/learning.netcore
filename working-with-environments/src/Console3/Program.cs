﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace Console3
{
    class Program
    {
        /// <summary>
        /// Usage:
        ///   dotnet build && dotnet bin\Debug\netcoreapp1.1\Console3.dll --help
        ///   dotnet build && dotnet bin\Debug\netcoreapp1.1\Console3.dll hide
        ///   dotnet build && dotnet bin\Debug\netcoreapp1.1\Console3.dll hide -?
        ///   dotnet build && dotnet bin\Debug\netcoreapp1.1\Console3.dll hide ALI
        /// </summary>
        /// <param name="args"></param>
        static void Main(params string[] args)
        {

            var app = new CommandLineApplication();
            app.Name = "ninja";
            app.HelpOption("-?|-h|--help");

            app.OnExecute(() =>
            {
                Console.WriteLine("Hello World!");
                return 0;
            });

            app.Command("hide", (command) =>
            {

                command.Description = "Instruct the ninja to hide in a specific location.";
                command.HelpOption("-?|-h|--help");

                var locationArgument = command.Argument("[location]",
                                           "Where the ninja should hide.");

                command.OnExecute(() =>
                {
                    var location = locationArgument.Value != null
                      ? locationArgument.Value
                      : "in a trash can";
                    Console.WriteLine("Ninja is hidden " + location);

                    return 0;
                });

            });

            app.Command("attack", (command) =>
            {
                command.Description = "Instruct the ninja to go and attack!";
                command.HelpOption("-?|-h|--help");

                var excludeOption = command.Option("-e|--exclude <exclusions>",
                                        "Things to exclude while attacking.",
                                        CommandOptionType.MultipleValue);

                var screamOption = command.Option("-s|--scream",
                                       "Scream while attacking",
                                       CommandOptionType.NoValue);

                command.OnExecute(() =>
                {
                    var exclusions = excludeOption.Values;
                    var attacking = (new List<string>
                            {
                                "dragons",
                                "badguys",
                                "civilians",
                                "animals"
                            }).Where(x => !exclusions.Contains(x));

                    Console.Write("Ninja is attacking " + string.Join(", ", attacking));

                    if (screamOption.HasValue())
                    {
                        Console.Write(" while screaming");
                    }

                    Console.WriteLine();

                    return 0;

                });
            });

            app.Execute(args);

        }

    }

}