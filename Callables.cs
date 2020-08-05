using System;
using System.Collections.Generic;
using Stannum.Ast;

namespace Stannum
{
    public interface ICallable
    {
        object Call(Interpreter interpreter, List<object> arguments);
    }

    public abstract class CallableBase : ICallable
    {
        protected abstract int Arity { get; }
        public abstract object Call(Interpreter interpreter, List<object> arguments);

        protected void CheckArguments(List<object> arguments)
        {
            if (arguments.Count != Arity)
            {
                throw new RuntimeException($"Expected {Arity} arguments, but got {arguments.Count}.");
            }
        }
        
        public override string ToString()
        {
            return $"({Arity}){{...}}";
        }
    }

    public class Builtin : CallableBase
    {
        private readonly Func<List<object>, object> _func;

        public Builtin(int arity, Func<List<object>, object> func)
        {
            Arity = arity;
            _func = func;
        }

        protected override int Arity { get; }

        public override object Call(Interpreter interpreter, List<object> arguments)
        {
            CheckArguments(arguments);
            return _func(arguments);
        }
    }

    public class Lambda : CallableBase
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

        protected override int Arity => _parameters.Count;

        public override object Call(Interpreter interpreter, List<object> arguments)
        {
            CheckArguments(arguments);

            var environment = new Environment(_closure);

            for (var i = 0; i < _parameters.Count; i += 1)
            {
                environment.Define(_parameters[i], arguments[i]);
            }

            try
            {
                interpreter.ExecuteBlock(_body.Stmts, environment);
            }
            catch (ReturnException @return)
            {
                return @return.Value;
            }

            return null;
        }
    }
}