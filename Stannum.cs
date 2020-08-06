using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Stannum.Grammar;

namespace Stannum
{
    internal static class Stannum
    {
        private const string Version = "alpha";
        private static readonly AstConverter Converter = new AstConverter();
        private static readonly Environment Environment = new Environment(new Prelude());
        private static readonly Interpreter Interpreter = new Interpreter(Environment);
        private static readonly Resolver Resolver = new Resolver(Interpreter);
        private static int _replAnonymous;

        public static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    RunRepl();
                    break;

                case 1:
                    RunFile(args[0]);
                    break;

                default:
                    Console.WriteLine("Usage: stannum [file]");
                    break;
            }
        }

        private static void RunRepl()
        {
            Console.WriteLine($"Stannum {Version} | Type .help for more information.");
            
            while (true)
            {
                var source = Prompt(">>> ");

                if (source == null || source == "\u0004")
                {
                    break;
                }

                if (source.StartsWith("."))
                {
                    HandleCommand(source);
                }
                else
                {
                    try
                    {
                        Run(source, true);
                    }
                    // catch (Exception e)
                    // {
                    //     Console.WriteLine(e.Message);
                    // }
                    finally
                    {
                        
                    }
                }
            }
        }

        private static void RunFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("Unrecognized file!");
            }

            Run(File.ReadAllText(path), false);

            if (!Environment.TryGetValue("main", out var main))
            {
                Console.WriteLine("=== Runtime Error ===");
                Console.WriteLine("Variable 'main' is not defined!");
                return;
            }

            if (!(main is ICallable function))
            {
                Console.WriteLine("=== Runtime Error ===");
                Console.WriteLine("Variable 'main' is not callable!");
                return;
            }

            function.Call(Interpreter, new List<object>());
        }

        private static void Run(string source, bool repl)
        {
            var input = new AntlrInputStream(source);
            var lexer = new StannumLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new StannumParser(tokens) {ErrorHandler = new BailErrorStrategy()};

            if (repl)
            {
                var ast = Converter.ConvertRepl(parser.repl(), _replAnonymous.ToString());
                
                Resolver.Resolve(ast);
                Interpreter.Interpret(ast);

                if (Environment.ContainsKey(_replAnonymous.ToString()))
                {
                    _replAnonymous += 1;
                }
            }
            else
            {
                var ast = Converter.ConvertProgram(parser.program());
                
                Resolver.Resolve(ast);
                Interpreter.Interpret(ast);
            }
        }

        private static string Prompt(string output)
        {
            Console.Write(output);
            return Console.ReadLine();
        }

        private static void HandleCommand(string line)
        {
            switch (line)
            {
                case ".env":
                case ".environment":
                    Console.WriteLine("=== ENVIRONMENT ===");
                    Console.WriteLine(Environment);
                    break;
                
                case ".h":
                case ".help":
                    Console.WriteLine("=== HELP ===");
                    Console.WriteLine("Available commands");
                    Console.WriteLine(".environment, .env:\tPrints all the defined names in the environment.");
                    Console.WriteLine(".help, .h:\t\tPrints this message.");
                    Console.WriteLine(".quit, .q:\t\tQuits the REPL.\n");
                    break;

                case ".q":
                case ".quit":
                    Console.WriteLine("Bye.\n");
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("?\n");
                    break;
            }
        }
    }
}