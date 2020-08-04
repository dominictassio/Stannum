namespace Stannum.Ast
{
    public class Identifier : Expr
    {
        public Identifier(string value)
        {
            Value = value;
        }
        
        public string Value { get; }
    }
}