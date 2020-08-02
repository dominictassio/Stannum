using System.Collections.Generic;

namespace Stannum.Ast
{
    public abstract class Lit<T> : Expr
    {
        public Lit(T value)
        {
            Value = value;
        }
        
        public T Value { get; }
    }

    public class ListLit : Lit<List<Expr>>
    {
        public ListLit(List<Expr> value) : base(value)
        {
        }
    }

    public class NumberLit : Lit<double>
    {
        public NumberLit(double value) : base(value)
        {
        }
    }

    public class RecordLit : Lit<Dictionary<string, Expr>>
    {
        public RecordLit(Dictionary<string, Expr> value) : base(value)
        {
        }
    }
    
    public class StringLit : Lit<string>
    {
        public StringLit(string value) : base(value)
        {
        }
    }
}