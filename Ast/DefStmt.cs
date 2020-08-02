namespace Stannum.Ast
{
    public class DefStmt : Stmt
    {
        public DefStmt(string name, Expr value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        
        public Expr Value { get; }
    }
}