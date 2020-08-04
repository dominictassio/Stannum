using System;
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
            for (;;)
            {
                var line = Prompt("> ");

                if (line == null || line == "\u0004")
                {
                    break;
                }

                if (line.StartsWith("."))
                {
                    HandleCommand(line);
                }
                else
                {
                    Run(line, RunType.Repl);
                }
            }
        }

        private static void RunFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("Unrecognized file!");
            }

            Run(File.ReadAllText(path), RunType.File);
        }

        private static void Run(string source, RunType type)
        {
            try
            {
                var input = new AntlrInputStream(source);
                var lexer = new StannumLexer(input);
                var tokens = new CommonTokenStream(lexer);
                var parser = new StannumParser(tokens) {ErrorHandler = new BailErrorStrategy()};
                var converter = new AstConverter();

                var ast = type switch
                {
                    RunType.File => converter.Convert(parser.program()),
                    RunType.Repl => converter.Convert(parser.repl()),
                    _ => throw new ArgumentOutOfRangeException(nameof(type))
                };

                var resolver = new Resolver(Interpreter);

                resolver.Resolve(ast);
                Interpreter.Interpret(ast);
            }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }
            finally
            {
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