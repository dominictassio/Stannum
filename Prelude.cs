using System;
using System.Collections.Generic;
using System.Globalization;

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
                Console.WriteLine(arguments[0] is string s ? s : Interpreter.Stringify(arguments[0]));
                return null;
            }));

            Define("write", new Builtin(1, arguments =>
            {
                Console.Write(arguments[0] is string s ? s : Interpreter.Stringify(arguments[0]));
                return null;
            }));

            Define("writeline", new Builtin(1, arguments =>
            {
                Console.WriteLine(arguments[0] is string s ? s : Interpreter.Stringify(arguments[0]));
                return null;
            }));

            Define("Number", new Dictionary<string, object>
            {
                ["_"] = new Builtin(1, arguments => arguments[0] is double ? arguments[0] : null),
                ["contains"] = new Builtin(1, arguments => arguments[0] is double),
                ["epsilon"] = double.Epsilon,
                ["maxvalue"] = double.MaxValue,
                ["minvalue"] = double.MinValue,
                ["nan"] = double.NaN,
                ["negativeinfinity"] = double.NegativeInfinity,
                ["positiveinfinity"] = double.PositiveInfinity
            });

            Define("String", new Dictionary<string, object>
            {
                ["_"] = new Builtin(1, arguments => arguments[0] switch
                {
                    double number => number.ToString(CultureInfo.InvariantCulture),
                    string s => s,
                    _ => null
                }),
                ["contains"] = new Builtin(1, arguments => arguments[0] is string),
                ["empty"] = ""
            });

            Define("List", new Dictionary<string, object>
            {
                ["_"] = new Builtin(1, arguments => arguments[0] is List<object> ? arguments[0] : null),
                ["contains"] = new Builtin(1, arguments => arguments[0] is List<object>),
                ["empty"] = new List<object>()
            });

            Define("Record", new Dictionary<string, object>
            {
                ["_"] = new Builtin(1, arguments => arguments[0] is Dictionary<string, object> ? arguments[0] : null),
                ["contains"] = new Builtin(1, arguments => arguments[0] is Dictionary<string, object>),
                ["empty"] = new Dictionary<string, object>()
            });
        }
    }
}