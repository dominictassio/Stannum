using System.Collections.Generic;

namespace Stannum.Ast
{
    public class Literal : Expr
    {
        public Literal(object value)
        {
            Value = value;
        }
        
        public object Value { get; }
    }
}