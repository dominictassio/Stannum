using System;
using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Stannum.Grammar;

namespace Stannum
{
    internal static class Stannum
    {
        private static readonly Environment Environment = new Environment(new Prelude());
        private static readonly Interpreter Interpreter = new Interpreter(Environment);

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
            for (var line = 1; ; line += 1)
            {
                var source = Prompt($"repl:{line}> ");

                if (source == null || source == "\u0004")
                {
                    break;
                }

                if (source.StartsWith("."))
                {
                    line -= 1;
                    HandleCommand(source);
                }
                else
                {
                    try
                    {
                        Run(source, true);
                    }
                    catch (Exception e)
                    {
                        line -= 1;
                        Console.WriteLine(e.Message);
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
                throw new Exception("Variable 'main' is not defined!");
            }

            if (!(main is ICallable function))
            {
                throw new Exception("Variable 'main' is not callable!");
            }

            function.Call(Interpreter, new List<object>());
        }

        private static void Run(string source, bool repl)
        {
            var input = new AntlrInputStream(source);
            var lexer = new StannumLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new StannumParser(tokens) {ErrorHandler = new BailErrorStrategy()};
            var converter = new AstConverter();
            var ast = repl ? converter.Convert(parser.repl()) : converter.Convert(parser.program());
            var resolver = new Resolver(Interpreter);

            resolver.Resolve(ast);
            Interpreter.Interpret(ast);
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
                    Console.WriteLine(Environment);
                    break;

                case ".q":
                case ".quit":
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("?");
                    break;
            }
        }

        private enum RunType
        {
            File,
            Repl
        }
    }
}