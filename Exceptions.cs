using System;
using Stannum.Ast;

namespace Stannum
{
    public class RuntimeException : Exception
    {
        public RuntimeException(string message) : base(message)
        {
        }
    }

    public class BreakException : Exception
    {
        public BreakException(string label)
        {
            Label = label;
        }
        
        public string Label { get; }
    }

    public class ContinueException : Exception
    {
        public ContinueException(string label)
        {
            Label = label;
        }
        
        public string Label { get; }
    }

    public class ReturnException : Exception
    {
        public ReturnException(object value)
        {
            Value = value;
        }
        
        public object Value { get; }
    }
}