using System;

namespace Stannum
{
    public class Prelude : Environment
    {
        public Prelude()
        {
            Define("None", null);
            Define("True", true);
            Define("False", false);
            
            Define("exit", new Builtin(1, arguments =>
            {
                if (!(arguments[0] is double number))
                {
                    throw new Exception("Exit code not a number!");
                }

                try
                {
                    var code = Convert.ToInt32(number);
                    System.Environment.Exit(code);
                }
                catch (OverflowException)
                {
                    throw new Exception("Exit code is invalid!");
                }

                return null;
            }));

            Define("print", new Builtin(1, arguments =>
            {
                Console.WriteLine(Interpreter.Stringify(arguments[0]));
                return null;
            }));
            
            Define("write", new Builtin(1, arguments =>
            {
                Console.Write(Interpreter.Stringify(arguments[0]));
                return null;
            }));
            
            Define("writeline", new Builtin(1, arguments =>
            {
                Console.WriteLine(Interpreter.Stringify(arguments[0]));
                return null;
            }));
        }
    }
}