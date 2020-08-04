using System;
using System.Collections.Generic;
using Stannum.Ast;

namespace Stannum
{
    public interface ICallable
    {
        object Call(Interpreter interpreter, List<object> arguments);
    }

    public class Builtin : ICallable
    {
        private readonly int _arity;
        private readonly Func<List<object>, object> _func;

        public Builtin(int arity, Func<List<object>, object> func)
        {
            _arity = arity;
            _func = func;
        }
        
        public object Call(Interpreter interpreter, List<object> arguments)
        {
            if (arguments.Count != _arity)
            {
                throw new RuntimeException($"Expected {_arity} arguments, but got {arguments.Count}.");
            }
            
            return _func(arguments);
        }
    }

    public class Lambda : ICallable
    {
        private readonly List<string> _parameters;
        private readonly BlockStmt _body;
        private readonly Environment _closure;

        public Lambda(List<string> parameters, BlockStmt body, Environment closure)
        {
            _parameters = parameters;
            _body = body;
            _closure = closure;
        }

        public object Call(Interpreter interpreter, List<object> arguments)
        {
            if (arguments.Count != _parameters.Count)
            {
                throw new RuntimeException($"Expected {_parameters.Count} arguments, but got {arguments.Count}.");
            }
            
            var environment = new Environment(_closure);

            for (var i = 0; i < _parameters.Count; i += 1)
            {
                environment[_parameters[i]] = arguments[i];
            }

            try
            {
                interpreter.Interpret(_body.Stmts, environment);
            }
            catch (ReturnException @return)
            {
                return @return.Value;
            }

            return null;
        }
    }
}