using System;

namespace Stannum
{
    public class Prelude : Environment
    {
        public Prelude()
        {
            this["None"] = null;
            this["True"] = true;
            this["False"] = false;
            
            this["exit"] = new Builtin(1, arguments =>
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
            });

            this["print"] = new Builtin(1, arguments =>
            {
                Console.Write(arguments[0]);
                return null;
            });

            this["printline"] = new Builtin(1, arguments =>
            {
                Console.WriteLine(arguments[0]);
                return null;
            });
        }
    }
}