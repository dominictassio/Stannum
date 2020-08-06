namespace Stannum.Ast
{
    public class RecordField : AstNode
    {
        public RecordField(string name, Expr value)
        {
            Name = name;
            Value = value;
        }
        
        public string Name { get; }
        
        public Expr Value { get; }
    }
}