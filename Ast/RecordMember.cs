namespace Stannum.Ast
{
    public class RecordMember : AstNode
    {
        public RecordMember(string name, Expr value)
        {
            Name = name;
            Value = value;
        }
        
        public string Name { get; }
        
        public Expr Value { get; }
    }
}